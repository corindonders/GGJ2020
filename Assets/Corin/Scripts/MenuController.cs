using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string Levelname;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Fire1") || CrossPlatformInputManager.GetButtonDown("Fire2") || CrossPlatformInputManager.GetButtonDown("Fire3")){
            SceneManager.LoadScene(Levelname, LoadSceneMode.Single);
        } 
    }

}
