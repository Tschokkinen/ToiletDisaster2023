using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    [SerializeField]private TMP_Text pointsText;
    [SerializeField]private int totalPoints;

    void Start()
    {
        totalPoints = 0;
        pointsText.text = totalPoints.ToString();
        Pooplet.poopletPoints += UpdatePoints;
    }

    public void UpdatePoints (object sender, int points) 
    {
        totalPoints += points;
        pointsText.text = totalPoints.ToString();
    }
}


