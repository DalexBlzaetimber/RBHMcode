using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIShowHide : MonoBehaviour
{
    public GameObject uiObject;

    void Start()
    {
        // Hide the UI on start
        uiObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        // Toggle visibility of UI
        uiObject.SetActive(!uiObject.activeSelf);
    }
}