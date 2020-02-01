using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI  scoreText;
    private int score;
    public int Tasks;
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
        scoreText.text = "" + score + "/"  + Tasks + "Tasks completed" ;

        if (score == Tasks) {
            Debug.Log("You Win");
        }

    }
}
