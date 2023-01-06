using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphManager : MonoBehaviour
{
    public enum GraphType
    {
        battery,
        wheel,
        pedal,
    }

    public TMP_Text title;
    public Window_Graph graphContainer;
    public BikeData bikeData;
    GraphType? selectedGraphType;
    GameObject camera;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void OpenGraph(GraphType type)
    {
        if (selectedGraphType != null)
        {
            UnSubscribe();
        }

        selectedGraphType = type;

        switch (type)
        {
            case GraphType.battery:
                title.text = "Battery Percentage";

                EventManager.batteryPercentageEvent += OnBatteryPercentageEvent;
                graphContainer.UpdateGraph(bikeData.batteryPercentageList, "%");
                break;
            case GraphType.wheel:
                title.text = "Wheel Speed";

                EventManager.wheelSpeedEvent += OnWheelSpeedEvent;
                graphContainer.UpdateGraph(bikeData.wheelSpeedList, "rpm");
                break;
            case GraphType.pedal:
                title.text = "Pedal Speed";

                EventManager.pedalSpeedEvent += OnPedalSpeedEvent;
                graphContainer.UpdateGraph(bikeData.pedalSpeedList, "rpm");
                break;
        }

        graphContainer.gameObject.SetActive(true);
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), 290f, .5f).setEaseInOutCubic();
        LeanTween.moveY(camera, -3.5f, .5f).setEaseInOutCubic();
        LeanTween.moveZ(camera, -14, .5f).setEaseInOutCubic();
    }

    public void CloseGraph()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), -290f, .5f).setEaseInOutCubic().setOnComplete(DisableGraph);
        LeanTween.moveY(camera, 0, .5f).setEaseInOutCubic();
        LeanTween.moveZ(camera, -8, .5f).setEaseInOutCubic();
    }

    void DisableGraph()
    {
        UnSubscribe();

        selectedGraphType = null;

        graphContainer.gameObject.SetActive(false);
    }

    void UnSubscribe()
    {
        switch (selectedGraphType)
        {
            case GraphType.battery:
                EventManager.batteryPercentageEvent -= OnBatteryPercentageEvent;
                break;
            case GraphType.wheel:
                EventManager.wheelSpeedEvent -= OnWheelSpeedEvent;
                break;
            case GraphType.pedal:
                EventManager.pedalSpeedEvent -= OnPedalSpeedEvent;
                break;
        }
    }

    void OnBatteryPercentageEvent(int percentage)
    {
        graphContainer.UpdateGraph(bikeData.batteryPercentageList, "%");
    }

    void OnWheelSpeedEvent(int speed)
    {
        graphContainer.UpdateGraph(bikeData.wheelSpeedList, "rpm");
    }

    void OnPedalSpeedEvent(int speed)
    {
        graphContainer.UpdateGraph(bikeData.pedalSpeedList, "rpm");
    }
}
