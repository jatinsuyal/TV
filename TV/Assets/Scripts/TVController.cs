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

   [SerializeField] private bool isPlaying = false;

    private void Start()
    {
        playPauseButton.onClick.AddListener(PlayPause);
        backButton.onClick.AddListener(Back);
    }

    public void TurnOnTV()
    {
        galleryMenu.SetActive(true);
    }

    public void PlayPause()
    {
        isPlaying = !isPlaying;
        if (isPlaying)
        {
            videoPlayer.Play();
            playPauseButton.image.sprite = playPauseSprite[0];
        }
        else
        {
            videoPlayer.Pause();
            playPauseButton.image.sprite = playPauseSprite[1];
        }
    }
    public Sprite[] playPauseSprite;
    public void Back()
    {
        galleryMenu.SetActive(true);
        videoPlayer.gameObject.SetActive(false);
    }

    public void SelectVideo()
    {
        galleryMenu.SetActive(false);
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.Play();
        isPlaying = true;
    }

    public void Seek(float value)
    {
        videoPlayer.time = value * videoPlayer.clip.length;
    }

    public void IncreaseSpeed(float speed)
    {
       // videoPlayer.playbackSpeed += speedIncrement;
        videoPlayer.playbackSpeed = speed;
    }
}
