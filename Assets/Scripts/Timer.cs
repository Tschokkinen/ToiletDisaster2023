using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]private TMP_Text timerText;
    public float timeLeft = 10.0f;
    public float extraTime = 20.0f;
    public float extraTimeFromIntruders = 5.0f;
    public bool timerReachedZero = false;

    public static event EventHandler<bool> timerStatus;

    // Start is called before the first frame update
    void Start()
    {
        //text.text = "Time left: " + timeLeft.ToString();
        timerStatus?.Invoke(this, true);
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
            timerText.text = "Time left: " + Math.Round(timeLeft, 2).ToString();
            yield return new WaitForSeconds(0.01f);
            timeLeft -= 0.01f;
        }
        timerText.text = "Time left: " + Math.Round(timeLeft, 2).ToString();
        timerReachedZero = true;
        timerStatus?.Invoke(this, false);
        Debug.Log("Level over");
    }


}
