using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerAuthentication2 : MonoBehaviour
{
    public TokenData tokenData; // Reference to TokenData ScriptableObject

    private CentralAPIHandler centralAPIHandler;

    private void Start()
    {
        centralAPIHandler = GetComponent<CentralAPIHandler>(); // Get CentralAPIHandler component
    }

    public void OnPlayButton()
    {
        StartCoroutine(AuthenticateUser());
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
            SceneManager.LoadScene(1); // Load main menu scene
        }
        else
        {
            Debug.Log("Authentication failed. Token is empty.");
            // Handle authentication failure
        }
    }
}
