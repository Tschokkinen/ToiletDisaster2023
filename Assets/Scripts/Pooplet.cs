using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooplet : MonoBehaviour
{
    // Rigidbody rb;

    // void Start ()
    // {
    //     rb = GetComponent<Rigidbody>();
    // }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PoopletEnd")
        {
            Destroy(this.gameObject);
        }

        // if (collider.gameObject.name == "DropPooplet")
        // {
        //     rb.useGravity = true;
        //     rb.constraints = RigidbodyConstraints.FreezePositionX;
        // }
    }
}
