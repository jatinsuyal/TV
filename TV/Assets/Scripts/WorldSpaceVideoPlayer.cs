using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WorldSpaceVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    void Start()
    {
        // Ensure that the VideoPlayer and AudioSource components are assigned in the Inspector
        if (videoPlayer == null || audioSource == null)
        {
            Debug.LogError("VideoPlayer or AudioSource component is not assigned!");
            return;
        }

        // Connect VideoPlayer to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        // Play the video
      //  videoPlayer.Play();
    }
}
