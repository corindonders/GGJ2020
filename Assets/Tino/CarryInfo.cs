using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CarryInfo : MonoBehaviour
{
    // This should be placed on a gameobject that can be picked up
    public bool pickedUp;

    public float carryOffsetUp;
    public float carryOffsetForward;

    public GameObject originalParent;
    private GameObject carryParent;

    public bool PickUp(GameObject carryParent)
    {
        if (pickedUp && this.carryParent == carryParent)
            return false;

        Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();

        if (rigidBody != null)
            rigidBody.isKinematic = true;

        gameObject.transform.SetParent(carryParent.transform);

        gameObject.transform.localPosition = (Vector3.forward * carryOffsetUp) + (Vector3.up * carryOffsetForward);

        this.carryParent = carryParent;

        pickedUp = true;

        return true;
    }

    public bool Drop()
    {
        if (!pickedUp && this.carryParent != null)
            return false;

        Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();

        if (rigidBody != null)
            rigidBody.isKinematic = false;

        gameObject.transform.SetParent(originalParent.transform, true);
        carryParent = null;

        pickedUp = false;

        return true;
    }
}
