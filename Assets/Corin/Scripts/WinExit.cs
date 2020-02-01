﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinExit : MonoBehaviour
{   
    public GameObject WinScreen;
    public GameObject MainUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.name == "ThirdPersonController")
        {
            //Output the message
            WinScreen.SetActive(true);
            MainUI.SetActive(false);
        }

    }

}
