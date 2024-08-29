using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManu : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject PlayMenu;
    public GameObject PlayerMenu;

    public void MenuActivete()
    {   
        MainMenu.SetActive(false);
        PlayerMenu.SetActive(true);
        PlayMenu.SetActive(false);
        Debug.Log("Menu Activated");
    }


    public void ReturnToMainMENU()
    {
        MainMenu.SetActive(true);
        PlayerMenu.SetActive(false);
        PlayMenu.SetActive(false);
        Debug.Log("Return to Main Menu");
    }
}
