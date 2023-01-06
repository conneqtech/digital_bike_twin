using TMPro;
using UnityEngine;

public class SupportModeManager : MonoBehaviour
{
    public TMP_Text supportModeText;
    public TMP_Dropdown dropdown;
    public DataProvider dataProvider;

    // Start is called before the first frame update
    void Awake()
    {
        // Subscribe to event
        EventManager.supportModeEvent += OnSupportModeEvent;
    }

    void OnSupportModeEvent(int supportMode)
    {
        supportModeText.text = $"Support Mode: <b>{supportMode}</b>";
        dropdown.value = supportMode - 1;
    }

    public void SetSupportMode()
    {
        dataProvider.UpdateSupportMode(dropdown.value + 1);
    }

    private void OnDisable()
    {
        //Unsubscribe to event
        EventManager.supportModeEvent -= OnSupportModeEvent;
    }
}
