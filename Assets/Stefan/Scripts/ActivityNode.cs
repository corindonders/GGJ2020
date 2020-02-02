using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ActivityNode : MonoBehaviour
{
}

public class ActivityNodeGizmo
{
    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawGizmoForMyScript(ActivityNode scr, GizmoType gizmoType)
    {
        Vector3 position = scr.transform.position;

        if (Vector3.Distance(position, Camera.current.transform.position) > 1f)
            Gizmos.DrawCube(position, new Vector3(.1f,.1f,.1f));
    }
}
