using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakInfo : MonoBehaviour
{
    public bool broken;

    public GameObject brokenObject;
    public GameObject untouchedObject;

    public bool Break()
    {
        if (broken)
            return false;

        broken = true;

        updateMesh(broken);

        return true;
    }

    public bool Repair()
    {
        if (broken)
            return false;

        broken = false;

        updateMesh(broken);

        return true;
    }

    private void updateMesh(bool broken)
    {
        untouchedObject.SetActive(!broken);
        brokenObject.SetActive(broken);
    }
}
