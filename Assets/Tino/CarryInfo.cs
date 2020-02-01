using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryInfo : MonoBehaviour
{
    public bool pickedUp;

    public GameObject originalParent;
    public GameObject carryParent;

    public bool PickUp(GameObject carryParent)
    { // Maybe transform to a slight offset from the player
        if (pickedUp && this.carryParent == carryParent)
            return false;

        gameObject.transform.SetParent(carryParent.transform);
        this.carryParent = carryParent;

        pickedUp = true;

        return true;
    }

    public bool Drop()
    {
        if (!pickedUp && this.carryParent != null)
            return false;

        gameObject.transform.SetParent(originalParent.transform, true);
        carryParent = null;

        pickedUp = false;

        return true;
    }
}
