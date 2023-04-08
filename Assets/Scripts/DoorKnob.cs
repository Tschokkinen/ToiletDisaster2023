using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnob : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartAnim()
    {
        anim.SetBool("MoveDoorKnob", true);
    }

    public void StopAnim()
    {
        anim.SetBool("MoveDoorKnob", false);
    }
    
}
