using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{
    public Text foundTxt;

    void Start()
    {
        AudioManager.Instance.ChangeMusic(AudioManager.Instance.menuMusic);
        foundTxt.text = ObjectDatabase.foundObjectIDs.Count + "/20 found.";
    }

    public void Retry()
    {
        CutsceneController.lineIndex = 7;
        SceneLoader.Instance.LoadScene("NormalHouse1", 1f);
        AudioManager.Instance.ChangePitch(1f);
        AudioManager.Instance.FadeVolume(true);
        AudioManager.Instance.ChangeMusic(AudioManager.Instance.gameMusic);
        
    }

    public void GoToMenu()
    {
        CutsceneController.lineIndex = 0;
        SceneLoader.Instance.LoadScene("MainMenu", 1f);
        AudioManager.Instance.ChangePitch(1f);
    }
}
