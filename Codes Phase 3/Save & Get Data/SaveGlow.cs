using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveGlow : MonoBehaviour
{   
    public Missions missions;
    public Player player;
    public Text MoneyText;

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Player")
        {
            player.SavePlayer();
            Debug.Log("Game Saved");
        }



        if(missions.Mission2==false  && missions.Mission3==false && missions.Mission4==false && missions.Mission5==false)
        {
            missions.Mission1 = true;
            player.Money += 100;
            MoneyText.text = player.Money.ToString();
        }
    }
}
