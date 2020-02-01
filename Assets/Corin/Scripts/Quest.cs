using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject Target;
    public GameObject VFX;
    public GameObject UI;
    private GameObject ScoreController;

    //public string Name;
    //public string Action;
    public enum Actions{ ShitOn, Move, Breaks }
    public Actions actions;
    //public string description
    public int scoreValue;
    public bool completed = false;


    // Start is called before the first frame update
    void Start()
    {
        ScoreController = GameObject.Find("@ Score Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuestSucces(){
        if (completed == false) {
        completed = true;

        VFX.SetActive(true);
        UI.SetActive(false);
        
        ScoreController.GetComponent<Score>().AddScore (scoreValue);

        }
    }
}
