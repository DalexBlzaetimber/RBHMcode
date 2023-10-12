using UnityEngine;
using UnityEngine.UI;

public class SocialMediaLinks : MonoBehaviour
{
    public Button youtubeButton;
    public Button twitterButton;
    public Button facebookButton;

    private string youtubeLink = "https://www.youtube.com/@SwordDoveGamingProductions/about";
    private string twitterLink = "https://twitter.com/DoveSword";
    private string facebookLink = "https://www.facebook.com/SworddoveGaming";

    private void Start()
    {
        youtubeButton.onClick.AddListener(OpenYouTubeLink);
        twitterButton.onClick.AddListener(OpenTwitterLink);
        facebookButton.onClick.AddListener(OpenFacebookLink);
    }

    private void OpenYouTubeLink()
    {
        Application.OpenURL(youtubeLink);
    }

    private void OpenTwitterLink()
    {
        Application.OpenURL(twitterLink);
    }

    private void OpenFacebookLink()
    {
        Application.OpenURL(facebookLink);
    }
}
