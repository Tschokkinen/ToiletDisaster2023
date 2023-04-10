using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spider : MonoBehaviour
{
    [SerializeField]private float swingSpeed = 1.0f;
    [SerializeField]private float negativeAngleZ = -40.0f;
    [SerializeField]private float positiveAngleZ = 40.0f;
    [SerializeField]private Transform child;

    // public delegate void SpiderStatus(bool status);
    // public static SpiderStatus spiderStatus;

    public static event EventHandler<bool> spiderStatus;

    void Start()
    {
        child = this.gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        float z = Mathf.SmoothStep(negativeAngleZ, positiveAngleZ, Mathf.PingPong(swingSpeed * Time.time, 1));
        transform.rotation= Quaternion.Euler(0, 0, z);

        if (child == null)
        {
            // Debug.Log("Destroy spider");
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        spiderStatus?.Invoke(this, true);
    }

    private void OnDisable()
    {
        spiderStatus?.Invoke(this, false);
    }

}
