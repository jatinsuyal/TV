using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;

public class VideoManager : MonoBehaviour
{
    public VideoClip[] videos;
    public Slider progressSlider;
    public VideoPlayer videoPlayer;
    private Dictionary<VideoClip, float> videoProgress = new Dictionary<VideoClip, float>();
    public Cinemachine.CinemachineVirtualCamera vCam;
    private void Start()
    {
        
        videoPlayer.loopPointReached += OnVideoEnd;
        progressSlider.onValueChanged.AddListener(OnSliderValueChanged);

        foreach (var video in videos)
        {
            videoProgress[video] = PlayerPrefs.GetFloat(video.name + "Progress", 0f);
        }

        LoadVideo(videos[0]);
    }
    public void TurnOnVCam()
    {
        vCam.Priority = 20;
    }
    private void LoadVideo(VideoClip videoClip)
    {
        videoPlayer.clip = videoClip;
        Debug.Log($"Clip assigned {videoPlayer.clip.name}");
        videoPlayer.time = videoProgress[videoClip];
       // videoPlayer.Play();
    }

    private void OnSliderValueChanged(float value)
    {
       // videoPlayer.time = value * videoPlayer.clip.length;
    }

    private void Update()
    {
        if (videoPlayer.isPlaying)
        {
            float progress = (float)(videoPlayer.time / videoPlayer.clip.length);
            progressSlider.value = progress;
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        videoProgress[videoPlayer.clip] = 0f;
        PlayerPrefs.SetFloat(videoPlayer.clip.name + "Progress", videoProgress[videoPlayer.clip]);
    }

    public void SelectVideo(int index)
    {
        Debug.Log($"{index} is {videos[index].name}");
        videoProgress[videoPlayer.clip] = (float)(videoPlayer.time / videoPlayer.clip.length); // Store the current progress before changing the video

        LoadVideo(videos[index]);
    }

    /*    public void PlayPause()
        {
            if (videoPlayer.isPlaying)
                videoPlayer.Pause();
            else
                videoPlayer.Play();
        }*/

}
