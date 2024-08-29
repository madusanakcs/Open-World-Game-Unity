using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemJane : MonoBehaviour
{
    public GameObject Axe;
    public GameObject Bow;
    public GameObject Quiver;


    public void SelectAxe()
    {
        Axe.SetActive(true);
        Bow.SetActive(false);
        Quiver.SetActive(false);
    }

    public void SelectBow()
    {
        Axe.SetActive(false);
        Bow.SetActive(true);
        Quiver.SetActive(false);
    }

    public void SelectQuiver()
    {
        Axe.SetActive(false);
        Bow.SetActive(false);
        Quiver.SetActive(true);
    }
    
}
