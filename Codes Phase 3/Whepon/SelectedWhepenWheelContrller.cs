using UnityEngine;
using UnityEngine.UI;


namespace StarterAssets
{
    public class SelectedWhepenWheelContrller : MonoBehaviour
    {
        public Animator anim;
        public Animator PlayerAnim;
        private bool WeaponSelected = false;
        public Image SelectItem;
        public Sprite NoImage;
        public static int WeaponID;

        public StarterAssets.ThirdPersonController thirdPersonController;

        public GameObject Pistol;
        public GameObject Rifle;
        public GameObject Axe;
        public GameObject Bow;
        public GameObject Quiver;
        public GameObject hand;

        public int SelectedWeaponID;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {   // peuse the game

                WeaponSelected = !WeaponSelected;

                Cursor.visible = WeaponSelected; // Show or hide the mouse cursor
                Cursor.lockState = WeaponSelected ? CursorLockMode.None : CursorLockMode.Locked; // Unlock or lock the cursor
            }

            if (WeaponSelected)
            {
                anim.SetBool("OpenWeaponWheel", true);


                switch (WeaponID)
                {
                    case 0: // Hand 
                        SelectedWeaponID=0;
                        Debug.Log("Hand Selected");
                        Pistol.SetActive(false);
                        Rifle.SetActive(false);
                        Axe.SetActive(false);
                        Bow.SetActive(false);
                        Quiver.SetActive(false);
                        hand.SetActive(true);

                        thirdPersonController.MoveSpeed = 2f;
                        thirdPersonController.SprintSpeed = 5.335f;

                        PlayerAnim.SetBool("BowIdle", false);
                        PlayerAnim.SetBool("rifleIdle", false);
                        PlayerAnim.SetBool("PistolIdle", false);
                        PlayerAnim.SetBool("AxeIdle", false);
                        PlayerAnim.SetBool("HandIdle", true);
                        break;

                    case 1: // Pistol
                        SelectedWeaponID=1;
                        Debug.Log("Pistol Selected");
                        Pistol.SetActive(true);
                        Rifle.SetActive(false);
                        Axe.SetActive(false);
                        Bow.SetActive(false);
                        Quiver.SetActive(false);
                        hand.SetActive(false);

                        thirdPersonController.MoveSpeed = 2f;
                        thirdPersonController.SprintSpeed = 5.335f;

                        PlayerAnim.SetBool("BowIdle", false);
                        PlayerAnim.SetBool("rifleIdle", false);
                        PlayerAnim.SetBool("PistolIdle", true);
                        PlayerAnim.SetBool("AxeIdle", false);
                        PlayerAnim.SetBool("HandIdle", false);
                        break;

                    case 2: // Rifle
                        SelectedWeaponID=2;
                        Debug.Log("Rifle Selected");
                        Pistol.SetActive(false);
                        Rifle.SetActive(true);
                        Axe.SetActive(false);
                        Bow.SetActive(false);
                        Quiver.SetActive(false);
                        hand.SetActive(false);


                        thirdPersonController.MoveSpeed = 1.5f;
                        thirdPersonController.SprintSpeed = 3.5f;

                        PlayerAnim.SetBool("rifleIdle", true);
                        PlayerAnim.SetBool("BowIdle", false);
                        PlayerAnim.SetBool("PistolIdle", false);
                        PlayerAnim.SetBool("AxeIdle", false);
                        PlayerAnim.SetBool("HandIdle", false);
                        break;

                    case 3: // Axe
                        SelectedWeaponID=3;
                        Debug.Log("Axe Selected");
                        Pistol.SetActive(false);
                        Rifle.SetActive(false);
                        Axe.SetActive(true);
                        Bow.SetActive(false);
                        Quiver.SetActive(false);
                        hand.SetActive(false);

                        thirdPersonController.MoveSpeed = 2f;
                        thirdPersonController.SprintSpeed = 5.335f;

                        PlayerAnim.SetBool("BowIdle", false);
                        PlayerAnim.SetBool("rifleIdle", false);
                        PlayerAnim.SetBool("PistolIdle", false);
                        PlayerAnim.SetBool("AxeIdle", true);
                        PlayerAnim.SetBool("HandIdle", false);
                        break;

                    case 4: // bow
                        SelectedWeaponID=4;
                        Debug.Log("Bow Selected");
                        Pistol.SetActive(false);
                        Rifle.SetActive(false);
                        Axe.SetActive(false);
                        Bow.SetActive(true);
                        Quiver.SetActive(true);
                        hand.SetActive(false);

                        thirdPersonController.MoveSpeed = 2f;
                        thirdPersonController.SprintSpeed = 5.335f;

                        PlayerAnim.SetBool("BowIdle", true);
                        PlayerAnim.SetBool("rifleIdle", false);
                        PlayerAnim.SetBool("PistolIdle", false);
                        PlayerAnim.SetBool("AxeIdle", false);
                        PlayerAnim.SetBool("HandIdle", false);
                        break;

                    case 5: // Lamp
                        SelectedWeaponID=5;
                        Debug.Log("Lamp Selected");

                        thirdPersonController.MoveSpeed = 2f;
                        thirdPersonController.SprintSpeed = 5.335f;

                        break;


                }

            }
            else
            {
                anim.SetBool("OpenWeaponWheel", false);
            }
        }
    }

}