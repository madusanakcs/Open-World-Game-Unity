using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CentralAPIHandler : MonoBehaviour//This scripts is used to handle all the API calls
{
    public TokenData tokenData; // Reference to TokenData ScriptableObject

    private string apiKey = "NjVjNjA0MGY0Njc3MGQ1YzY2MTcyMmNjOjY1YzYwNDBmNDY3NzBkNWM2NjE3MjJjMg";
    private string baseurl = "http://20.15.114.131:8080/api";
    private string responseBody;
    private string jsonResponse_y;
    private string responseBody_m;

    private string responseBody_cm;

    private string responseBody_d;
    private float currentPowerConsumption;
   private string playerListResponse;



    [System.Serializable]


    private class TokenResponse
    {
        public string token;
    }
    [System.Serializable]
    private class CurrentPowerConsumptionResponse
    {
        public float currentConsumption;
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

    public IEnumerator UpdatePlayerProfile(string requestBody)
    {
        if (string.IsNullOrEmpty(tokenData.token))
        {
            Debug.LogError("Token not found.");
            yield break;
        }

        string url = baseurl + "/user/profile/update";

        using (UnityWebRequest www = UnityWebRequest.Put(url, requestBody))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Authorization", "Bearer " + tokenData.token);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                requestBody = www.downloadHandler.text;
                Debug.Log("Player profile updated successfully: " + responseBody);
            }
            else
            {
                Debug.LogError("Failed to update player profile: " + www.error);
            }
        }
    }

    public IEnumerator FetchPowerConsumptionYearly(int year)
    {
        string url = baseurl +"/power-consumption/yearly/view"+ "?year=" + year;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Authorization", "Bearer " + tokenData.token);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                jsonResponse_y = www.downloadHandler.text;
                Debug.Log("Power consumption response: " + jsonResponse_y);
            }
            else
            {
                Debug.LogError("Failed to fetch power consumption: " + www.error);
            }
        }


    }

    public string GetPowerConsumptionYearlyResponseBody()
{
    return jsonResponse_y;
}

    

    public IEnumerator ViewPowerConsumptionByMonth(int year, string month)
    {
        string url = baseurl + "/power-consumption/month/view?year=" + year + "&month=" + month;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Authorization", "Bearer " + tokenData.token);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                responseBody_m = www.downloadHandler.text;
                Debug.Log("Power Consumption by Month: " + responseBody);
            }
            else
            {
                Debug.LogError("Failed to fetch power consumption by month: " + www.error);
            }
        }
    }

    public string GetPowerConsumptionByMonthResponseBody()
    {
        return responseBody_m;
    }

    // View Power Consumption by Current Month
    public IEnumerator ViewPowerConsumptionByCurrentMonth()
    {
        string url = baseurl + "/power-consumption/current-month/view";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Authorization", "Bearer " + tokenData.token);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                responseBody_cm = www.downloadHandler.text;
                Debug.Log("Power Consumption by Current Month: " + responseBody_cm);
            }
            else
            {
                Debug.LogError("Failed to fetch power consumption by current month: " + www.error);
            }
        }
    }

public string GetPowerConsumptionByCurrentMonthResponseBody()
    {
        return responseBody_cm;
    }

    public IEnumerator ViewDailyPowerConsumptionByMonth(int year, string month)
    {
        string url = baseurl + "/power-consumption/month/daily/view?year=" + year + "&month=" + month;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Authorization", "Bearer " + tokenData.token);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                responseBody_d = www.downloadHandler.text;
                Debug.Log("Daily Power Consumption by Month: " + responseBody_d);
            }
            else
            {
                Debug.LogError("Failed to fetch daily power consumption by month: " + www.error);
            }
        }
    }
     public string GetDailyMonthResponseBody(){
        return responseBody_d;
     }

    // View Daily Power Consumption by Current Month
    public IEnumerator ViewDailyPowerConsumptionByCurrentMonth()
    {
        string url = baseurl + "/power-consumption/current-month/daily/view";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Authorization", "Bearer " + tokenData.token);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseBody = www.downloadHandler.text;
                Debug.Log("Daily Power Consumption by Current Month: " + responseBody);
            }
            else
            {
                Debug.LogError("Failed to fetch daily power consumption by current month: " + www.error);
            }
        }
    }
     public IEnumerator GetCurrentPowerConsumption()
    {
        if (string.IsNullOrEmpty(tokenData.token))
        {
            Debug.LogError("Token not found.");
            yield break;
        }

        string url = baseurl + "/power-consumption/current/view";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Authorization", "Bearer " + tokenData.token);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseBody = www.downloadHandler.text;
                CurrentPowerConsumptionResponse response = JsonUtility.FromJson<CurrentPowerConsumptionResponse>(responseBody);
                currentPowerConsumption = response.currentConsumption;
            }
            else
            {
                Debug.LogError("Failed to fetch current power consumption: " + www.error);
            }
        }
    }

    public float GetCurrentPowerConsumptionValue()
    {
        return currentPowerConsumption;
    }

   public IEnumerator FetchPlayerList()
    {
        if (string.IsNullOrEmpty(tokenData.token))
        {
            Debug.LogError("Token not found.");
            yield break;
        }

        string url = baseurl + "/user/profile/list";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Authorization", "Bearer " + tokenData.token);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                playerListResponse = www.downloadHandler.text;
                Debug.Log("Player list response: " + playerListResponse);
            }
            else
            {
                Debug.LogError("Failed to fetch player list: " + www.error);
            }
        }
    }

    public string GetPlayerList()
    {
        return playerListResponse;
    }

}