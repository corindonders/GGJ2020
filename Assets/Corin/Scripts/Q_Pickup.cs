using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Q_Pickup : MonoBehaviour
{
    public GameObject Parent;
    public GameObject PlayerGrab;
    public GameObject WorldQuest;
    public GameObject MoveTargets;
    public bool PlayerInside;
    public bool PickedUp;
    public int WeightMulti = 1;

    // Start is called before the first frame update
    void Start()
    {
                Parent = this.transform.parent.gameObject;
                PlayerGrab = GameObject.Find("PlayerGrab");
                WorldQuest = GameObject.Find("[ Quests ]");
    }
    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Fire3")){
            if (PlayerInside == true && PickedUp == false){
                Parent.transform.SetParent(PlayerGrab.transform);
                Parent.transform.localPosition = Vector3.zero;                
                PickedUp=true;
                MoveTargets.SetActive(true);

            }else{
                Parent.transform.SetParent(WorldQuest.transform);
                PickedUp=false;
                MoveTargets.SetActive(false);

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