using UnityEngine;

public class LightsManager : MonoBehaviour
{
    public bool isToggledOn = false;

    public GameObject[] onObjects;
    public GameObject[] offObjects;
    public DataProvider dataProvider;

    private void Awake()
    {
        //Subscribe to event
        EventManager.lightOnEvent += OnLightOnEvent;
    }

    void OnLightOnEvent(bool isOn)
    {
        isToggledOn = isOn;
        SetLights(isOn);
    }

    public void ToggleLights()
    {
        isToggledOn = !isToggledOn;
        dataProvider.UpdateLightOn(isToggledOn);
    }

    void SetLights(bool isOn)
    {
        foreach (GameObject obj in onObjects)
        {
            obj.SetActive(isOn);
        }

        foreach (GameObject obj in offObjects)
        {
            obj.SetActive(!isOn);
        }
    }

    private void OnDisable()
    {
        //Unsubscribe to event
        EventManager.lightOnEvent -= OnLightOnEvent;
    }
}
