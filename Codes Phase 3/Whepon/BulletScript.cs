using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private  Rigidbody bulletRigidbody;

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        float Speed = 60f;
        bulletRigidbody.velocity = transform.forward * Speed;
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
