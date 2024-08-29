using UnityEngine;

public class CarEnter : MonoBehaviour
{
    public MonoBehaviour CarController;
    public MonoBehaviour CarCamController;
    public MonoBehaviour CarAudioController;
    public GameObject Player;
    public Transform Car;
    public GameObject DriveText;
    public LayerMask PlayerLayer;
    bool carDriving = false;
    bool driving;
    public Camera PlayerCamera;
    public Camera CarCamera;
    public GameObject RealCarCam;
    public GameObject FrontCam;
    public AudioSource audioSource;
    public GameObject CarSpeedText;
    public GameObject Smoke;

    void Start()
    {
        CarController.enabled = false;
        CarCamController.enabled = false;
        CarAudioController.enabled = false;


        DriveText.SetActive(false);
        PlayerCamera.enabled = true;
        CarCamera.enabled = false;
        RealCarCam.SetActive(false);
        FrontCam.SetActive(false);

        audioSource.enabled = false;
        CarSpeedText.SetActive(false);
        Smoke.SetActive(false);

    
    }
    void Update()
    {
        if (carDriving && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player entered car");
            DriveText.SetActive(false);
            driving = true;
           Player.transform.parent = Car.transform;

            Player.SetActive(false);
            PlayerCamera.enabled = false;
            CarCamera.enabled = true;
            RealCarCam.SetActive(true);
            FrontCam.SetActive(true);

            CarController.enabled = true;
            CarCamController.enabled = true;
            CarAudioController.enabled = true;

            audioSource.enabled = true;
            CarSpeedText.SetActive(true);
            Smoke.SetActive(true);



        }
        if (driving && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Player exited car");
            driving = false;
            Player.SetActive(true);
            Player.transform.parent = null;
            PlayerCamera.enabled = true;
            CarCamera.enabled = false;
            RealCarCam.SetActive(false);
            FrontCam.SetActive(false);
            CarController.enabled = false;
            CarCamController.enabled = false;
            CarAudioController.enabled = false;
            audioSource.enabled = false;
            CarSpeedText.SetActive(false);
            Smoke.SetActive(false);
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger area");
            DriveText.SetActive(true);
            carDriving = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger area");
            DriveText.SetActive(false);
            carDriving = false;
        }
    }
}
