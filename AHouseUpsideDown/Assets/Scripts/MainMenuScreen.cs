using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    public GameObject galleryPanel;
    public GameObject volumeButton;
    public Sprite volumeMute, volumeUnmute;

    void Awake()
    {
        ObjectDatabase.foundObjectIDs = PlayerData.LoadFoundObjects();
    }

    public void Play()
    {
        SceneLoader.Instance.LoadScene("IntroCutscene1", 1f);
        AudioManager.Instance.FadeVolume(true);
    }

    public void OpenGalleryPanel()
    {
        GetComponent<Animator>().SetTrigger("Out");
        galleryPanel.GetComponent<Animator>().SetTrigger("In");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Volume()
    {
        AudioManager.Instance.ToggleMute();
        volumeButton.GetComponent<Image>().sprite = AudioManager.Instance.isMuted ? volumeMute : volumeUnmute;
    }
}
