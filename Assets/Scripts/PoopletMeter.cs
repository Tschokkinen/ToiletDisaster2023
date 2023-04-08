using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopletMeter : MonoBehaviour
{
    [SerializeField]private float defaultMoveValue = 0.4f;

    public void MovePooplets ()
    {
        GameObject[] poopletsInScene = GameObject.FindGameObjectsWithTag("Pooplet");

        foreach (var obj in poopletsInScene)
        {
            Vector3 newPos = new Vector3(obj.transform.position.x + defaultMoveValue, obj.transform.position.y + defaultMoveValue, obj.transform.position.z);
            obj.transform.position = newPos;
        }
    }
}
