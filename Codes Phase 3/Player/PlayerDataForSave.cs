using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataForSave 
{
    public int Money;
    public float[] position;
    public bool Mission1;
    public bool Mission2;
    public bool Mission3;
    public bool Mission4;
    public bool Mission5;
    public bool Mission6;
    public bool Mission7;


    public PlayerDataForSave(Player player)
    {
        Money = player.Money;
        Mission1 = player.Missions.Mission1;
        Mission2 = player.Missions.Mission2;
        Mission3 = player.Missions.Mission3;
        Mission4 = player.Missions.Mission4;
        Mission5 = player.Missions.Mission5;
        Mission6 = player.Missions.Mission6;
        Mission7 = player.Missions.Mission7;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

}