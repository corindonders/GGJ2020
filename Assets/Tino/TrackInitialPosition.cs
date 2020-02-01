using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackInitialPosition : MonoBehaviour
{
    public Vector3 initialPosition;
    public float margin;

    void Start()
    {
        initialPosition = gameObject.transform.position;
    }
}
