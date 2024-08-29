using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
//using Unity.PlasticSCM.Editor.WebApi;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using THOR;
using UnityEngine.UI;


[System.Serializable]
public class MonthlyPowerConsumptionView
{
    public int year;
    public int month;
    public int units;
}

[System.Serializable]
public class DailyPowerConsumptionView
{
    public int year;
    public int month;
    public Dictionary<string, float> dailyUnits;
}

[System.Serializable]

public class DailyPowerConsumptionResponse
{
    public DailyPowerConsumptionView dailyPowerConsumptionView;
}

[System.Serializable]
public class PowerConsumptionResponse
{
    public MonthlyPowerConsumptionView monthlyPowerConsumptionView;
}
[System.Serializable]
public class MonthData
{
    public float units;
}

[System.Serializable]
public class PowerConsumptionResponseYearly
{
    public Dictionary<string, MonthData> units;
}


public class PowerConsumption : MonoBehaviour//This scripts is used to handle all the API calls
{
    private CentralAPIHandler centralAPIHandler;
    public int currentyear;
    public int currentmonth;
    public int currentday;
    public float currenttime;

    public float average_power_monthly;

    public float difference_last_current_month;

    // light component in attach game object
    public GameObject light;

    // thounderstome compounent
    public GameObject thounderstome;

    [Header("Sky Box Matirials")]
    public Material skyboxLiteWarm;
    public Material cloudySky;
    public Material sunnySky;
    public Material Sky01;
    public Material SkyDay;
    public Material Skyxx;
    public Material Skyyy;
    public Material Skyzz;

    [Header("Rain and Wind")]
    public GameObject Rain;
    public GameObject Wind;

    [Header("Power Text")]
    public Text  Daily;
    public Text  Monthly;
    public Text  Yearly;


    Dictionary<int, string> monthMap = new Dictionary<int, string>()
{
    { 1, "JANUARY" },
    { 2, "FEBRUARY" },
    { 3, "MARCH" },
    { 4, "APRIL" },
    { 5, "MAY" },
    { 6, "JUNE" },
    { 7, "JULY" },
    { 8, "AUGUST" },
    { 9, "SEPTEMBER" },
    { 10, "OCTOBER" },
    { 11, "NOVEMBER" },
    { 12, "DECEMBER" }
};



    private void Start()
    {   //GameObject obj = GameObject.Find("FETCH");
        //centralAPIHandler = obj.GetComponent<CentralAPIHandler>();
        centralAPIHandler = GetComponent<CentralAPIHandler>();
        //take current date and time
        currentyear = System.DateTime.Now.Year;
        currentmonth = System.DateTime.Now.Month;
        currentday = System.DateTime.Now.Day;
        currenttime = System.DateTime.Now.Hour;
        Debug.Log("Current Year: " + currentyear);
        Debug.Log("Current Month: " + currentmonth);
        Debug.Log("Current Day: " + currentday);
        Debug.Log("Current Time: " + currenttime);

        StartCoroutine(UpdateEvery30Seconds());

    }

    // Update is called once per 30 second not frame

    IEnumerator UpdateEvery30Seconds()
    {
        while (true)
        {
            // Your code that you want to execute every 30 seconds goes here
            GetDifference();
            GetYearlyDifference();
            GetDifferencePowerConsumption();

            Light lightComponent = light.GetComponent<Light>();
            Debug.Log("Pako");

            if (lightComponent.intensity <= 0.3f)
            {
                // Skybox will be changed to cloudy skybox
                RenderSettings.skybox = skyboxLiteWarm;

                //change the color temprture of light component in attach game object
                lightComponent.colorTemperature = 20000;
            }

            else if (lightComponent.intensity > 0.3f && lightComponent.intensity <= 0.6f)
            {
                // Skybox will be changed to sunny skybox
                RenderSettings.skybox = cloudySky;
                lightComponent.colorTemperature = 3300;
            }

            else if (lightComponent.intensity > 0.6f && lightComponent.intensity <= 0.9f)
            {
                // Skybox will be changed to sunny skybox
                RenderSettings.skybox = sunnySky;
                lightComponent.colorTemperature = 12000;
            }

            else if (lightComponent.intensity > 0.9f && lightComponent.intensity <= 1.2f)
            {
                // Skybox will be changed to sunny skybox
                RenderSettings.skybox = SkyDay;
                lightComponent.colorTemperature = 11500;
            }

            else if (lightComponent.intensity > 1.2f && lightComponent.intensity <= 1.5f)
            {
                // Skybox will be changed to sunny skybox
                RenderSettings.skybox = Skyxx;
                lightComponent.colorTemperature = 7500;
            }

            else if (lightComponent.intensity > 1.5f && lightComponent.intensity <= 2f)
            {
                // Skybox will be changed to sunny skybox
                RenderSettings.skybox = Skyyy;
                lightComponent.colorTemperature = 7500;
            }

            else if (lightComponent.intensity > 2f)
            {
                // Skybox will be changed to sunny skybox
                RenderSettings.skybox = Skyzz;
                lightComponent.colorTemperature = 6500;
            }









            yield return new WaitForSeconds(3f); // Changed to 30 seconds
        }
    }








    public void GetDifferencePowerConsumption()
    {
        StartCoroutine(GetCDifferenceOfMonthlyPower(difference =>
        {
            Debug.Log("Difference in monthly power consumption: " + difference);
            //methana ona tika da ganna

            if (difference < 0)
            {
                Wind.SetActive(true);
                // monthly text will be changed
                Monthly.text = "Monthly - Wasted";
            }
            else
            {
                Wind.SetActive(false);
                // monthly text will be changed
                Monthly.text = "Monthly - Saved";
            }
           
        }));
    }
    public IEnumerator GetCDifferenceOfMonthlyPower(Action<float> callback)
    {
        yield return StartCoroutine(centralAPIHandler.ViewPowerConsumptionByCurrentMonth());
        string responseBody = centralAPIHandler.GetPowerConsumptionByCurrentMonthResponseBody();
        Debug.Log("Response: " + responseBody);

        PowerConsumptionResponse responsecurrent = JsonUtility.FromJson<PowerConsumptionResponse>(responseBody);
        int unitsCurrent = responsecurrent.monthlyPowerConsumptionView.units;
        Debug.Log("Units: " + unitsCurrent);
        string lastMonth = monthMap[currentmonth - 1];

        yield return StartCoroutine(centralAPIHandler.ViewPowerConsumptionByMonth(currentyear, lastMonth));
        string responseBodyLast = centralAPIHandler.GetPowerConsumptionByMonthResponseBody();
        Debug.Log("Response: " + responseBodyLast);
        PowerConsumptionResponse responselast = JsonUtility.FromJson<PowerConsumptionResponse>(responseBodyLast);
        int unitsLast = responselast.monthlyPowerConsumptionView.units;
        Debug.Log("Units: " + unitsLast);
        difference_last_current_month = unitsLast - unitsCurrent;
        Debug.Log("current month: " + unitsCurrent);
        callback(difference_last_current_month / 10);


    }

    public IEnumerator GetDifferenceDaily(Action<float> callback)
    {
        yield return StartCoroutine(centralAPIHandler.ViewDailyPowerConsumptionByMonth(currentyear, monthMap[currentmonth - 1]));
        string responseBody = centralAPIHandler.GetDailyMonthResponseBody();
        Debug.Log("Response: " + responseBody);

        // Deserialize the JSON response
        DailyPowerConsumptionResponse response = JsonConvert.DeserializeObject<DailyPowerConsumptionResponse>(responseBody);
        if (response == null || response.dailyPowerConsumptionView == null)
        {
            Debug.LogError("Failed to deserialize response body or missing data.");
            yield break;
        }

        // Get the consumption values for the last day and two days before
        int lastDay = currentday - 1;
        int twoDaysBefore = currentday - 2;
        Debug.Log("Units: " + response.dailyPowerConsumptionView.dailyUnits);

        // Check if the dictionary contains data for the last day and two days before
        if (response.dailyPowerConsumptionView.dailyUnits.ContainsKey(lastDay.ToString()) &&
            response.dailyPowerConsumptionView.dailyUnits.ContainsKey(twoDaysBefore.ToString()))
        {
            float lastDayConsumption = response.dailyPowerConsumptionView.dailyUnits[lastDay.ToString()];
            float twoDaysBeforeConsumption = response.dailyPowerConsumptionView.dailyUnits[twoDaysBefore.ToString()];

            // Calculate the difference
            float difference = twoDaysBeforeConsumption - lastDayConsumption;

            // Invoke the callback with the difference
            callback(difference);
        }
        else
        {
            Debug.LogError("Data for last day or two days before is not available.");
        }
    }

    public void GetDifference()
    {
        StartCoroutine(GetDifferenceDaily(difference =>
                {
                    ProcessDifference(difference);
                }));
    }

    public IEnumerator GetDaily(Action<float> callback)
    {
        yield return StartCoroutine(centralAPIHandler.GetCurrentPowerConsumption());
        float currentPowerConsumption = centralAPIHandler.GetCurrentPowerConsumptionValue();
        Debug.Log("Current Power Consumption: " + currentPowerConsumption);
        callback(currentPowerConsumption);

    }

    public void GetcurrentPower()
    {
        StartCoroutine(GetDaily(currentPowerConsumption =>
        {
            Debug.Log("Current Power Consumption: " + currentPowerConsumption);
        }));


    }

    public IEnumerator GetYearly(Action<float> callback)
    {
        // Get the data for this year
        yield return StartCoroutine(centralAPIHandler.FetchPowerConsumptionYearly(currentyear));
        string responseBodyThisYear = centralAPIHandler.GetPowerConsumptionYearlyResponseBody();
        Debug.Log("Power consumption response this year: " + responseBodyThisYear);

        PowerConsumptionResponseYearly responseThisYear = null;
        try
        {
            responseThisYear = JsonConvert.DeserializeObject<PowerConsumptionResponseYearly>(responseBodyThisYear);
        }
        catch (Exception e)
        {
            Debug.LogError("Deserialization failed for this year: " + e.Message);
        }

        if (responseThisYear == null || responseThisYear.units == null)
        {
            Debug.LogError("Failed to deserialize response body or missing data for this year.");
            yield break;
        }
        yield return StartCoroutine(centralAPIHandler.FetchPowerConsumptionYearly(currentyear - 1));
        string responseBodyLastYear = centralAPIHandler.GetPowerConsumptionYearlyResponseBody();
        Debug.Log("Power consumption response last year: " + responseBodyLastYear);

        PowerConsumptionResponseYearly responseLastYear = null;
        try
        {
            responseLastYear = JsonConvert.DeserializeObject<PowerConsumptionResponseYearly>(responseBodyLastYear);
        }
        catch (Exception e)
        {
            Debug.LogError("Deserialization failed for last year: " + e.Message);
        }

        if (responseLastYear == null || responseLastYear.units == null)
        {
            Debug.LogError("Failed to deserialize response body or missing data for last year.");
            yield break;
        }

        string currentMonth = monthMap[currentmonth];
        // Calculate the difference
        if (responseThisYear.units.ContainsKey(currentMonth) && responseLastYear.units.ContainsKey(currentMonth))
        {
            float difference = responseLastYear.units[currentMonth].units - responseThisYear.units[currentMonth].units;
            callback(difference / 10);
        }
        else
        {
            if (!responseThisYear.units.ContainsKey(currentMonth))
            {
                Debug.LogError($"Data for the month {currentMonth} is missing in this year's response.");
            }
            if (!responseLastYear.units.ContainsKey(currentMonth))
            {
                Debug.LogError($"Data for the month {currentMonth} is missing in last year's response.");
            }
        }
    }

    public void GetYearlyDifference()
    {
        StartCoroutine(GetYearly(difference =>
        {
            Debug.Log("Difference in yearly power consumption: " + difference);
            if(difference<0)
            {
                Rain.SetActive(true);
                // yearly text will be changed
                Yearly.text = "Yearly - Wasted";
                
            }
            else
            {
                Rain.SetActive(false);
                // yearly text will be changed
                Yearly.text = "Yearly - Saved";
            } 
        }));
    }

    private void ProcessDifference(float difference)
    {
        if (difference <= 0)
        {
            light.GetComponent<Light>().intensity -= 0.1f;
            thounderstome.GetComponent<THOR_Thunderstorm>().probability += 0.05f;
            // light intensity will be decreased by 0.1 based on the difference untill equal to (4 + difference)/10f;
            if (light.GetComponent<Light>().intensity <= (4 + difference) / 4f)
            {
                light.GetComponent<Light>().intensity = (4 + difference) / 4f;
            }

            if (thounderstome.GetComponent<THOR_Thunderstorm>().probability >= (4 - difference) / 10f)
            {
                thounderstome.GetComponent<THOR_Thunderstorm>().probability = (4 - difference) / 10f;
            }

            // Daily text will be changed
            Daily.text = "Daily - Wasted";

        }
        else
        {
            light.GetComponent<Light>().intensity += 0.1f;
            thounderstome.GetComponent<THOR_Thunderstorm>().probability -= 0.05f;
            // light intensity will be increased by 0.1 based on the difference untill equal to (4 + difference)/10f;
            if (light.GetComponent<Light>().intensity >= (4 + difference) / 10f)
            {
                light.GetComponent<Light>().intensity = (4 + difference) / 10f;
            }

            if (thounderstome.GetComponent<THOR_Thunderstorm>().probability <= (4 - difference) / 10f)
            {
                thounderstome.GetComponent<THOR_Thunderstorm>().probability = (4 - difference) / 10f;
            }

            // Daily text will be changed
            Daily.text = "Daily - Saved";
        }
    }
}
