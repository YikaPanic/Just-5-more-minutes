using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private float score;

    void Start()
    {
        score = 0;
        UpdateScoreDisplay();
    }

    public void IncreaseScore(float amount)
    {
        score += amount;
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }
}
