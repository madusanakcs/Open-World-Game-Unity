using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class Missions : MonoBehaviour
{
    public bool Mission1 = false;
    public bool Mission2 = false;
    public bool Mission3 = false;
    public bool Mission4 = false;
    public bool Mission5 = false;
    public bool Mission6 =false;
    public bool Mission7 =false;

    [Header("Mission things UI")]
    public Text Mission1Text;



    [Header("Missions 3 Objects")]
    public mission3Script Object1;
    public mission3Script Object2;
    public mission3Script Object3;
    public mission3Script Object4;
    public mission3Script Object5;
    public mission3Script Object6;
    public mission3Script Object7;
    public mission3Script Object8;
    public mission3Script Object9;
    public mission3Script Object10;
    public mission3Script Object11;
    public mission3Script Object12;
    public mission3Script Object13;
    public mission3Script Object14;
    public mission3Script Object15;
    public mission3Script Object16;
    public mission3Script Object17;
    public mission3Script Object18;
    public mission3Script Object19;
    public mission3Script Object20;
    public mission3Script Object21;
    public mission3Script Object22;
    public mission3Script Object23;
    public mission3Script Object24;
    public mission3Script Object25;
    public mission3Script Object26;
    public mission3Script Object27;
    public mission3Script Object28;
    public mission3Script Object29;
    public mission3Script Object30;
    public mission3Script Object31;
    public mission3Script Object32;
    public mission3Script Object33;
    public mission3Script Object34;
    public mission3Script Object35;
    public mission3Script Object36;
    public mission3Script Object37;
    public mission3Script Object38;
    public mission3Script Object39;
    public mission3Script Object40;
    public mission3Script Object41;


    [Header("Missions 4 Animals")]
    public animal_deer Animal1;
    public animal_deer Animal2;
    public animal_deer Animal3;
    public animal_deer Animal4;
    public animal_deer Animal5;




    [Header("Mission 5 and 6 7")]
    public GameObject Mission5Timeline;
    public GameObject bear;
    public wolf bearWolf;
    public GameObject Mission7things;



    public GameObject mission2;
        public GameObject mission3;

    private void Update()
    {
        if (Mission1 == false && Mission2 == false && Mission3 == false && Mission4 == false && Mission5 == false && Mission6 == false && Mission7 == false)
        {
            Debug.Log("Locate your house and Save game");
            Mission1Text.text = "Locate your house and Save game";
        }
        {                     
            Debug.Log(" Locate your house and Save game");
            Mission1Text.text = "Locate your house and Save game";
        }

        if (Mission1 == true && Mission2 == false && Mission3 == false && Mission4 == false && Mission5 == false && Mission6 == false && Mission7 == false)
        {   
            mission2.SetActive(true);
            Debug.Log(" Go Farm and plant some crops");
            Mission1Text.text = "Go Farm and plant some crops";


        }

        if (Mission1 == true && Mission2 == true && Mission3 == false && Mission4 == false && Mission5 == false && Mission6 == false && Mission7 == false)
        {
            Debug.Log("Get to Tactor and plow the field");
            mission3.SetActive(true);
            Mission1Text.text = "Get to Tactor and plow the field";

            if (Object1.MudOK == true && Object2.MudOK == true && Object3.MudOK == true && Object4.MudOK == true && Object5.MudOK == true && Object6.MudOK == true && Object7.MudOK == true && Object8.MudOK == true && Object9.MudOK == true && Object10.MudOK == true && Object11.MudOK == true && Object12.MudOK == true && Object13.MudOK == true && Object14.MudOK == true && Object15.MudOK == true && Object16.MudOK == true && Object17.MudOK == true && Object18.MudOK == true && Object19.MudOK == true && Object20.MudOK == true && Object21.MudOK == true && Object22.MudOK == true && Object23.MudOK == true && Object24.MudOK == true && Object25.MudOK == true && Object26.MudOK == true && Object27.MudOK == true && Object28.MudOK == true && Object29.MudOK == true && Object30.MudOK == true && Object31.MudOK == true && Object32.MudOK == true && Object33.MudOK == true && Object34.MudOK == true && Object35.MudOK == true && Object36.MudOK == true && Object37.MudOK == true && Object38.MudOK == true && Object39.MudOK == true && Object40.MudOK == true && Object41.MudOK == true)
            {
                Mission3 = true;
            }
        }
        
        if (Mission1 == true && Mission2 == true && Mission3 == true && Mission4 == false && Mission5 == false && Mission6 == false && Mission7 == false)
        {
            Debug.Log("Go to the forest and Hunt the Deers (5)");
            Mission1Text.text = "Go to the forest and Hunt the Deers (5)";

            if (Animal1.DeerDied == true && Animal2.DeerDied == true && Animal3.DeerDied == true && Animal4.DeerDied == true && Animal5.DeerDied == true)
            {
                Mission4 = true;
            }
        }

        if (Mission1 == true && Mission2 == true && Mission3 == true && Mission4 == true && Mission5 == false && Mission6 == false && Mission7 == false)

        {
            Debug.Log(" Go to meet the Martha");
            Mission1Text.text = "Go to meet the Martha";
            Mission5Timeline.SetActive(true);
        }

        if (Mission1 == true && Mission2 == true && Mission3 == true && Mission4 == true && Mission5 == true && Mission6 == false && Mission7 == false)
        {
            Debug.Log("Go to the forest and Hunt the Bear");
            Mission1Text.text = "Go to the forest and Hunt the Bear";
            bear.SetActive(true);

            if(bearWolf.wolfDie==true)
            {
                Mission6 = true;
            }
        }
        if (Mission1 == true && Mission2 == true && Mission3 == true && Mission4 == true && Mission5 == true && Mission6 == true && Mission7 == false)
        {
            Debug.Log("Find the SuperCar and Steal it");
            Mission1Text.text = "Find the SuperCar and Steal it";
            Mission7things.SetActive(true);


        }

    }
}
