using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float sceneWidth;
    Vector3 pressPoint;
    Quaternion startRotation;

    private void Start()
    {
        sceneWidth = Screen.width;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressPoint = Input.mousePosition;
            startRotation = transform.rotation;
        }
        else if (Input.GetMouseButton(0)) {
            float currentDistanceBetweenMousePositions = (Input.mousePosition - pressPoint).x;
            transform.rotation = startRotation * Quaternion.Euler(Vector3.down * (currentDistanceBetweenMousePositions / sceneWidth) * 360);
        }
    }
}
