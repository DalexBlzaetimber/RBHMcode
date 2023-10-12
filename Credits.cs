using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public float scrollSpeed = 50.0f;  // The speed at which the credits will scroll (lower values make the credits scroll slower)
    public RectTransform creditsRectTransform;  // The RectTransform of the credits text
    public Button creditsButton;  // The button used to show/hide the credits
    public GameObject uiObject;

    private bool isScrolling = false;  // Whether or not the credits are currently scrolling
    private Vector3 initialPosition;  // The initial position of the credits text

    void Start()
    {
        // Get the initial position of the credits text
        initialPosition = creditsRectTransform.localPosition;
        uiObject.SetActive(false);

        // Add a listener to the credits button so that the credits can be shown/hidden
        creditsButton.onClick.AddListener(ToggleCredits);
    }

    void Update()
    {
        if (isScrolling)
        {
            // Scroll the credits up by the scroll speed multiplied by the delta time
            creditsRectTransform.localPosition += Vector3.up * (scrollSpeed * Time.deltaTime);

            // If the credits have scrolled past the top of the screen, reset their position to the initial position
            if (creditsRectTransform.localPosition.y >= Screen.height)
            {
                creditsRectTransform.localPosition = initialPosition;
            }
        }
    }

    void ToggleCredits()
    {
        uiObject.SetActive(!uiObject.activeSelf);
        // Toggle the isScrolling flag to start/stop the scrolling credits
        isScrolling = !isScrolling;

        // Set the credits text active if it's currently inactive, and vice versa
        creditsRectTransform.gameObject.SetActive(isScrolling);

        // If the credits are being shown and are not scrolling yet, start the scrolling
        if (isScrolling && creditsRectTransform.localPosition == initialPosition)
        {
            creditsRectTransform.localPosition = new Vector3(initialPosition.x, -Screen.height, initialPosition.z);
        }
        else if (!isScrolling)
        {
            // If the credits are being hidden, reset their position to the initial position
            creditsRectTransform.localPosition = initialPosition;
        }
    }
}
