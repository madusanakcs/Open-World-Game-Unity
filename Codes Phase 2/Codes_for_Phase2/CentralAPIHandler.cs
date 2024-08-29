using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CentralAPIHandler : MonoBehaviour//This scripts is used to handle all the API calls
{
    public TokenData tokenData; // Reference to TokenData ScriptableObject

    private string apiKey ="NjVjNjA0MGY0Njc3MGQ1YzY2MTcyMmNjOjY1YzYwNDBmNDY3NzBkNWM2NjE3MjJjMg";
    private string baseurl = "http://20.15.114.131:8080/api";
    private string responseBody;

   

    [System.Serializable]
    

    private class TokenResponse
    {
        public string token;
    }

    public IEnumerator GetToken()
    {
        string endPoint = baseurl + "/login";

        using (UnityWebRequest www = UnityWebRequest.Post(endPoint, new WWWForm()))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes("{\"apiKey\": \"" + apiKey + "\"}");
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonResponse = www.downloadHandler.text;
                TokenResponse response = JsonUtility.FromJson<TokenResponse>(jsonResponse);
                tokenData.token = response.token; // Store token in TokenData
            }
            else
            {
                Debug.LogError("Failed to fetch token: " + www.error);
            }
        }
    }

    public IEnumerator FetchPlayerProfile()
    {
        if (string.IsNullOrEmpty(tokenData.token))
        {
            Debug.LogError("Token not found.");
            yield break;
        }

        string url = baseurl + "/user/profile/view";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Authorization", "Bearer " + tokenData.token);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                responseBody = www.downloadHandler.text;
                Debug.Log("Player profile response: " + responseBody);
            }
            else
            {
                Debug.LogError("Failed to fetch player profile: " + www.error);
            }
        }
    }

    public string GetProfileResponseBody()
    {
        return responseBody;
    }

    public IEnumerator UpdatePlayerProfile( string requestBody)
    {   
        if (string.IsNullOrEmpty(tokenData.token))
        {
            Debug.LogError("Token not found.");
            yield break;
        }

        string url = baseurl + "/user/profile/update";
        //string requestBody = JsonUtility.ToJson(request);

        using (UnityWebRequest www = UnityWebRequest.Put(url, requestBody))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Authorization", "Bearer " + tokenData.token);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                requestBody = www.downloadHandler.text;
                //UpdatePlayerProfileResponse response = JsonUtility.FromJson<UpdatePlayerProfileResponse>(jsonResponse);
                Debug.Log("Player profile updated successfully: " + responseBody);
            }
            else
            {
                Debug.LogError("Failed to update player profile: " + www.error);
            }
        }
    }
   
}
