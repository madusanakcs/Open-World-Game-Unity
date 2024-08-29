using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WARNING : MonoBehaviour
{                                       //This handles the main warning 
                                        // Player profile incomplete warning and quiz is not answered warning
    public Canvas QuizAnswerwarning;
    public Canvas CompleteProfileWarning;
    public bool QuizAnswered;
    public bool ProfileCompleted;
    private PlayerProfile playerprofile;
    private PlayerManager playerManager;
    public ProfileStatus profileStatus;

    private void OnProfileCompleted(bool isProfileCompleted)
{
    ProfileCompleted = isProfileCompleted;
}

private void Start()
{
    
    GameObject obj = GameObject.Find("FETCH");
    playerprofile = obj.GetComponent<PlayerProfile>();
    playerManager = obj.GetComponent<PlayerManager>();

    StartCoroutine(InitializeVariables());
}

IEnumerator InitializeVariables()
{
    yield return playerprofile.GetIsProfileCompleted((result) => 
    {
        ProfileCompleted = result;
        profileStatus.IsProfileCompleted = result;
        Debug.Log("ProfileComplete: " + ProfileCompleted);
    });
    playerManager.LoadData();
    QuizAnswered = playerManager.GetIsQuizAnswered();
    Debug.Log("Running warning script");
    Debug.Log("QuizAnswered: " + QuizAnswered);
}


    public void QuizWarningOn()
    {   
        if (!QuizAnswered && ProfileCompleted)
        {
            QuizAnswerwarning.gameObject.SetActive(true);
            // after 5 seconds the warning will disappear
            Invoke("WarningOffQuiz", 5);
        }

    }

    public void ProfileWarningOn()
    {
        if (!ProfileCompleted)
        {
            CompleteProfileWarning.gameObject.SetActive(true);
            // after 5 seconds the warning will disappear
            Invoke("WarningOffProfile", 5);
        }
    }

    private void WarningOffQuiz()
    {
        QuizAnswerwarning.gameObject.SetActive(false);
    }

    private void WarningOffProfile()
    {
        CompleteProfileWarning.gameObject.SetActive(false);
    }

}
