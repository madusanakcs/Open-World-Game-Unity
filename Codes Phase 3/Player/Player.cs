using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Money;
    public Missions Missions;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerDataForSave data = SaveSystem.LoadPlayer();

        Money = data.Money;

        Missions.Mission1 = data.Mission1;
        Missions.Mission2 = data.Mission2;
        Missions.Mission3 = data.Mission3;
        Missions.Mission4 = data.Mission4;
        Missions.Mission5 = data.Mission5;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }
}