using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public GameObject Emoji_Pouting;
    public GameObject Emoji_Serious;
    public GameObject Emoji_Wrench;
    public GameObject Emoji_Exclamation;
    public GameObject Emoji_Broom;
    private Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Emoji_Pouting.transform.LookAt(camera);
        Emoji_Serious.transform.LookAt(camera);
        Emoji_Wrench.transform.LookAt(camera);
        Emoji_Exclamation.transform.LookAt(camera);
        Emoji_Broom.transform.LookAt(camera);
    }

    void OnTriggerEnter(Collider Other){
        if(Other.gameObject.name == "ThirdPersonController"){
            //Get the Renderer component from the new cube
            var cubeRenderer = this.GetComponent<Renderer>();
       
            //Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", new Color(1f, 0f, 0f, 0.3f));
            Emoji_Exclamation.SetActive(true);
        }
        if(Other.gameObject.name == "Shit(Clone)"){
            Debug.Log("I see poop");
            Emoji_Serious.SetActive(true);
        }
        if(Other.gameObject.name == "Broken"){
            Debug.Log("This Is broken");
            Emoji_Wrench.SetActive(true);

        }
    }

    void OnTriggerExit(Collider Other){
        if(Other.gameObject.name == "ThirdPersonController"){
            //Get the Renderer component from the new cube
            var cubeRenderer = this.GetComponent<Renderer>();
            //Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", new Color(0f, 0f, 0f, 0.15f));
            Emoji_Exclamation.SetActive(false);
        }
        if(Other.gameObject.name == "Shit(Clone)"){
            Emoji_Serious.SetActive(false);

        }

        if(Other.gameObject.name == "Broken"){
            Emoji_Wrench.SetActive(false);
        }

    }


}
