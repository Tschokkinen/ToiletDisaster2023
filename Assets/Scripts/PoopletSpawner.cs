using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopletSpawner : MonoBehaviour
{
    [SerializeField]private GameController gameController;

    // void OnTriggerEnter(Collider collider)
    // {
    //     if (collider.gameObject.tag == "Pooplet")
    //     {
    //         gameController.poopletStillOnEnterPoint = true;
    //     }
    // }

    // void OnTriggerExit(Collider collider)
    // {
    //     if (collider.gameObject.tag == "Pooplet")
    //     {
    //         gameController.poopletStillOnEnterPoint = false;
    //     }
    // }
}
