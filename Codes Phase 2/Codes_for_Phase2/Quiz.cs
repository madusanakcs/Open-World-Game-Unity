using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Quiz : MonoBehaviour//This handles the questionaire
{

    public ProfileStatus profileStatus;
    private PlayerProfile playerProfile;
    private PlayerManager playerManager;

    private string[] details;
    private string email;
    private string password;
    private string firstname;
    private string lastname;
    private string questToken;
    
    public int score;

    public bool isQuizDone;

    public GameObject PasswardCanvas;

    [System.Serializable]
    private class QuestTokenResponse
    {
        public string token;
    }
    void Start()
    {
        playerProfile = GetComponent<PlayerProfile>();
        playerManager = GetComponent<PlayerManager>();
    }

    public void StartQuestionnaire()
    {   
        PasswardCanvas.SetActive(false);
        StartCoroutine(GetQuestTokenFetchQuest());
        playerManager.UpdateCoins(35);

        if (profileStatus.IsProfileCompleted)
        {   StartCoroutine(GetQuestTokenFetchQuest());
            return;
        }
        {
            Debug.Log("Profile not completed. You need to comple the player profile first");
            return;
        }
        
               
    }

    private IEnumerator GetQuestTokenFetchQuest()//This handle getting token and fetching question according to the conditions
    {
        playerManager.LoadData();
        if (playerManager.GetIsQuizAnswered())
        {
            Debug.Log("Questionnaire already completed.");
            yield break;
        }
        else
        {
            if (playerManager.GetIsRegistered())
            {
                Debug.Log("Player is registered.");
            }
            else
            {
                yield return StartCoroutine(UserRegistration());
                playerManager.UpdateIsRegistered(true);
            }

            
            yield return StartCoroutine(FetchIsQuizAnswered());
            if (!isQuizDone)
            {
                 DoQuestionnaire();
            }
            else
            {   
                Debug.Log("Questionnaire already completed.");
                playerManager.UpdateIsQuizAnswered(true);
                int current_coins=playerManager.GetCoins();
                yield return StartCoroutine(FetchScore());
                int coins = 5*score+ current_coins;
                playerManager.UpdateCoins(coins);

            }

        }
               
    }

    public IEnumerator UserRegistration()//handle user registration, this only need to do once
    {
        details = playerProfile.GetDetaisforQuest();
        email = details[2];
        lastname = details[1];
        firstname = details[0];
        password =playerManager.GetQuizPassword();
        string json = "{\"firstname\":\"" + firstname + "\",\"lastname\":\"" + lastname + "\",\"email\":\"" + email + "\",\"password\":\"" + password + "\"}";
        Debug.Log("JSON: " + json);
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/api/auth/register", new WWWForm());
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to register user: " + request.error);
        }
        else
        {
            string responseJson = request.downloadHandler.text;
            Debug.Log("User registered successfully. Response: " + responseJson);
        }
    }

      public IEnumerator ObtainQuestionnaireToken()//Get questionaire token to access the questionaire and fetch the questionaire details
    {   details = playerProfile.GetDetaisforQuest();
        email = details[2];
        password =playerManager.GetQuizPassword();;
         playerManager.UpdateQuizPassword(password);
        string url = "http://localhost:8080/api/auth/login";

        string json = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\"}";
        Debug.Log("JSON: " + json);
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        UnityWebRequest request = UnityWebRequest.Post(url, new WWWForm());
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to login user: " + request.error);
        }
        else
        {
            string responseJson = request.downloadHandler.text;
            questToken = JsonUtility.FromJson<QuestTokenResponse>(responseJson).token;
            Debug.Log("User logged successfully. Response: " + responseJson);
        }
        DoQuestionnaire();
    }
    public IEnumerator FetchIsQuizAnswered()//This check if the questionaire is already answered
    {
        string url = "http://localhost:8080/user/isQuizDone";

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Authorization", "Bearer " + questToken);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to fetch questionnaire: " + request.error);
        }
        else
        {
            string responseJson = request.downloadHandler.text;
            Debug.Log("Questionnaire fetched successfully. Response: " + responseJson);
            
            isQuizDone = bool.Parse(responseJson);
        }
    }

    public IEnumerator FetchScore() //This fetch the score of the questionaire
    {
        string url = "http://localhost:8080/user/getScore";

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Authorization", "Bearer " + questToken);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to fetch questionnaire: " + request.error);
        }
        else
        {
            string responseJson = request.downloadHandler.text;
            Debug.Log("Questionnaire fetched successfully. Response: " + responseJson);
            // Parse the JSON response to extract the boolean value
            score = int.Parse(responseJson);
        }

    }
   
    public void DoQuestionnaire()//This open the questionaire in the browser
    {
        string url = "http://localhost:3000/?jwtToken="+ questToken;
        Application.OpenURL(url);
    }

    public IEnumerator ObtainScore(){//this is obtaine the coins earned from the questionaire
        if (isQuizDone) {
            playerManager.LoadData();
            yield return StartCoroutine(FetchScore());
            int coins = 5*score+ playerManager.GetCoins();
            playerManager.UpdateCoins(coins);
            playerManager.UpdateIsQuizAnswered(true);

        }
    }



}
