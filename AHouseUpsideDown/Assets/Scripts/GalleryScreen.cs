using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryScreen : MonoBehaviour
{
    public GameObject menuPanel, objectImage, columns;
    public Button[] objectButtons;

    void Start()
    {
        for (int i = 0; i < objectButtons.Length; i++)
        {
            objectButtons[i].GetComponentInChildren<Text>().text = "???";
            objectButtons[i].interactable = false;
        }

        foreach (string foundID in ObjectDatabase.foundObjectIDs)
        {
            if (ObjectDatabase.objectInfo.ContainsKey(foundID))
            {
                var info = ObjectDatabase.objectInfo[foundID];
                int index = info.index;
                objectButtons[index].GetComponentInChildren<Text>().text = info.displayName;
                objectButtons[index].interactable = true;
            }
        }
    }

    public void CloseGalleryPanel()
    {
        GetComponent<Animator>().SetTrigger("Out");
        menuPanel.GetComponent<Animator>().SetTrigger("In");
    }

    public void ShowObjectImage(Sprite objectSprite)
    {
        columns.GetComponent<Animator>().SetTrigger("Out");
        objectImage.GetComponent<Animator>().SetTrigger("In");
        objectImage.GetComponent<Image>().sprite = objectSprite;
    }

    public void CloseObjectImage()
    {
        objectImage.GetComponent<Animator>().SetTrigger("Out");
        columns.GetComponent<Animator>().SetTrigger("In");
    }
}
