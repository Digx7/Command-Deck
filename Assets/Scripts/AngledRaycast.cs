using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngledRaycast : MonoBehaviour
{
    public Vector2 pivotPoint;
    public float range;
    public float angle;
    private Vector2 startPoint;

    private void Awake()
    {
        pivotPoint = Vector2.zero;
        startPoint = Vector2.zero;
    }

    public Ray2D RaycastAtAngle(float angle)
    {
        startPoint = (Vector2)transform.position + pivotPoint;
        Vector2 direction = GetDirectionVector2D(angle);
        return new Ray2D(startPoint, direction);
    }

    public Vector2 GetDirectionVector2D(float angle)
    {
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
    }
}
