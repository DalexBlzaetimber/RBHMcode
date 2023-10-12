using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public GameObject settingsUI;
    public Button settingsButton;
    private PauseButton pauseButton;

    private void Start()
    {
        // hide the settings UI on start
        settingsUI.SetActive(false);

        // add listener to settings button
        settingsButton.onClick.AddListener(ToggleSettingsUI);
    }

    void ToggleSettingsUI()
    {
        Time.timeScale = 0f;
        // toggle visibility of settings UI only when timescale is 0
        if (Time.timeScale == 0)
        {
            settingsUI.SetActive(!settingsUI.activeSelf);
        }
    }

    private void Update()
    {
        // hide the settings UI when timescale is 1
        if (Time.timeScale == 1)
        {
            settingsUI.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        ToggleSettingsUI();
    }
}
