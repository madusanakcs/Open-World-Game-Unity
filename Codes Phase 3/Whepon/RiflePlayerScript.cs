using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("RifleWalk", true);
        }
        else
        {
            anim.SetBool("RifleWalk", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("RifleRun", true);
        }
        else
        {
            anim.SetBool("RifleRun", false);
        }
    }
}
