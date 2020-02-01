using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_ColliderCheck : MonoBehaviour
{
    public GameObject Parent;

    // Start is called before the first frame update
    void Start()
    {
        
        Parent = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.name == "Shit(Clone)")
        {
            //Output the message
            Debug.Log("I Pooped on the desk");
            Parent.GetComponent<Quest>().QuestSucces();
        }

    }


}
