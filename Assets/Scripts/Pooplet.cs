using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pooplet : MonoBehaviour
{
    // Rigidbody rb;
    [SerializeField] private float defaultMoveValue = 0.4f;

    public static event EventHandler<int> poopletPoints;

    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        TargetController.MovePoopletEvent += MovePooplet;
    }

    void OnDisable()
    {
        TargetController.MovePoopletEvent -= MovePooplet;
    }

    public void MovePooplet(object sender, EventArgs e)
    {
        Vector3 newPos = new Vector3(
                        gameObject.transform.position.x + defaultMoveValue,
                        gameObject.transform.position.y,
                        gameObject.transform.position.z
                        );
        gameObject.transform.position = newPos;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "PoopletDrop")
        {
            TargetController.MovePoopletEvent -= MovePooplet;
        }
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
