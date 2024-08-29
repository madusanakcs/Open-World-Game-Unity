using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StarterAssets;

public class handScript : MonoBehaviour
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

    [Header("Audio")]
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
            playerAnim.SetBool("HandBlock", true);
            isBlocking = true;
        }
        else
        {
            playerAnim.SetBool("HandBlock", false);
            isBlocking = false;
        }
    }


    public void Kick()
    {
        if (Input.GetKey(KeyCode.LeftControl) && playerAnim.GetBool("Grounded"))
        {
            playerAnim.SetBool("HandKick", true);
            isKicking = true;
            audioSource.PlayOneShot(playerattakSound);
        }
        else
        {
            playerAnim.SetBool("HandKick", false);
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
            playerAnim.SetTrigger("HandAttack" + currentAttack);
            audioSource.PlayOneShot(AttackSound);

            //Reset Timer
            timeSinceAttack = 0;
        }

    }


    // Attack wolf and deer Same as malee script

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Collided");
        if (Input.GetMouseButtonDown(0) && playerAnim.GetBool("Grounded") && timeSinceAttack > 0.8f && other.gameObject.CompareTag("Wolf"))
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

        // same as kick

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
