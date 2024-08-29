using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudScript : MonoBehaviour
{
    public GameObject mud;
        public bool mudisSet = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tactor")
        {
            mud.SetActive(true);

            mudisSet = true;
        }
    }
}
