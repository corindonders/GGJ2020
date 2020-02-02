using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV_Scale : MonoBehaviour
{
    public Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(Random.Range(0.5f, 1.6f), 1f, Random.Range(0.5f, 1.6f));
        
        this.transform.localScale = scaleChange;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
