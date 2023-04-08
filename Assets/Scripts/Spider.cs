using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    GameController gameController;

    [SerializeField]private float swingSpeed = 1.0f;
    [SerializeField]private float negativeAngleZ = -40.0f;
    [SerializeField]private float positiveAngleZ = 40.0f;
    [SerializeField]private Transform child;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        child = this.gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        float z = Mathf.SmoothStep(negativeAngleZ, positiveAngleZ, Mathf.PingPong(swingSpeed * Time.time, 1));
        transform.rotation= Quaternion.Euler(0, 0, z);

        if (child == null)
        {
            Debug.Log("Destroy spider");

            // Replace changing spiderActive with an event later.
            gameController.spiderActive = false;
            Destroy(this.gameObject);
        }
    }

}
