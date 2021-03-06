﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI  scoreText;
    private int score;
    public int Tasks;
    public GameObject Exit;
    // Start is called before the first frame update
    void Start()
    {           
        Tasks = GameObject.FindGameObjectsWithTag("Quest").Length;
        score = 0;
        UpdateScore ();
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        scoreText.text = "" + score + "/"  + Tasks + " tasks completed" ;

        if (score == Tasks) {
            scoreText.text = "You completed all your tasks. Go to the exit!!!" ;
            Exit.SetActive(true);
        }

    }
}
