using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
    [SerializeField] Transform focus;
    [SerializeField, Range(1f, 200f)] float distance = 50f;
    [SerializeField, Min(0f)] float focusRadius = 1f;
    [SerializeField] float zoomScaler = 0.1f;

    Vector3 focusPoint;
    float currentZoom = 1;

    void Awake()
    {
        focusPoint = focus.position;
    }

    void LateUpdate()
    {
        //Vector3 focusPoint = focus.position;
        UpdateFocusPoint();
        Vector3 lookDirection = transform.forward;

        currentZoom += Input.mouseScrollDelta.y * zoomScaler;
        transform.localPosition = focusPoint - lookDirection * (distance * currentZoom);
    }

    void UpdateFocusPoint()
    {
        Vector3 targetPoint = focus.position;
        if (focusRadius > 0f)
        {
            float distance = Vector3.Distance(targetPoint, focusPoint);
            if (distance > focusRadius)
            {
                focusPoint = Vector3.Lerp(
                    targetPoint, focusPoint, focusRadius / distance
                );
            }
        }
        else
        {
            focusPoint = targetPoint;
        }
    }
}
