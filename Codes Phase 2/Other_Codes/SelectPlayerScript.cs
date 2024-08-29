using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerScript : MonoBehaviour
{
    [Header("Player  ")]
    public GameObject Jane;
    public GameObject Edward;
    public GameObject item;


    [Header("Player Pannel")]
    public GameObject PlayerPannelJane;
    public GameObject PlayerPannelEdward;
    public GameObject itemPannel;

    [Header("Player Selection")]
    public GameObject JaneButton;
    public GameObject EdwardButton;
    public GameObject itemButton;


    [Header("Menu")]
    public GameObject Game;

    public void SelectJane()
    {
        Jane.SetActive(true);
        Edward.SetActive(false);
        item.SetActive(false);

        PlayerPannelJane.SetActive(true);
        PlayerPannelEdward.SetActive(false);
        itemPannel.SetActive(false);

    }

    public void SelectEdward()
    {
        Jane.SetActive(false);
        Edward.SetActive(true);
        item.SetActive(false);

        PlayerPannelJane.SetActive(false);
        PlayerPannelEdward.SetActive(true);
        itemPannel.SetActive(false);


    }

    public void SelectItem()
    {
        Jane.SetActive(false);
        Edward.SetActive(false);
        item.SetActive(true);

        PlayerPannelJane.SetActive(false);
        PlayerPannelEdward.SetActive(false);
        itemPannel.SetActive(true);

    }
    
    

     
      public void OnJaneButtonClick()
    {
        SelectJane();
    }

    public void OnEdwardButtonClick()
    {
        SelectEdward();
    }

    public void OnItemButtonClick()
    {
        SelectItem();
    }

    public void Start()
    {
        SelectJane();
    }
}
