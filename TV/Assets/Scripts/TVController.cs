using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TVController : MonoBehaviour
{
    public GameObject galleryMenu;
    public VideoPlayer videoPlayer;
    public Button playPauseButton;
    public Button backButton;
    public Slider videoSlider;

    private bool isPlaying = false;

    private void Start()
    {
        galleryMenu.SetActive(false);
        videoPlayer.gameObject.SetActive(false);
    }

    public void TurnOnTV()
    {
        galleryMenu.SetActive(true);
    }

    public void PlayPause()
    {
        if (isPlaying)
        {
            videoPlayer.Pause();
            isPlaying = false;
            playPauseButton.GetComponentInChildren<Text>().text = "Play";
        }
        else
        {
            videoPlayer.Play();
            isPlaying = true;
            playPauseButton.GetComponentInChildren<Text>().text = "Pause";
        }
    }

    public void Back()
    {
        galleryMenu.SetActive(true);
        videoPlayer.gameObject.SetActive(false);
    }

    public void SelectVideo(string videoName)
    {
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.clip = Resources.Load<VideoClip>("Videos/" + videoName);
        videoPlayer.Play();
        isPlaying = true;
        playPauseButton.GetComponentInChildren<Text>().text = "Pause";
    }

    public void Seek(float value)
    {
        videoPlayer.time = value * videoPlayer.clip.length;
    }

}
