using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]private TMP_Text text;
    public float timeLeft = 10.0f;
    public float extraTime = 20.0f;
    public float extraTimeFromIntruders = 5.0f;
    public bool timerReachedZero = false;

    // Start is called before the first frame update
    void Start()
    {
        //text.text = "Time left: " + timeLeft.ToString();
        StartCoroutine(TimeLeft());
    }

    public void TimeFromDefeatedIntruders()
    {
        timeLeft += extraTimeFromIntruders;
    }

    public void GiveMoreTime()
    {
        timeLeft = timeLeft + extraTime;
    }

    IEnumerator TimeLeft ()
    {
        while (timeLeft >= 0.00)
        {
            text.text = "Time left: " + Math.Round(timeLeft, 2).ToString();
            yield return new WaitForSeconds(0.01f);
            timeLeft -= 0.01f;
        }
        text.text = "Time left: " + Math.Round(timeLeft, 2).ToString();
        timerReachedZero = true;
        Debug.Log("Level over");
    }


}
