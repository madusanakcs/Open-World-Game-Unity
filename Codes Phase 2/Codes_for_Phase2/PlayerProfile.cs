using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using System;

[System.Serializable]
public class UserProfile
{
    public User user;
}

[System.Serializable]
public class User
{
    public string firstname;
    public string lastname;
    public string username;
    public string nic;
    public string phoneNumber;
    public string email;
    public string profilePictureUrl;


}




[System.Serializable]
public class UpdateProfileRequest
{
    public string firstname;
    public string lastname;
    public string nic;
    public string phoneNumber;
    public string email;
    public string profilePictureUrl;
}

public class PlayerProfile : MonoBehaviour //This scripts handle all the player data that is fetched from the API
{
    [Header("Profile Details")]
    public GameObject FirstName;
    public GameObject LastName;
    public GameObject Email;
    public GameObject MobileNum;
    public GameObject UserName;
    public GameObject Demand_response_program_member_status;
    public GameObject NIC;
    public GameObject Coins;
    public GameObject Points;
    public GameObject Ranking;

    [Header("Token")]
    private string token;
    private CentralAPIHandler centralAPIHandler;
    private PlayerManager playerManager;
    public TokenData TokenData;
    public bool isProfileCompleted;

    private void Start()
    {   GameObject obj = GameObject.Find("FETCH");
        centralAPIHandler = obj.GetComponent<CentralAPIHandler>();
        playerManager = obj.GetComponent<PlayerManager>();
    }
    public void OnPlayerProfileButton()
    {
        StartCoroutine(FetchDisplayPlayerProfileCoroutine());
        //UpdatePlayerProfile("firstname", "Pabadhi");
    }

    UserProfile userProfile;
    

    private IEnumerator FetchDisplayPlayerProfileCoroutine()
    {
        yield return StartCoroutine(FetchPlayerProfileCoroutine());
        DisplayUserProfile(userProfile.user);

    }

    private IEnumerator FetchPlayerProfileCoroutine()
    {
        yield return StartCoroutine(centralAPIHandler.FetchPlayerProfile());

        string responseBody = centralAPIHandler.GetProfileResponseBody();
        Debug.Log("Player profile response: " + responseBody);

        if (!string.IsNullOrEmpty(responseBody))
        {
            userProfile = JsonUtility.FromJson<UserProfile>(responseBody);

        }
        else
        {
            Debug.LogError("Player profile response is null or empty.");
        }
    }

    private void DisplayUserProfile(User user)
    {
        // Now you can access user profile details like this:
        string firstname = user.firstname;
        string lastname = user.lastname;
        string username = user.username;
        string nic = user.nic;
        string phoneNumber = user.phoneNumber;
        string email = user.email;
        string profilePictureUrl = user.profilePictureUrl;
        playerManager.LoadData();
        int leaderboardRanking = playerManager.GetLeaderboardRanking();
        int points = playerManager.GetPoints();
        int coins = playerManager.GetCoins();
        bool isMember = playerManager.IsMember();
        Debug.Log("First Name: " + firstname);
        Debug.Log("Last Name: " + lastname);
        Debug.Log("Username: " + username);
        Debug.Log("NIC: " + nic);
        Debug.Log("Phone Number: " + phoneNumber);
        Debug.Log("Email: " + email);
        Debug.Log("Profile Picture URL: " + profilePictureUrl);
        Debug.Log("Leaderboard Ranking: " + leaderboardRanking);
        Debug.Log("Points: " + points);
        Debug.Log("Coins: " + coins);
        Debug.Log("Is Member: " + isMember);

        FirstName.GetComponent<TMP_Text>().text = firstname;
        LastName.GetComponent<TMP_Text>().text = lastname;
        Email.GetComponent<TMP_Text>().text = email;
        MobileNum.GetComponent<TMP_Text>().text = phoneNumber;
        UserName.GetComponent<TMP_Text>().text = username;
        NIC.GetComponent<TMP_Text>().text = nic;
        Demand_response_program_member_status.GetComponent<TMP_Text>().text = "Yes";
        Coins.GetComponent<TMP_Text>().text = coins.ToString();
        Points.GetComponent<TMP_Text>().text = points.ToString();
        Ranking.GetComponent<TMP_Text>().text = leaderboardRanking.ToString();
    }

    // public IEnumerator CheckProfileIsEmpty()
    // {
       
    //     yield return StartCoroutine(centralAPIHandler.FetchPlayerProfile());

    //     string responseBody = centralAPIHandler.GetProfileResponseBody();

    //     userProfile = JsonUtility.FromJson<UserProfile>(responseBody);

    //     if (userProfile.user.firstname == null || userProfile.user.lastname == "" || userProfile.user.username == "" || userProfile.user.nic == "" || userProfile.user.phoneNumber == "" || userProfile.user.email == "")
    //     {
    //         isProfileCompleted = false;
    //     }
    //     else
    //     {
    //         isProfileCompleted = true;
    //         Debug.Log("Profile is not empty");
    //     }
    // }

   
    // public bool GetIsProfileCompleted()
    // {//This method is used to check if the profile has empty fields or not
    //     Debug.Log("Checking if profile is empty");
    //     StartCoroutine(CheckProfileIsEmpty());
    //     return isProfileCompleted;
    // }
// public void CheckProfileIsEmpty(Action<bool> onComplete)
// {
//     StartCoroutine(CheckProfileIsEmptyCoroutine(onComplete));
// }

private IEnumerator CheckProfileIsEmptyCoroutine(Action<bool> onComplete)
{
    yield return StartCoroutine(centralAPIHandler.FetchPlayerProfile());

    string responseBody = centralAPIHandler.GetProfileResponseBody();

    userProfile = JsonUtility.FromJson<UserProfile>(responseBody);

    bool isProfileCompleted = !(string.IsNullOrEmpty(userProfile.user.firstname) ||
                                string.IsNullOrEmpty(userProfile.user.lastname) ||
                                string.IsNullOrEmpty(userProfile.user.username) ||
                                string.IsNullOrEmpty(userProfile.user.nic) ||
                                string.IsNullOrEmpty(userProfile.user.phoneNumber) ||
                                string.IsNullOrEmpty(userProfile.user.email));

    onComplete?.Invoke(isProfileCompleted);
}

public IEnumerator GetIsProfileCompleted(Action<bool> onComplete)
{
    Debug.Log("Checking if profile is empty");
    yield return CheckProfileIsEmptyCoroutine(onComplete);
}

    public void UpdatePlayerProfile(string fieldName, string value)
    {
        StartCoroutine(SendUpdateProfileRequest(fieldName, value));
    }


    private IEnumerator SendUpdateProfileRequest(string fieldName, string value)
    {
        yield return StartCoroutine(FetchPlayerProfileCoroutine());

        switch (fieldName)
        {
            case "firstname":
                userProfile.user.firstname = value;
                break;
            case "lastname":
                userProfile.user.lastname = value;
                break;
            case "nic":
                userProfile.user.nic = value;
                break;
            case "phoneNumber":
                userProfile.user.phoneNumber = value;
                break;
            case "email":
                userProfile.user.email = value;
                break;
            case "profilePictureUrl":
                userProfile.user.profilePictureUrl = value;
                break;
            default:
                Debug.LogWarning("Invalid field name provided: " + fieldName);
                yield break;
        }

        UpdateProfileRequest updateRequest = new UpdateProfileRequest
        {
            firstname = userProfile.user.firstname,
            lastname = userProfile.user.lastname,
            nic = userProfile.user.nic,
            phoneNumber = userProfile.user.phoneNumber,
            email = userProfile.user.email,
            profilePictureUrl = userProfile.user.profilePictureUrl
        };

        string requestBody = JsonUtility.ToJson(updateRequest);
        Debug.Log("Request Body: " + requestBody);

        yield return StartCoroutine(centralAPIHandler.UpdatePlayerProfile(requestBody));
    }
    public string[] GetDetaisforQuest()
    {
        StartCoroutine(FetchPlayerProfileCoroutine());
        string[] details = new string[] { userProfile.user.firstname, userProfile.user.lastname, userProfile.user.email };
        return details;
    }
}
