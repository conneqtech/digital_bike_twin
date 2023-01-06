using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BikeData : ScriptableObject
{
    public int currentBatteryPercentage;
    public int currentWheelSpeed;
    public int currentPedalSpeed;
    public int currentSupportMode;

    public int currentSpeed;
    public int currentOdometer;
    public int currentRange;

    public bool lightOn;

    public List<int> batteryPercentageList;
    public List<int> wheelSpeedList;
    public List<int> pedalSpeedList;

    public void SetBatteryPercentage(int percentage)
    {
        if (percentage > 100)
        {
            currentBatteryPercentage = 100;
            AddToList(batteryPercentageList, currentBatteryPercentage);
            return;
        }

        if (percentage < 0)
        {
            currentBatteryPercentage = 0;
            AddToList(batteryPercentageList, currentBatteryPercentage);
            return;
        }

        currentBatteryPercentage = percentage;
        AddToList(batteryPercentageList, currentBatteryPercentage);
    }

    public void SetWheelSpeed(int speed)
    {
        if (speed > 500)
        {
            currentWheelSpeed = 500;
            AddToList(wheelSpeedList, currentWheelSpeed);
            return;
        }

        if (speed < 0)
        {
            currentWheelSpeed = 0;
            AddToList(wheelSpeedList, currentWheelSpeed);
            return;
        }

        currentWheelSpeed = speed;
        AddToList(wheelSpeedList, currentWheelSpeed);
    }

    public void SetPedalSpeed(int speed)
    {
        if (speed > 500)
        {
            currentPedalSpeed = 500;
            AddToList(pedalSpeedList, currentPedalSpeed);
            return;
        }

        if (speed < 0)
        {
            currentPedalSpeed = 0;
            AddToList(pedalSpeedList, currentPedalSpeed);
            return;
        }

        currentPedalSpeed = speed;
        AddToList(pedalSpeedList, currentPedalSpeed);
    }

    public void SetSupportMode(int mode)
    {
        if (mode > 6)
        {
            currentSupportMode = 6;
            return;
        }

        if (mode < 0)
        {
            currentSupportMode = 0;
            return;
        }

        currentSupportMode = mode;
    }

    public void SetSpeed(int speed)
    {
        currentSpeed = speed;
    }

    public void SetOdometer(int distance)
    {
        currentOdometer = distance;
    }

    public void SetRange(int range)
    {
        currentRange = range;
    }

    public void SetLightOn(bool isOn)
    {
        lightOn = isOn;
    }

    void AddToList(List<int> list, int item)
    {
        if (list.Count >= 60)
        {
            list.RemoveAt(0);
        }
        list.Add(item);
    }
}
