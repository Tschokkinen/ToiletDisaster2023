using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private bool stopMouse;
    private int speed = 2;
    // public Transform target;
    private SpriteRenderer spriteRenderer;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        // stopMouse = false;
        // StartCoroutine(MoveToTarget());
        spriteRenderer = GetComponent<SpriteRenderer> ();

        if (transform.position.x < 1.0)
        {
            spriteRenderer.flipX = true;
            direction = Vector2.right;
        }
        else
        {
            spriteRenderer.flipX = false;
            direction = -Vector2.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    // IEnumerator MoveToTarget ()
    // {
    //     while (stopMouse == false)
    //     {
    //         transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime / speed);
    //         //time += Time.deltaTime;
    //         yield return null;
    //     }
    // }

    void OnBecameInvisible ()
    {
        Destroy(this.gameObject);
    }
}
