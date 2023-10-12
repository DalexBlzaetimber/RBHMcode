using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoClip[] videos; // an array of VideoClips to play
    public int videosPerLevel = 4; // number of videos to play per level
    public int currentLevel = 0; // current level index
    public VideoPlayer videoPlayer; // reference to the VideoPlayer component

    private int currentVideoIndex = 0; // current video index
    private int videosPlayedInCurrentLevel = 0; // number of videos played in current level

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished; // subscribe to the loopPointReached event
        PlayNextVideo(); // start playing the first video
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        videosPlayedInCurrentLevel++;

        // check if we've played all the videos for this level
        if (videosPlayedInCurrentLevel >= videosPerLevel)
        {
            // move to the next level
            currentLevel++;
            videosPlayedInCurrentLevel = 1;

            // check if we've played all the levels
            if (currentLevel >= Mathf.CeilToInt((float)videos.Length / videosPerLevel))
            {
                currentLevel = 0; // start over
            }

            // set the current video index to the first video in the new level
            currentVideoIndex = currentLevel * videosPerLevel;
        }

        PlayNextVideo();
    }

    private void PlayNextVideo()
    {
        // check if we've played all the videos
        if (currentVideoIndex >= videos.Length)
        {
            currentVideoIndex = 0; // start over
        }

        videoPlayer.clip = videos[currentVideoIndex];
        videoPlayer.Play();

        currentVideoIndex++;
    }
}
