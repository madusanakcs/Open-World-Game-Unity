using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using StarterAssets;
 
public class MaleeScript : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnim;

    //Blocking Parameters
    public bool isBlocking;

    //Kick Parameters
    public bool isKicking;

    //Attack Parameters
    public bool isAttacking;
    private float timeSinceAttack;
    public int currentAttack = 0;

    //Audio
    public AudioSource audioSource;
    public AudioClip AttackSound;
    public AudioClip playerattakSound;
    public AudioClip HitAttackSound;
    public AudioClip hitkickSound;


    private void Update()
    {
        timeSinceAttack += Time.deltaTime;

        Attack();
        Block();
        Kick();
    }

    private void Block()
    {
        if (Input.GetKey(KeyCode.LeftShift) && playerAnim.GetBool("Grounded"))
        {
            playerAnim.SetBool("Block", true);
            isBlocking = true;
        }
        else
        {
            playerAnim.SetBool("Block", false);
            isBlocking = false;
        }
    }


    public void Kick()
    {
        if (Input.GetKey(KeyCode.LeftControl) && playerAnim.GetBool("Grounded"))
        {
            playerAnim.SetBool("Kick", true);
            isKicking = true;

            // play playerattak sound
            audioSource.PlayOneShot(playerattakSound);
        }
        else
        {
            playerAnim.SetBool("Kick", false);
            isKicking = false;
        }

    }

    private void Attack()
    {

        if (Input.GetMouseButtonDown(0) && playerAnim.GetBool("Grounded") && timeSinceAttack > 0.8f)
        {




            currentAttack++;
            isAttacking = true;

            if (currentAttack > 3)
                currentAttack = 1;

            //Reset
            if (timeSinceAttack > 1.7f)
                currentAttack = 1;

            //Call Attack Triggers
            playerAnim.SetTrigger("MaleeAttack" + currentAttack);

            // play attack sound
            audioSource.PlayOneShot(AttackSound);
            audioSource.PlayOneShot(playerattakSound);

            //Reset Timer
            timeSinceAttack = 0;
        }

    }

    private void OnTriggerStay(Collider other)
    {   Debug.Log("Collided");
        if  (Input.GetMouseButtonDown(0) && playerAnim.GetBool("Grounded") && timeSinceAttack > 0.8f && other.gameObject.CompareTag("Wolf"))
        {
            Debug.Log("Wolf Hit");
            other.gameObject.GetComponent<wolf>().TakeDamage(5);
            audioSource.PlayOneShot(HitAttackSound);
        }

        // same as deer

        if (Input.GetMouseButtonDown(0) && playerAnim.GetBool("Grounded") && timeSinceAttack > 0.8f && other.gameObject.CompareTag("Deer"))
        {
            Debug.Log("Deer Hit");
            other.gameObject.GetComponent<animal_deer>().Die(20);
            audioSource.PlayOneShot(HitAttackSound);
        }

        if (Input.GetKey(KeyCode.LeftControl) && playerAnim.GetBool("Grounded") && other.gameObject.CompareTag("Wolf"))
        {
            Debug.Log("Wolf Hit");
            other.gameObject.GetComponent<wolf>().TakeDamage(5);
            audioSource.PlayOneShot(hitkickSound);
        }

        if (Input.GetKey(KeyCode.LeftControl) && playerAnim.GetBool("Grounded") && other.gameObject.CompareTag("Deer"))
        {
            Debug.Log("Deer Hit");
            other.gameObject.GetComponent<animal_deer>().Die(10);
            audioSource.PlayOneShot(hitkickSound);
        }
    }



}
