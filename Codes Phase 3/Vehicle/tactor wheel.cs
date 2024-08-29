using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tactorwheel : MonoBehaviour
{

     
    public Animator animator;
    public Animator animatorback;

    void Start()
    {
        animator.SetBool("idle", true);
        animatorback.SetBool("idle", true);
    }


    void Update()
    {
        // Check for player input and trigger animations accordingly
        if (Input.GetKey(KeyCode.W)) // Press W for forward movement
        {
            animator.SetBool("isMovingForward", true);
            animator.SetBool("idle", false);
            animatorback.SetBool("isMovingForward", true);
            animatorback.SetBool("idle", false);
        }
        else
        {
            animator.SetBool("isMovingForward", false);
            animator.SetBool("idle", true);
            animatorback.SetBool("isMovingForward", false);
            animatorback.SetBool("idle", true);
            
        }

        if (Input.GetKey(KeyCode.S)) // Press S for backward movement
        {
            animator.SetBool("isMovingBackward", true);
            animator.SetBool("idle", false);
            animatorback.SetBool("isMovingBackward", true);
            animatorback.SetBool("idle", false);
        }
        else
        {
            animator.SetBool("isMovingBackward", false);
            animator.SetBool("idle", true);
            animatorback.SetBool("isMovingBackward", false);
            animatorback.SetBool("idle", true);
        }

        if (Input.GetKey(KeyCode.A)) // Press A for left movement
        {
            animator.SetBool("isMovingLeft", true);
            animator.SetBool("idle", false);
        }
        else
        {
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("idle", true);
        }

        if (Input.GetKey(KeyCode.D)) // Press D for right movement
        {
            animator.SetBool("isMovingRight", true);
            animator.SetBool("idle", false);
        }
        else
        {
            animator.SetBool("isMovingRight", false);
            animator.SetBool("idle", true);
        }
    }


}
