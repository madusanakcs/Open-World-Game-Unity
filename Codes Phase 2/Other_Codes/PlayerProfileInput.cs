using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerProfileInput : MonoBehaviour
{
    private string input;
    public string FirstName;
    public string LastName;
    public string Email;
    public string MobileNum;
    public string UserName;
 
    public string NIC;

    [Header("Warning Text")]
    public Text InvalidFirstNameWarning;
    public Text InvalidLastNameWarning;
    public Text InvalidEmailWarning;
    public Text InvalidMobileNumWarning;
    public Text InvalidUserNameWarning; 
    public Text InvalidNICWarning;




    [Header("Edit Information")]
    public InputField FirstNameInput;
    public InputField LastNameInput;
    public InputField EmailInput;
    public InputField MobileNumInput;
    public InputField UserNameInput;
    public InputField NICInput;

    [Header("Show Text")]
    public GameObject FirstNameText;
    public GameObject LastNameText;
    public GameObject EmailText;
    public GameObject MobileNumText;
    public GameObject UserNameText;
    public GameObject NICText;




    private PlayerProfile playerprofile;

    public void Start()
    {
        playerprofile = GetComponent<PlayerProfile>();
    }

    public void EditFirstName()
    {
        FirstNameInput.gameObject.SetActive(true);

    }
    
    public void EditLastName()
    {
        LastNameInput.gameObject.SetActive(true);
    }

    public void EditEmail()
    {
        EmailInput.gameObject.SetActive(true);
    }

    public void EditMobileNum()
    {
        MobileNumInput.gameObject.SetActive(true);
    }

    public void EditUserName()
    {
        UserNameInput.gameObject.SetActive(true);
    }

    public void EditNIC()
    {
        NICInput.gameObject.SetActive(true);
    }

















    public void NIC1(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            Debug.LogWarning("NIC input cannot be empty.");
           
            InvalidNICWarning.text = "NIC Number cannot be empty.";
            NIC =null;

            return;
        }

        if (!long.TryParse(s, out _))
        {
            Debug.LogWarning("Invalid NIC input. NIC number must be a valid number.");
            InvalidNICWarning.text = "NIC Number must be a valid number.";
            NIC = null;
            return;
        }


        NIC = s;
        playerprofile.UpdatePlayerProfile("nic", NIC);
        Debug.Log("NIC: " + NIC);
        NICText.GetComponent<TMP_Text>().text = NIC;
        InvalidNICWarning.text = "";
        NICInput.gameObject.SetActive(false);

    }

    public void FirstName1(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            Debug.LogWarning("First Name input cannot be empty.");
            InvalidFirstNameWarning.text = "First Name cannot be empty.";
            FirstName = null;
            return;
        }
 
        FirstName = s;
        playerprofile.UpdatePlayerProfile("firstname", FirstName);
        Debug.Log("First Name: " + FirstName);
        FirstNameText.GetComponent<TMP_Text>().text = FirstName;
        InvalidFirstNameWarning.text = "";
         FirstNameInput.gameObject.SetActive(false);

    }

    public void LastName1(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            Debug.LogWarning("Last Name input cannot be empty.");
           InvalidLastNameWarning.text = "Last Name cannot be empty.";
           LastName = null;
            return;
        }
 

        LastName = s;
        playerprofile.UpdatePlayerProfile("lastname", LastName);
        Debug.Log("Last Name: " + LastName);
        LastNameText.GetComponent<TMP_Text>().text = LastName;
        InvalidLastNameWarning.text = "";
        LastNameInput.gameObject.SetActive(false);
    }

    public void Email1(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            Debug.LogWarning("Email input cannot be empty.");
            InvalidEmailWarning.text = "Email cannot be empty.";
            Email = null;
            return;
        }
 

        Email = s;
        playerprofile.UpdatePlayerProfile("email", Email);
        Debug.Log("Email: " + Email);
        EmailText.GetComponent<TMP_Text>().text = Email;
        InvalidEmailWarning.text = "";
        EmailInput.gameObject.SetActive(false);
    }

    public void MobileNum1(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            Debug.LogWarning("Mobile Number input cannot be empty.");
            InvalidMobileNumWarning.text = "Mobile Number cannot be empty.";
            MobileNum = null;
            return;
        }
 
        if (!int.TryParse(s, out _))
        {
            Debug.LogWarning("Invalid Mobile Number input. Mobile number must be a valid number.");
            InvalidMobileNumWarning.text = "Mobile Number must be a valid number.";
            MobileNum = null;
            return;
        }

        MobileNum = s;
        playerprofile.UpdatePlayerProfile("phoneNumber", MobileNum);
        Debug.Log("Mobile Number: " + MobileNum);
        MobileNumText.GetComponent<TMP_Text>().text = MobileNum;
        InvalidMobileNumWarning.text = "";
        MobileNumInput.gameObject.SetActive(false);
    }

    public void UserName1(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            Debug.LogWarning("User Name input cannot be empty.");
            InvalidUserNameWarning.text = "User Name cannot be empty.";
            UserName = null;
            return;
        }

 

        UserName = s;
        //playerManager.UpdatePlayerData("username", UserName);
        Debug.Log("User Name: " + UserName);
        UserNameText.GetComponent<TMP_Text>().text = UserName;
        InvalidUserNameWarning.text = "";
        UserNameInput.gameObject.SetActive(false);
    }

 
}
