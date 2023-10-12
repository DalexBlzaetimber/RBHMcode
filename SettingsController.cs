using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider brightnessSlider;
    public Slider volumeSlider;
    public Toggle uiToggle; // new public variable for the toggle button
    public GameObject uiObject; // new public variable for the UI to hide/show

    private void Start()
    {
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 0.5f);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);

        // add listener to toggle button
        uiToggle.onValueChanged.AddListener(ToggleUI);

        // hide the UI on start
        uiObject.SetActive(false);
    }

    public void OnBrightnessChanged()
    {
        float brightness = brightnessSlider.value;
        PlayerPrefs.SetFloat("Brightness", brightness);
        UpdateBrightness(brightness);
    }

    public void OnVolumeChanged()
    {
        float volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volume);
        UpdateVolume(volume);
    }

    private void UpdateBrightness(float brightness)
    {
        // Update game's brightness setting
        // For example:

        // update ambient light
        RenderSettings.ambientLight = new Color(brightness, brightness, brightness);

        // get the directional light
        GameObject directionalLight = GameObject.Find("Directional Light");
        if (directionalLight != null)
        {
            // update directional light's intensity
            Light lightComponent = directionalLight.GetComponent<Light>();
            lightComponent.intensity = brightness;
        }
    }

    private void UpdateVolume(float volume)
    {
        // Update game's volume setting
        // For example:
        AudioListener.volume = volume;
    }

    private void ToggleUI(bool value)
    {
        // toggle visibility of UI based on toggle button value
        uiObject.SetActive(value);
    }
}
