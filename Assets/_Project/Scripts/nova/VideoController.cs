using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    // s[SerializeField] string videoURL; // e.g. "https://www.example.com/demo.mp4"
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        //videoPlayer.source = VideoSource.Url;
        //videoPlayer.url = videoURL;
        //videoPlayer.isLooping = true;

        //videoPlayer.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (videoPlayer.isPlaying)
                videoPlayer.Pause();
            else
                videoPlayer.Play();
        }
    }
}
