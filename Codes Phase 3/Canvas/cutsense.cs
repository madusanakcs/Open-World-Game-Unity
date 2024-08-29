using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class cutsense : MonoBehaviour
{
    public GameObject cutsceneObject; // The GameObject that represents your cutscene
    public GameObject player; // The player GameObject
    private PlayerInput playerMovement; // Assuming your player has a PlayerMovement script
    public float cutsceneDuration = 5f; // Duration of the cutscene in seconds
    public GameObject AimCamera;
    public GameObject MainCamera;
    public GameObject Axe;

    public Missions mission;

    private void Start()
    {
        cutsceneObject.SetActive(false); // Make sure the cutscene is initially inactive
        playerMovement = player.GetComponent<PlayerInput>(); // Get the PlayerMovement component
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assumes the player has the tag "Player"
        {
            StartCoroutine(PlayCutscene());
                    MainCamera.SetActive(false);
        }
    }

    private IEnumerator PlayCutscene()
    {
        cutsceneObject.SetActive(true); // Activate the cutscene GameObject
        playerMovement.enabled = false; // Disable player movement
        AimCamera.SetActive(false);
        MainCamera.SetActive(false);
        Axe.SetActive(true);

        Debug.Log("Cutscene is playing!");

        // Wait for the duration of the cutscene
        yield return new WaitForSeconds(cutsceneDuration);

        // Deactivate the cutscene GameObject and re-enable player movement
        EndCutscene();
    }

    private void EndCutscene()
    {
        cutsceneObject.SetActive(false); // Deactivate the cutscene GameObject
        playerMovement.enabled = true; // Re-enable player movement
        MainCamera.SetActive(true);
        Axe.SetActive(false);
        Debug.Log("Cutscene has ended.");
        mission.Mission5 = true;


    }
}
