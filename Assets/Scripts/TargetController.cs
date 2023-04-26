using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetController : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    private Timer timer;
    [SerializeField] private LayerMask layermask;
    [SerializeField] private DoorKnob doorKnob;
    [SerializeField] private PoopletMeter poopletMeter;

    public static event EventHandler? MovePoopletEvent;

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }

    void Start()
    {
        timer = GameObject.Find("GameController").GetComponent<Timer>();
        Debug.Log("TargetController started");
    }

    protected virtual void MovePooplet(EventArgs e)
    {
        MovePoopletEvent?.Invoke(this, e);
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Debug.Log("Touch");
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.transform != null)
                    {
                        if (hit.collider.transform.name == "TummyTarget")
                        {
                            // Debug.Log("Hit TummyTarget");
                            // poopletMeter.MovePooplets();
                            MovePooplet(EventArgs.Empty);
                        }
                        else if (hit.collider.transform.name == "L_Foot")
                        {
                            // Debug.Log("Hit L_Foot");
                            getHits(hit.collider);
                        }
                        else if (hit.collider.transform.name == "R_Foot")
                        {
                            // Debug.Log("Hit R_Foot");
                            getHits(hit.collider);
                        }
                        else if (hit.collider.transform.name == "L_Arm")
                        {
                            // Debug.Log("Hit L_Arm");
                        }
                        else if (hit.collider.transform.name == "R_Arm")
                        {
                            // Debug.Log("Hit R_Arm");
                            doorKnob.StopAnim();
                        }
                        else if (hit.collider.transform.name == "Above")
                        {
                            // Debug.Log("Hit Above");
                            getHits(hit.collider);
                        }
                        else if (hit.collider.transform.name == "ToiletPaper")
                        {
                            // Debug.Log("Hit ToiletPaper");
                        }
                    }

                }

            }
        }
    }

    void getHits(Collider collider)
    {
        Collider[] hitColliders = Physics.OverlapSphere(collider.transform.position, 0.5f, layermask);
        foreach (var hitCollider in hitColliders)
        {
            // Debug.Log("HitCollider: " + hitCollider.gameObject.name);
            Destroy(hitCollider.gameObject);
            timer.timeLeft += 10.0f;
        }
    }

    // void OnTriggerEnter(Collider collider)
    // {
    //     Debug.Log("Collision");
    //     if (collider.gameObject.name == "Mouse")
    //     {
    //         // Debug.Log("Added Mouse to list");
    //         // Debug.Log(collider.gameObject);
    //         // enemies.Add(collider.gameObject);
    //     }
    // }

    // void OnTriggerExit(Collider collider)
    // {
    //     if (collider.gameObject.name == "Mouse")
    //     {
    //         // Debug.Log("Removed Mouse from list");
    //         // enemies.Remove(collider.gameObject);
    //     }
    // }
}
