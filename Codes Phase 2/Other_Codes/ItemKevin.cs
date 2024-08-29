using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKevin : MonoBehaviour
{
    public GameObject Axe;
    public GameObject Bow;
    public GameObject Quiver;
    public GameObject Sunglass;
    public GameObject Baret;

    public void SelectSunglass()
    {
        Axe.SetActive(false);
        Bow.SetActive(false);
        Quiver.SetActive(false);
        Sunglass.SetActive(true);
        Baret.SetActive(false);
    }

    public void SelectBaret()
    {
        Axe.SetActive(false);
        Bow.SetActive(false);
        Quiver.SetActive(false);
        Sunglass.SetActive(false);
        Baret.SetActive(true);
    }

    public void SelectAxe()
    {
        Axe.SetActive(true);
        Bow.SetActive(false);
        Quiver.SetActive(false);
        Sunglass.SetActive(false);
        Baret.SetActive(false);
    }

    public void SelectBow()
    {
        Axe.SetActive(false);
        Bow.SetActive(true);
        Quiver.SetActive(false);
        Sunglass.SetActive(false);
        Baret.SetActive(false);
    }   

    public void SelectQuiver()
    {
        Axe.SetActive(false);
        Bow.SetActive(false);
        Quiver.SetActive(true);
        Sunglass.SetActive(false);
        Baret.SetActive(false);
    }

    
}
