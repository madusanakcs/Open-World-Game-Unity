using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2Script : MonoBehaviour
{

    // 36 plant there
    public PlantSript Plant1;
    public PlantSript Plant2;
    public PlantSript Plant3;
    public PlantSript Plant4;
    public PlantSript Plant5;
    public PlantSript Plant6;
    public PlantSript Plant7;

    public PlantSript Plant8;
    public PlantSript Plant9;
    public PlantSript Plant10;
    public PlantSript Plant11;
    public PlantSript Plant12;
    public PlantSript Plant13;
    public PlantSript Plant14;

    public PlantSript Plant15;
    public PlantSript Plant16;
    public PlantSript Plant17;
    public PlantSript Plant18;
    public PlantSript Plant19;
    public PlantSript Plant20;
    public PlantSript Plant21;
    
    public PlantSript Plant22;
    public PlantSript Plant23;
    public PlantSript Plant24;
    public PlantSript Plant25;
    public PlantSript Plant26;
    public PlantSript Plant27;
    public PlantSript Plant28;
    
    public PlantSript Plant29;
    public PlantSript Plant30;
    public PlantSript Plant31;
    public PlantSript Plant32;
    public PlantSript Plant33;
    public PlantSript Plant34;
    public PlantSript Plant35;
    public PlantSript Plant36;

    public Missions missions2;

    private void Update()
    {
        if (Plant1.Isplanted == true && Plant2.Isplanted == true && Plant3.Isplanted == true && Plant4.Isplanted == true && Plant5.Isplanted == true && Plant6.Isplanted == true && Plant7.Isplanted == true &&
            Plant8.Isplanted == true && Plant9.Isplanted == true && Plant10.Isplanted == true && Plant11.Isplanted == true && Plant12.Isplanted == true && Plant13.Isplanted == true && Plant14.Isplanted == true &&
            Plant15.Isplanted == true && Plant16.Isplanted == true && Plant17.Isplanted == true && Plant18.Isplanted == true && Plant19.Isplanted == true && Plant20.Isplanted == true && Plant21.Isplanted == true &&
            Plant22.Isplanted == true && Plant23.Isplanted == true && Plant24.Isplanted == true && Plant25.Isplanted == true && Plant26.Isplanted == true && Plant27.Isplanted == true && Plant28.Isplanted == true &&
            Plant29.Isplanted == true && Plant30.Isplanted == true && Plant31.Isplanted == true && Plant32.Isplanted == true && Plant33.Isplanted == true && Plant34.Isplanted == true && Plant35.Isplanted == true && Plant36.Isplanted == true)
        {
            Debug.Log("Mission 2 Completed");
            missions2.Mission2 = true;
        }
    }

}
