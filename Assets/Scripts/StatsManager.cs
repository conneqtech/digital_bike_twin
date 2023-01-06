using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public TMP_Text speedText;
    public TMP_Text odometerText;
    public TMP_Text rangeText;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to events
        EventManager.speedEvent += OnSpeedEvent;
        EventManager.odometerEvent += OnOdometerEvent;
        EventManager.rangeEvent += OnRangeEvent;
    }

    void OnSpeedEvent(int speed)
    {
        speedText.text = $"{speed}km/h";
    }

    void OnOdometerEvent(int distance)
    {
        odometerText.text = $"{distance}km";
    }

    void OnRangeEvent(int range)
    {
        rangeText.text = $"{range}km";
    }

    private void OnDisable()
    {
        //Unsubscribe to events
        EventManager.speedEvent -= OnSpeedEvent;
        EventManager.odometerEvent += OnOdometerEvent;
        EventManager.rangeEvent += OnRangeEvent;
    }
}
