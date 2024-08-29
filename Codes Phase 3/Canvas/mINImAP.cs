using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mINImAP : MonoBehaviour
{   
    public GameObject minimap;
    // IF press m key minimap will be active
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            minimap.gameObject.SetActive(!minimap.gameObject.activeSelf);
        }
    } 
}
