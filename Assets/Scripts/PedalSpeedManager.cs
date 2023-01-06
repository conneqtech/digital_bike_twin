using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PedalSpeedManager : MonoBehaviour
{
    public TMP_Text pedalSpeedText;

    public Transform pedals;
    int pedalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to event
        EventManager.pedalSpeedEvent += OnPedalSpeedEvent;
    }

    void OnPedalSpeedEvent(int speed)
    {
        pedalSpeed = speed;
        pedalSpeedText.text = $"Pedal Speed: <b>{speed}</b><size=70%>rpm</size>";
    }

    private void Update()
    {
        if (pedalSpeed < 1)
        {
            return;
        }

        pedals.Rotate(Vector3.forward, pedalSpeed * 6f * Time.deltaTime);
    }

    private void OnDisable()
    {
        //Unsubscribe to event
        EventManager.pedalSpeedEvent -= OnPedalSpeedEvent;
    }
}
