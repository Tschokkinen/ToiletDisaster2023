using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorKnob : MonoBehaviour
{
    private Animator anim;

    // public delegate void DoorKnobStatus(bool status);
    // public static DoorKnobStatus doorKnobStatus;
    public static event EventHandler<bool> doorKnobStatus;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartAnim()
    {
        anim.SetBool("MoveDoorKnob", true);
        doorKnobStatus?.Invoke(this, true);
    }

    public void StopAnim()
    {
        anim.SetBool("MoveDoorKnob", false);
        doorKnobStatus?.Invoke(this, false);
    }
    
}
