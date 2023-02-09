using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Text pointsText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject arrow;
    private int oldHighScore;
    private int highScore;
    private int score = 0;
    private readonly int coinValue = 1;
    
    /// <summary>
    /// Points counter.
    /// </summary>
    private void Start()
    {
        AddListeners();
        highScore = PlayerPrefs.GetInt("highScore", 0);
        oldHighScore = highScore;
    }
    private void FixedUpdate()
    {
        pointsText.text = score.ToString();
            if(highScore < score)
            {
                highScore = score;
                PlayerPrefs.SetInt("highScore", score);
            }
    }
    private void AddListeners()
    {
        ActionContainer.OnCoinTriggerEnter += () => score += coinValue;
        ActionContainer.OnRestart += Restart;
        ActionContainer.OnHit += ResultShow;
    }
    private void ResultShow()
    {
        panel.SetActive(true);
        if (score>oldHighScore)
        {
            arrow.SetActive(true);
            scoreText.text = $"Score:{score.ToString()}";
            highScoreText.text = $"New Highscore:{highScore.ToString()}";
        }
        else
        {
            scoreText.text = $"Score:{score.ToString()}";
            highScoreText.text = $"Highscore:{highScore.ToString()}";
        }
    }

    private void Restart()
    {
        score = 0;
        panel.SetActive(false);
        arrow.SetActive(false);
    }
}
