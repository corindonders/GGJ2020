using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackInitialPosition : MonoBehaviour
{
    // This should be placed on a gameobject that needs to have a reference to check if it has momved
    public Vector3 initialPosition;
    public float margin;

    void Start()
    {
        initialPosition = gameObject.transform.position;
    }
}
