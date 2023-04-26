using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopletMeter : MonoBehaviour
{
    [SerializeField]private GameController gameController;
    [SerializeField]private float defaultMoveValue = 0.4f;
    [SerializeField]private GameObject poopletMoveArea;
    [SerializeField]private LayerMask layermask;
    // [SerializeField]private Transform poopletSpawnpoint;

    // void OnDrawGizmos()
    // {
    //     // Draw a yellow sphere at the transform's position
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireCube(poopletMoveArea.transform.position, transform.localScale / 2);
    // }

    // public void MovePooplets ()
    // {
    //     GameObject[] poopletsInScene = GameObject.FindGameObjectsWithTag("Pooplet");

    //     // Collider[] hitColliders = Physics.OverlapBox(poopletMoveArea.transform.position, transform.localScale / 2, Quaternion.identity, layermask);
    //     foreach (var obj in poopletsInScene)
    //     {
    //         Vector3 newPos = new Vector3(
    //             obj.transform.position.x + defaultMoveValue, 
    //             obj.transform.position.y, 
    //             obj.transform.position.z
    //             );
    //         obj.transform.position = newPos;
    //     }
    // }
}
