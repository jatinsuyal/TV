using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;

public class VideoManager : MonoBehaviour
{
    public VideoClip[] videos;
    public Slider progressSlider;

    private VideoPlayer videoPlayer;
    private Dictionary<VideoClip, float> videoProgress = new Dictionary<VideoClip, float>();

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
        progressSlider.onValueChanged.AddListener(OnSliderValueChanged);

        foreach (var video in videos)
        {
            videoProgress[video] = PlayerPrefs.GetFloat(video.name + "Progress", 0f);
        }

        LoadVideo(videos[0]);
    }

    private void LoadVideo(VideoClip videoClip)
    {
        videoPlayer.clip = videoClip;
        videoPlayer.time = videoProgress[videoClip];
        videoPlayer.Play();
    }

    private void OnSliderValueChanged(float value)
    {
        videoPlayer.time = value * videoPlayer.clip.length;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        videoProgress[videoPlayer.clip] = 0f;
        PlayerPrefs.SetFloat(videoPlayer.clip.name + "Progress", videoProgress[videoPlayer.clip]);
    }

    public void SelectVideo(int index)
    {
        LoadVideo(videos[index]);
    }

    public void PlayPause()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
        else
            videoPlayer.Play();
    }
}
