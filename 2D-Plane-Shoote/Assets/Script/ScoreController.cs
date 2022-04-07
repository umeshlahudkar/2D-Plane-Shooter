using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        //scoreText = GetComponent<TextMeshProUGUI>();
        score = 0;
        scoreDisplay();
    }

    public void ScoreIncrement()
    {
        score = score + 1;
        scoreDisplay();
    }

    public void scoreDisplay()
    {
        scoreText.text = "SCORE : " + score;
    }
}
