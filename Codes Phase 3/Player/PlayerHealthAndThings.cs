using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class PlayerHealthAndThings : MonoBehaviour
{
    public Slider healthBarSlider;

    [Header("Player Health Things")]
    private float playerHealth = 120f;
    private float presentHealth=120f;
    public AudioClip playerHurtSound;
    public AudioSource audioSource;

    public Animator PlayerAnim;

    public ThirdPersonController TPS;



    public int Money=143;

            bool k=true;




    public void GivefullHealth(float health)
    {
        healthBarSlider.maxValue = health;
        healthBarSlider.value = health;
    }

    public void SetHealth(float health)
    {
        healthBarSlider.value = health;

    }




    public void playerHitDamage(float takeDamage)
    {

        presentHealth -= takeDamage;
        SetHealth(presentHealth);
      audioSource.PlayOneShot(playerHurtSound);


        if (presentHealth <= 0 & k)
        {
            PlayerDie();
            k=false;
            audioSource.enabled=false;
        }
    }


    public void PlayerDie()
    {
        Debug.Log("Player Die");
        PlayerAnim.SetTrigger("Die");
        // Death camara will be active
        TPS.enabled=false;
  
    }
}
