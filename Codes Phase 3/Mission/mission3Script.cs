using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission3Script : MonoBehaviour
{

    // 36 Mud there
    public MudScript Mud1;
    public MudScript Mud2;
    public MudScript Mud3;
    public MudScript Mud4;
    public MudScript Mud5;
    public MudScript Mud6;
    public MudScript Mud7;

    public MudScript Mud8;
    public MudScript Mud9;
    public MudScript Mud10;
    public MudScript Mud11;
    public MudScript Mud12;
    public MudScript Mud13;
    public MudScript Mud14;

    public MudScript Mud15;
    public MudScript Mud16;
    public MudScript Mud17;
    public MudScript Mud18;
    public MudScript Mud19;
    public MudScript Mud20;
    public MudScript Mud21;
    
    public MudScript Mud22;
    public MudScript Mud23;
    public MudScript Mud24;
    public MudScript Mud25;
    public MudScript Mud26;
    public MudScript Mud27;
    public MudScript Mud28;
    
    public MudScript Mud29;
    public MudScript Mud30;
    public MudScript Mud31;
    public MudScript Mud32;
    public MudScript Mud33;
    public MudScript Mud34;
    public MudScript Mud35;
    public MudScript Mud36;

    public bool MudOK = false;

    private void Update()
    {
        if (Mud1.mudisSet == true && Mud2.mudisSet == true && Mud3.mudisSet == true && Mud4.mudisSet == true && Mud5.mudisSet == true && Mud6.mudisSet == true && Mud7.mudisSet == true &&
            Mud8.mudisSet == true && Mud9.mudisSet == true && Mud10.mudisSet == true && Mud11.mudisSet == true && Mud12.mudisSet == true && Mud13.mudisSet == true && Mud14.mudisSet == true &&
            Mud15.mudisSet == true && Mud16.mudisSet == true && Mud17.mudisSet == true && Mud18.mudisSet == true && Mud19.mudisSet == true && Mud20.mudisSet == true && Mud21.mudisSet == true &&
            Mud22.mudisSet == true && Mud23.mudisSet == true && Mud24.mudisSet == true && Mud25.mudisSet == true && Mud26.mudisSet == true && Mud27.mudisSet == true && Mud28.mudisSet == true &&
            Mud29.mudisSet == true && Mud30.mudisSet == true && Mud31.mudisSet == true && Mud32.mudisSet == true && Mud33.mudisSet == true && Mud34.mudisSet == true && Mud35.mudisSet == true && Mud36.mudisSet == true)
        {
            Debug.Log("Mission 3 Completed");
            MudOK = true;
        }
    }

}
