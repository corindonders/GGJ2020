using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Q_Kick : MonoBehaviour
{
    public GameObject Parent;
    public GameObject Object;
    public int chargeCounter01 = 0;
    public bool PlayerInside;
    // Start is called before the first frame update
    void Start()
    {
                Parent = this.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButton("Fire3")){
            if (PlayerInside == true){
                chargeCounter01++;
                if(chargeCounter01 >= 100){
                    Object.name = "Broken";
                    Parent.GetComponent<Quest>().QuestSucces();
                }
            }
        } 
    }

    void OnTriggerEnter(Collider Other){
        if(Other.gameObject.name == "ThirdPersonController"){
            PlayerInside= true;
        }
    }

     void OnTriggerExit(Collider Other){
        if(Other.gameObject.name == "ThirdPersonController"){
            PlayerInside= false;     
        }
    }


}
