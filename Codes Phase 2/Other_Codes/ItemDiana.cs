using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDiana : MonoBehaviour
{
    public GameObject Axe;
    public GameObject Bow;
    public GameObject Quiver;
    public GameObject jacket;
    public GameObject shoes;
    public GameObject gloves;
    public GameObject dress;


    public void SelectAxe()
    {
        Axe.SetActive(true);
        Bow.SetActive(false);
        Quiver.SetActive(false);
        jacket.SetActive(false);
        shoes.SetActive(false);
        gloves.SetActive(false);
        //dress.SetActive(false);
    }

    public void SelectBow()
    {
        Axe.SetActive(false);
        Bow.SetActive(true);
        Quiver.SetActive(false);
        jacket.SetActive(false);
        shoes.SetActive(false);
        gloves.SetActive(false);
       // dress.SetActive(false);
    }

    public void SelectQuiver()
    {
        Axe.SetActive(false);
        Bow.SetActive(false);
        Quiver.SetActive(true);
        jacket.SetActive(false);
        shoes.SetActive(false);
        gloves.SetActive(false);
        //dress.SetActive(false);
    }   

    public void SelectJacket()
    {
        Axe.SetActive(false);
        Bow.SetActive(false);
        Quiver.SetActive(false);
        jacket.SetActive(true);
        shoes.SetActive(false);
        gloves.SetActive(false);
        //dress.SetActive(false);
    }   

    public void SelectShoes()
    {
        Axe.SetActive(false);
        Bow.SetActive(false);
        Quiver.SetActive(false);
        jacket.SetActive(false);
        shoes.SetActive(true);
        gloves.SetActive(false);
       // dress.SetActive(false);
    }

    public void SelectGloves()
    {
        Axe.SetActive(false);
        Bow.SetActive(false);
        Quiver.SetActive(false);
        jacket.SetActive(false);
        shoes.SetActive(false);
        gloves.SetActive(true);
       // dress.SetActive(false);
    }

    public void SelectDress()
    {
        Axe.SetActive(false);
        Bow.SetActive(false);
        Quiver.SetActive(false);
        jacket.SetActive(false);
        shoes.SetActive(false);
        gloves.SetActive(false);
     //   dress.SetActive(true);
    }   



}
