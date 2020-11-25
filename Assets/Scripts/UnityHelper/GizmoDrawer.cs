using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawer : MonoBehaviour
{
   public enum GizmoShape
    {
        WireSphere = 0,
        Sphere = 1,
        Cube,
        WireCube
    }

    public enum GizmoColor
    {
        Blue,
        Cyan,
        Green,
        Magenta,
        Red,
        White,
        Yellow
    }

    public bool showGizmo;
    public GizmoShape shape;
    public GizmoColor color;
    public float radius;
    public Vector3 scale;

    private void OnDrawGizmos()
    {
        if (!showGizmo)
        {
            return;
        }

        switch (color)
        {
            case GizmoColor.Blue:
                Gizmos.color = Color.blue;
                break;
            case GizmoColor.Cyan:
                Gizmos.color = Color.cyan;
                break;
            case GizmoColor.Green:
                Gizmos.color = Color.green;
                break;
            case GizmoColor.Magenta:
                Gizmos.color = Color.magenta;
                break;
            case GizmoColor.Red:
                Gizmos.color = Color.red;
                break;
            case GizmoColor.White:
                Gizmos.color = Color.white;
                break;
            case GizmoColor.Yellow:
                Gizmos.color = Color.yellow;
                break;
            default:
                Gizmos.color = Color.white;
                break;
        }

        switch (shape)
        {
            case GizmoShape.WireSphere:
                Gizmos.DrawWireSphere(transform.localPosition, radius);
                break;
            case GizmoShape.Sphere:
                Gizmos.DrawSphere(transform.localPosition, radius);
                break;
            case GizmoShape.Cube:
                Gizmos.DrawCube(transform.localPosition, scale);
                break;
            case GizmoShape.WireCube:
                Gizmos.DrawWireCube(transform.localPosition, scale);
                break;
            default:
                break;
        }
    }
}
