using Newtonsoft.Json;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class UserView
{
    public string firstname;
    public string lastname;
    public string username;
    public string nic;
    public string phoneNumber;
    public string email;
}

public class UserViewsResponse
{
    public List<UserView> userViews;
}

public class LeaderboardManager : MonoBehaviour
{
    private CentralAPIHandler centralAPIHandler;
    private PlayerManager playerManager;
    private UserViewsResponse userViewsResponse;
    private PowerConsumption powerConsumption;
    private PlayerProfile playerProfile;
    private string username;
    private float difference;
    private List<string> usernames = new List<string>(); // Initialize usernames
    private int[] missionScores = { 100, 200, 300, 400, 500 };
    private const int maxMissions = 5;

    float itemSpacing = 0f;
    float itemWidth;
    public int rank = 0;

    public GameObject leaderboardItemPrefab; // Assign the prefab in the Unity Inspector
    public Transform leaderboardParent; 

    void Start()
    {
        centralAPIHandler = GetComponent<CentralAPIHandler>();
        playerProfile = GetComponent<PlayerProfile>();
        powerConsumption = GetComponent<PowerConsumption2>();
        playerManager = GetComponent<PlayerManager>();
        StartCoroutine(FetchLeaderboard());
        StartCoroutine(playerProfile.FetchPlayerProfileCoroutine());
    }

    public void OnLeaderboardButton()
    {
        GenerateLeaderboard();
    }

    private IEnumerator FetchLeaderboard() // Fetch player list and take usernames to an array.
    {
        yield return StartCoroutine(centralAPIHandler.FetchPlayerList());
        string response = centralAPIHandler.GetPlayerList();
        if (!string.IsNullOrEmpty(response))
        {
            userViewsResponse = JsonConvert.DeserializeObject<UserViewsResponse>(response);
            if (userViewsResponse != null && userViewsResponse.userViews != null)
            {
                usernames.Clear();
                foreach (UserView userView in userViewsResponse.userViews)
                {
                    usernames.Add(userView.username);
                }
                Debug.Log("Usernames fetched: " + string.Join(", ", usernames));
            }
            else
            {
                Debug.LogError("Failed to parse player list response.");
            }
        }
        else
        {
            Debug.LogError("Empty player list response.");
        }
    }

    public string[,] AssignLeaderboardScores(List<string> usernames) // This function use to  assign score to other players
    {
        int userCount = usernames.Count;
        string[,] leaderboard = new string[userCount, 2];
        System.Random random = new System.Random();

        for (int i = 0; i < userCount; i++)
        {
            int completedMissions = random.Next(0, maxMissions + 1);
            int powerSavingsScore = random.Next(-9, 10)*10;
            int score = 0;
            for (int j = 0; j < completedMissions; j++)
            {
                score += missionScores[j];
            }
            score += powerSavingsScore;
            if (score < 0)
            {
                score = 0;
            }
            leaderboard[i, 0] = usernames[i];
            leaderboard[i, 1] = score.ToString();
        }
        return leaderboard;
    }

    private void PrintLeaderboard(string[,] leaderboard) // This is for testing purposes.
    {
        Debug.Log("Leaderboard:");
        for (int i = 0; i < leaderboard.GetLength(0); i++)
        {
            Debug.Log(leaderboard[i, 0] + ": " + leaderboard[i, 1]);
        }
    }

    private string[,] SortLeaderboard(string[,] leaderboard, string username) // This sort leaderboard and get the rank of the player to show it on player profile.
    {                                                                          // That is the reason for taking username as the second argument.
        int length = leaderboard.GetLength(0);
        List<(string Username, int Score)> leaderboardList = new List<(string Username, int Score)>();

        // Convert 2D array to list of tuples
        for (int i = 0; i < length; i++)
        {
            leaderboardList.Add((leaderboard[i, 0], int.Parse(leaderboard[i, 1])));
        }
        
        // Sort the list by score in descending order
        leaderboardList.Sort((a, b) => b.Score.CompareTo(a.Score));

        // Convert the sorted list back to a 2D array
        string[,] sortedLeaderboard = new string[length, 2];
        for (int i = 0; i < length; i++)
        {
            sortedLeaderboard[i, 0] = leaderboardList[i].Username;
            sortedLeaderboard[i, 1] = leaderboardList[i].Score.ToString();
        }

        // Find rank of the given username
        for (int i = 0; i < length; i++)
        {
            if (sortedLeaderboard[i, 0] == username)
            {
                rank = i + 1; 
                break;
            }
        }  
        Debug.Log("Rank: " + rank);
        Debug.Log("Points: " + sortedLeaderboard[rank - 1, 1]);
        playerManager.UpdateLeaderboardRanking(rank);
        playerManager.UpdatePoints(int.Parse(sortedLeaderboard[rank - 1, 1]));
        return sortedLeaderboard;
    }

    public void GenerateLeaderboard()
    {
        StartCoroutine(powerConsumption.GetDifferenceDaily(diff =>
        {
            difference = diff; //get the difference of the power in units between 2 days before the current date and yesterday
            Debug.Log("Difference in daily power consumption: " + difference);

            username = playerProfile.GetUserName(); // take the user name of the current player
            if (usernames.Contains(username))// remove that user name from the fetched username list
            {
                usernames.Remove(username);
            }
            string[,] leaderboard = AssignLeaderboardScores(usernames);// Assign scores to the other users 
            Debug.Log("Generated Leaderboard: " + leaderboard[0, 0] + ": " + leaderboard[0, 1]);

            string[,] playerScore = CalculateScore(difference);// Calculate score to the current player
            Debug.Log("Calculated Player Score: " + playerScore[0, 0] + ": " + playerScore[0, 1]);

            string[,] updatedLeaderboard = AppendPlayerScoreToLeaderboard(leaderboard, playerScore);// appent current player and other players
            updatedLeaderboard = SortLeaderboard(updatedLeaderboard, username);
            PrintLeaderboard(updatedLeaderboard);
            PopulateLeaderboard(updatedLeaderboard);
        }));
    }

    public string[,] CalculateScore(float difference) // This calculate the score of the player 
    {
        string path = Application.persistentDataPath + "/player.json";
        PlayerDataForSave playerData;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                playerData = formatter.Deserialize(stream) as PlayerDataForSave;
            }
             if (playerData == null)
        {
            Debug.LogError("Failed to deserialize data.");
            return null;
        }

        Debug.Log("Deserialized data: " +
                  "Money: " + playerData.Money +
                  ", Position: " + string.Join(", ", playerData.position) +
                  ", Mission1: " + playerData.Mission1 +
                  ", Mission2: " + playerData.Mission2 +
                  ", Mission3: " + playerData.Mission3 +
                  ", Mission4: " + playerData.Mission4 +
                  ", Mission5: " + playerData.Mission5 +
                  ", Mission6: " + playerData.Mission6 +
                  ", Mission7: " + playerData.Mission7);

        }
        else
        {
            // Provide default values if the file doesn't exist
            playerData = new PlayerDataForSave();
        }

        int missionScore = 0;
        if (playerData.Mission2) missionScore += missionScores[0];
        if (playerData.Mission3) missionScore += missionScores[1];
        if (playerData.Mission4) missionScore += missionScores[2];
        if (playerData.Mission6) missionScore += missionScores[3];
        if (playerData.Mission7) missionScore += missionScores[4];

        int powerScore = (int)(difference * 10);
        int totalScore = powerScore + missionScore;
        if (totalScore < 0)
        {
            totalScore = 0;
        }

        return new string[,] { { username, totalScore.ToString() } };
    }

    public void PopulateLeaderboard(string[,] data)
    {
        itemWidth = leaderboardParent.GetChild(0).GetComponent<RectTransform>().sizeDelta.y; 
        itemSpacing = itemSpacing * itemWidth;
        Destroy(leaderboardParent.GetChild(0).gameObject);
        leaderboardParent.DetachChildren();

        for (int i = 0; i < data.GetLength(0); i++)
        {
            GameObject newItem = Instantiate(leaderboardItemPrefab, leaderboardParent);
            LeaderboardItem itemScript = newItem.GetComponent<LeaderboardItem>();
            int itemCount = leaderboardParent.childCount - 1;
            itemScript.SetItemPosition(Vector2.down * itemCount * (itemWidth + itemSpacing));

            int rank = i + 1;
            string name = data[i, 0];
            int score = int.Parse(data[i, 1]);

            itemScript.SetValues(rank, name, score);
        }

        ResizeContainer(leaderboardParent);
    }

    void ResizeContainer(Transform container)
    {
        int itemCount = container.childCount;
        container.GetComponent<RectTransform>().sizeDelta = Vector2.up * (itemWidth + itemSpacing) * itemCount;
    }

    public string[,] AppendPlayerScoreToLeaderboard(string[,] leaderboard, string[,] playerScore) 
    {
        int existingRows = leaderboard.GetLength(0);
        int columns = leaderboard.GetLength(1);
        string[,] updatedLeaderboard = new string[existingRows + 1, columns];

        for (int i = 0; i < existingRows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                updatedLeaderboard[i, j] = leaderboard[i, j];
            }
        }

        for (int j = 0; j < columns; j++)
        {
            updatedLeaderboard[existingRows, j] = playerScore[0, j];
        }

        Debug.Log("Updated Leaderboard:");
        for (int i = 0; i < updatedLeaderboard.GetLength(0); i++)
        {
            Debug.Log(updatedLeaderboard[i, 0] + ": " + updatedLeaderboard[i, 1]);
        }

        return updatedLeaderboard;
    }
}