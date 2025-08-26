using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text timerTxt, objectiveTxt;

    public static GameUIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnTimeChanged += UpdateTimerDisplay;
            GameManager.Instance.OnObjectiveChanged += UpdateObjectiveDisplay;
        }
    }

    void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnTimeChanged -= UpdateTimerDisplay;
            GameManager.Instance.OnObjectiveChanged -= UpdateObjectiveDisplay;
        }
    }

    void UpdateTimerDisplay(int newValue)
    {
        timerTxt.text = newValue.ToString() + " seconds left...";
    }

    void UpdateObjectiveDisplay(string newText)
    {
        objectiveTxt.text = newText;
    }

    public void Skip(string sceneName)
    {
        SceneLoader.Instance.LoadScene(sceneName, 1f);
    }
}
