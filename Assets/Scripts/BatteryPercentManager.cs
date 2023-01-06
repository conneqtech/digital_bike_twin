using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryPercentManager : MonoBehaviour
{
    public TMP_Text percentageText;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to event
        EventManager.batteryPercentageEvent += OnBatteryPercentageEvent;
    }

    void OnBatteryPercentageEvent(int percentage)
    {
        string colour = GetBatteryPercentageColour(percentage);
        percentageText.text = $"Battery: <b><color=\"{colour}\">{percentage}%</b>";
    }

    string GetBatteryPercentageColour(int percentage)
    {
        if (percentage < 25)
            return "red";
        else if (percentage >= 25 && percentage < 50)
            return "orange";
        else if (percentage >= 50 && percentage < 75)
            return "yellow";
        else
            return "green";
    }

    private void OnDisable()
    {
        //Unsubscribe to event
        EventManager.batteryPercentageEvent -= OnBatteryPercentageEvent;
    }
}
