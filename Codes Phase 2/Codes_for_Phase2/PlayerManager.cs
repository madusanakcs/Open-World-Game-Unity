using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
using System.IO;
using System;
using UnityEngine.UI;



[System.Serializable]
public class PlayerData
{
    public bool isamember;
    public int coins;
    public int points;
    public int leaderboardRanking;
    public bool isQuizAnswered;
    
    public bool isRegistered;
    public string quizPassword;
}

public class PlayerManager : MonoBehaviour

{
    private PlayerData playerData = new PlayerData();
    public InputField inputField;
   
    private string persistentPath = "";

    private void Start()
    {  
       
        
       
    }
    // This script manages all player data that should save. 

    private void Awake()
    {
        persistentPath = Application.persistentDataPath + "/SaveData.json";
       
       
    }
    
    public int GetCoins()
    {
        return playerData.coins;
    }
    public int GetPoints()
    {
        return playerData.points;
    }
    public int GetLeaderboardRanking()
    {
        return playerData.leaderboardRanking;
    }

    public bool IsMember()
    {
        return playerData.isamember;
    }


    public bool GetIsQuizAnswered()
    {
        return playerData.isQuizAnswered;
    }
    
    public bool GetIsRegistered()
    {
        return playerData.isRegistered;
    }

    public string GetQuizPassword()
    {
        return playerData.quizPassword;
    }
    //save player data in jason utility
    public void SaveData()
    {
        try
        {
            string savePath = persistentPath;

            Debug.Log("Saving Data at " + savePath);
            string json = JsonUtility.ToJson(playerData);
            Debug.Log(json);

            using StreamWriter writer = new StreamWriter(savePath);
            writer.Write(json);

            Debug.Log("Data saved successfully!");
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving data: " + e.Message);
        }
    }

    public void LoadData()
{
    string jsonFilePath = persistentPath;

    if (File.Exists(jsonFilePath))
    {
        try
        {
            using (StreamReader reader = new StreamReader(jsonFilePath))
            {
                string json = reader.ReadToEnd();
                playerData = JsonUtility.FromJson<PlayerData>(json);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error loading data: " + e.Message);
        }
    }
    else
    {
        Debug.LogWarning("No saved data found. Assigning default values.");

        // Assign default values
        playerData.coins = 0;
        playerData.points = 0;
        playerData.leaderboardRanking = 0;
        playerData.isamember = true;
        playerData.isQuizAnswered = false;
        playerData.isRegistered = false;
        playerData.quizPassword = "";

    }
}

public void UpdateCoins (int coins)
{   
    LoadData();
    playerData.coins = coins;
    SaveData();

}
public void UpdatePoints (int points)
{   
    LoadData();
    playerData.points = points;
    SaveData();
}

public void UpdateLeaderboardRanking (int leaderboardRanking)
{   
    LoadData();
    playerData.leaderboardRanking = leaderboardRanking;
    SaveData();
}

public void UpdateIsMember (bool isamember)
{   
    LoadData();
    playerData.isamember = isamember;
    SaveData();
}

public void UpdateIsQuizAnswered (bool isQuizAnswered)
{   
    LoadData();
    playerData.isQuizAnswered = isQuizAnswered;
    SaveData();
}

public void UpdateIsRegistered (bool isRegistered)
{   
    LoadData();
    playerData.isRegistered = isRegistered;
    SaveData();
}  


public void UpdateQuizPassword (string quizPassword)
{
    LoadData();
    Debug.Log("Quiz Password: " + quizPassword);
    Debug.Log("Update Quiz Password");
    playerData.quizPassword = quizPassword;
    SaveData();
}

public void resetData()
{
    playerData.coins = 0;
    playerData.points = 0;
    playerData.leaderboardRanking = 0;
    playerData.isamember = true;
    playerData.isQuizAnswered = false;
    playerData.isRegistered = false;
    playerData.quizPassword = "";
    SaveData();

}

}