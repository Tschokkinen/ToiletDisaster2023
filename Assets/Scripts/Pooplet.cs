using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pooplet : MonoBehaviour
{
    // Rigidbody rb;

    public static event EventHandler<int> poopletPoints;

    void Start ()
    {
        // rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PoopletEnd")
        {
            poopletPoints?.Invoke(this, 1);
            Destroy(this.gameObject);
        }

        // if (collider.gameObject.name == "DropPooplet")
        // {
        //     rb.useGravity = true;
        //     rb.constraints = RigidbodyConstraints.FreezePositionX;
        // }
    }
}
