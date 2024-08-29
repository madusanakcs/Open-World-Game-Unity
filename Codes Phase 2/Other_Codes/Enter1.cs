using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enter : MonoBehaviour
{
    // if press enter deactivete canvas

    // public GameObject canvas1;
    // // public text(legasy) text1;
    // public GameObject text1;
    // public GameObject text2;
    // public GameObject canvas2;
    public TokenData tokenData; // Reference to TokenData ScriptableObject

    private CentralAPIHandler centralAPIHandler;

    private void Start()
    {
        centralAPIHandler = GetComponent<CentralAPIHandler>(); // Get CentralAPIHandler component
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(AuthenticateUser());
            

        }
    }
    private IEnumerator AuthenticateUser()
    {
        if (centralAPIHandler == null)
    {
        Debug.LogError("CentralAPIHandler is not attached.");
        yield break;
    }

    yield return StartCoroutine(centralAPIHandler.GetToken());

    if (tokenData == null)
    {
        Debug.LogError("TokenData is not assigned.");
        yield break;
    }

        string token = tokenData.token; // Get token from TokenData

        if (!string.IsNullOrEmpty(token))
        {
            Debug.Log("Authentication successful. Token: " + token);
            yield return null;
            SceneManager.LoadScene("Demo1"); // Load main menu scene
        }
        else
        {
            Debug.Log("Authentication failed. Token is empty.");
            // Handle authentication failure
        }
    }

}
