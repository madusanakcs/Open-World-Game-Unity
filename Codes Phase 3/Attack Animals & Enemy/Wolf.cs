using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace StarterAssets
{
    public class wolf : MonoBehaviour
    {
        private int HP = 100;
        public Animator animator;
        public Slider healthbar;
        public PlayerHealthAndThings playerHealthAndThings;

        public bool wolfDie = false;


        [Header("Audio")]
        public AudioSource audioSource1;
        public AudioClip WolfAttackSound;
        public AudioClip wolfHurtsound;
        public AudioClip wolfDieSound;
        public AudioClip wolfHowlSound;

        private void Update()
        {
            healthbar.value = HP;
            // if animatar isAttac is true then player health will be decrease



        }

        // check every 2 second function animator isAttac is true play sound
        private IEnumerator CheckAnimatorState()
        {
            while (true)
            {
                if (animator.GetBool("isAttac") | animator.GetBool("isAttac2") & animator.GetBool("DIE")==false )
                {
                    audioSource1.PlayOneShot(WolfAttackSound);
                }

                if (animator.GetBool("isSit") & animator.GetBool("isAttac")==false & animator.GetBool("isAttac2")==false)
                {
                    audioSource1.PlayOneShot(wolfHowlSound);
                }

                yield return new WaitForSeconds(3f);
            }
        }





        private void Start()
        {
            StartCoroutine(UpdateHealth());
            StartCoroutine(CheckAnimatorState());
        }

        // update is called every 3 second
        IEnumerator UpdateHealth()
        {
            while (true)
            {
                if (animator.GetBool("isAttac") && HP > 0)
                {
                    playerHealthAndThings.playerHitDamage(10f);
                    Debug.Log("Player Health Decrease");
                }
                else
                {
                    Debug.Log("Player Health Not Decrease");
                }

                yield return new WaitForSeconds(2f);
            }
        }






        public void TakeDamage(int damageAmount)
        {
            HP -= damageAmount;
            audioSource1.PlayOneShot(wolfHurtsound);

            if (HP <= 0)
            {
                //play death animation
                //animator.SetTrigger("die");
                animator.SetBool("DIE", true);
                animator.SetBool("isWalk", false);
                animator.SetBool("isRun", false);
                animator.SetBool("isAttc", false);
                animator.SetBool("isAttac2", false);
                animator.SetBool("isSit", false);
                GetComponent<Collider>().enabled = false;
                audioSource1.PlayOneShot(wolfDieSound);
                wolfDie = true;

                // Rigid body desabled
                GetComponent<Rigidbody>().isKinematic = true;

            }
            else
            {
                //play hit animation
                animator.SetTrigger("damage");

            }
        }
    }
}