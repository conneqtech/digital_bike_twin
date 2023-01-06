using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProvider : MonoBehaviour
{
    public BikeData bikeData;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.UpdateBatteryPercentageEvent(bikeData.currentBatteryPercentage);
        EventManager.UpdateWheelSpeedEvent(bikeData.currentWheelSpeed);
        EventManager.UpdatePedalSpeedEvent(bikeData.currentPedalSpeed);
        EventManager.UpdateSupportModeEvent(bikeData.currentSupportMode);
        EventManager.UpdateSpeedEvent(bikeData.currentSpeed);
        EventManager.UpdateOdometerEvent(bikeData.currentOdometer);
        EventManager.UpdateRangeEvent(bikeData.currentRange);
        EventManager.UpdateLightOnEvent(bikeData.lightOn);

        StartCoroutine(InvokeEverySecond());
    }

    IEnumerator InvokeEverySecond()
    {
        while (true)
        {
            UpdateBatteryPercentage();
            UpdateWheelSpeed();
            UpdatePedalSpeed();
            UpdateSpeed();
            UpdateOdometer();
            UpdateRange();

            yield return new WaitForSeconds(1);
        }
    }

    void UpdateBatteryPercentage()
    {
        if (bikeData.currentBatteryPercentage < 1)
        {
            bikeData.SetBatteryPercentage(100);
        }
        else
        {
            bikeData.SetBatteryPercentage(bikeData.currentBatteryPercentage - 1);
        }

        EventManager.UpdateBatteryPercentageEvent(bikeData.currentBatteryPercentage);
    }

    void UpdateWheelSpeed()
    {
        int range = 30;
        int min = bikeData.currentWheelSpeed - range >= 0
            ? bikeData.currentWheelSpeed - range
            : 0;
        int max = bikeData.currentWheelSpeed + range <= 500
            ? bikeData.currentWheelSpeed + range
            : 500;
        bikeData.SetWheelSpeed(Random.Range(min, max));

        EventManager.UpdateWheelSpeedEvent(bikeData.currentWheelSpeed);
    }

    void UpdatePedalSpeed()
    {
        int range = 20;
        int min = bikeData.currentPedalSpeed - range >= 0
            ? bikeData.currentPedalSpeed - range
            : 0;
        int max = bikeData.currentPedalSpeed + range <= 500
            ? bikeData.currentPedalSpeed + range
            : 500;
        bikeData.SetPedalSpeed(Random.Range(min, max));

        EventManager.UpdatePedalSpeedEvent(bikeData.currentPedalSpeed);
    }

    public void UpdateSupportMode(int mode)
    {
        bikeData.SetSupportMode(mode);
        EventManager.UpdateSupportModeEvent(bikeData.currentSupportMode);
    }

    public void UpdateSpeed()
    {
        bikeData.SetSpeed((int)(bikeData.currentWheelSpeed * .13f));
        EventManager.UpdateSpeedEvent(bikeData.currentSpeed);
    }

    public void UpdateOdometer()
    {
        bikeData.SetOdometer(bikeData.currentOdometer + 1);
        EventManager.UpdateOdometerEvent(bikeData.currentOdometer);
    }

    public void UpdateRange()
    {
        bikeData.SetRange((int)(36f / 100f * bikeData.currentBatteryPercentage));
        EventManager.UpdateRangeEvent(bikeData.currentRange);
    }

    public void UpdateLightOn(bool isOn)
    {
        bikeData.lightOn = isOn;
        EventManager.UpdateLightOnEvent(bikeData.lightOn);
    }
}
