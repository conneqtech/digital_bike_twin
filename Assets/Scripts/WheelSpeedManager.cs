using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelSpeedManager : MonoBehaviour
{
    public TMP_Text wheelSpeedText;
    public GameObject[] wheels;

    int wheelSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to event
        EventManager.wheelSpeedEvent += OnWheelSpeedEvent;
    }

    void OnWheelSpeedEvent(int speed)
    {
        wheelSpeed = speed;
        wheelSpeedText.text = $"Wheel Speed: <b>{speed}</b><size=70%>rpm</size>";
   
    }

    private void Update()
    {
        if (wheelSpeed < 1)
        {
            return;
        }

        foreach (GameObject wheel in wheels)
        {
            wheel.transform.Rotate(Vector3.forward, wheelSpeed * 6f * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        //Unsubscribe to event
        EventManager.wheelSpeedEvent -= OnWheelSpeedEvent;
    }
}
