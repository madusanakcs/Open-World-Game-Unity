using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSript : MonoBehaviour
{
    public Missions mission_;
    public GameObject plant;
    public GameObject Planttext;
    public bool Isplanted = false;
    public Animator anim;

    private void OnTriggerStay(Collider other)
    {
        if (Isplanted == false)
        {
            Planttext.SetActive(true);

            //press E to plant
            if (Input.GetKeyDown(KeyCode.E))
            {
                plant.SetActive(true);
                anim.SetTrigger("plant");
                Debug.Log("Planting..............");
                // plants scaling slowly by 5sec
                InvokeRepeating("Planting", 0, 5);

                Isplanted = true;

                // Deactivate light component in attach game object
                gameObject.GetComponent<Light>().enabled = false;


                Planttext.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Planttext.SetActive(false);
    }


    // plants scaling slowly by 5sec function
    private void Planting()
    {   // while plant scale > 1.2f plant will grow
        if (plant.transform.localScale.x < 1f)
        {   
            plant.transform.localScale += new Vector3(1f, 1f, 1f) * Time.deltaTime;
            plant.transform.position += new Vector3(0, 1f, 0) * Time.deltaTime;
        }
        else
        {
            // plant will stop growing
            CancelInvoke("Planting");
        }
    }







}
