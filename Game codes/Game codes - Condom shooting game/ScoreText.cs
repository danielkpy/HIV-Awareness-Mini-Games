using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text score;
    public static int scoreValue = 0;
    

    void Update()
    {
        score.text = "SCORE: " + scoreValue.ToString();
    }
}
