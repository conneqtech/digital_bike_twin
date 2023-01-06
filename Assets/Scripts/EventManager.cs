using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action<int> batteryPercentageEvent;
    public static event Action<int> wheelSpeedEvent;
    public static event Action<int> pedalSpeedEvent;
    public static event Action<int> supportModeEvent;

    public static event Action<int> speedEvent;
    public static event Action<int> odometerEvent;
    public static event Action<int> rangeEvent;

    public static event Action<bool> lightOnEvent;


    public static void UpdateBatteryPercentageEvent(int percentage)
    {
        batteryPercentageEvent?.Invoke(percentage);
    }

    public static void UpdateWheelSpeedEvent(int speed)
    {
        wheelSpeedEvent?.Invoke(speed);
    }

    public static void UpdatePedalSpeedEvent(int speed)
    {
        pedalSpeedEvent?.Invoke(speed);
    }

    public static void UpdateSupportModeEvent(int mode)
    {
        supportModeEvent?.Invoke(mode);
    }

    public static void UpdateSpeedEvent(int speed)
    {
        speedEvent?.Invoke(speed);
    }

    public static void UpdateOdometerEvent(int distance)
    {
        odometerEvent?.Invoke(distance);
    }

    public static void UpdateRangeEvent(int range)
    {
        rangeEvent?.Invoke(range);
    }

    public static void UpdateLightOnEvent(bool isOn)
    {
        lightOnEvent?.Invoke(isOn);
    }
}
