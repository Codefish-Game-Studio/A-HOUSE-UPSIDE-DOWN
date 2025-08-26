using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string[] objects = { "ration", "book2", "car", "cat", "food",
        "clock", "poster", "fish", "jewelry", "magnet",
        "mug", "pan", "penguim", "phone", "plant",
        "portrait", "radio", "rubik", "sheet", "watch"};
    public string hiddenObject;
    public bool objectWasFound = false;

    public event Action<int> OnTimeChanged;
    public int totaltime = 30;
    private int time;
    public int Time
    {
        get => time;

        set
        {
            time = Mathf.Clamp(value, 0, totaltime);
            OnTimeChanged?.Invoke(time);
        }
    }

    public event Action<string> OnObjectiveChanged;
    private string objective;
    public string Objective
    {
        get => objective;

        set
        {
            objective = value;
            OnObjectiveChanged?.Invoke(objective);
        }
    }

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        Time = totaltime;
        StopAllCoroutines();

        switch (newScene.name)
        {
            case "NormalHouse1":
                Objective = "Pay attention!";
                StartCoroutine(WaitingForNextScene("UpsideDownHouse"));
                break;
            case "UpsideDownHouse":
                Objective = "Look for the missing item.";
                HideObject();
                StartCoroutine(WaitingForNextScene("NormalHouse2"));
                AudioManager.Instance.ChangePitch(-1f);
                break;
            case "NormalHouse2":
                Objective = "Click on the stolen item.";
                AudioManager.Instance.ChangePitch(1f);
                break;
        }
    }

    private void HideObject()
    {
        objectWasFound = false;
        int r = UnityEngine.Random.Range(0, objects.Length);
        hiddenObject = objects[r];

        GameObject[] objectsOnScene = GameObject.FindGameObjectsWithTag("HideableObject");

        if (objectsOnScene != null)
        {
            foreach (GameObject obj in objectsOnScene)
            {
                string objectID = obj.GetComponent<SelectableObjects>().id;

                if (objectID == hiddenObject)
                {
                    obj.SetActive(false);
                }
            }
        }

        Debug.Log(hiddenObject);
    }

    public void CheckObjectID(string selectedObjectID)
    {
        if (selectedObjectID == hiddenObject)
        {
            objectWasFound = true;

            if (!ObjectDatabase.foundObjectIDs.Contains(selectedObjectID))
            {
                ObjectDatabase.foundObjectIDs.Add(selectedObjectID);
                PlayerData.SaveFoundObjects(ObjectDatabase.foundObjectIDs);
            }

            Debug.Log("Congrats!");
        }
        else
        {
            objectWasFound = false;

            Debug.Log("Wrong!");
        }
        
        SceneLoader.Instance.LoadScene("EndingCutscene", 1f);
    }

    private IEnumerator WaitingForNextScene(string nextScene)
    {
        while (Time > 0)
        {
            Time -= 1;
            yield return new WaitForSeconds(1f);
        }

        SceneLoader.Instance.LoadScene(nextScene, 1f);
    }
}
