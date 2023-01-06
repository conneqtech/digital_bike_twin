using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixToAnchor : MonoBehaviour
{
    public Transform anchorPoint;

    private void Update()
    {
        transform.position = anchorPoint.position;
    }
}
