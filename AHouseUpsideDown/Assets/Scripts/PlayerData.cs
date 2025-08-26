using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    private const string FoundObjectsKey = "FoundObjects";

    public static void SaveFoundObjects(List<string> foundObjectIDs)
    {
        string serialized = string.Join(",", foundObjectIDs);
        PlayerPrefs.SetString(FoundObjectsKey, serialized);
        PlayerPrefs.Save();
    }

    public static List<string> LoadFoundObjects()
    {
        List<string> loadedList = new List<string>();

        if (PlayerPrefs.HasKey(FoundObjectsKey))
        {
            string serialized = PlayerPrefs.GetString(FoundObjectsKey);
            if (!string.IsNullOrEmpty(serialized))
            {
                string[] ids = serialized.Split(',');
                loadedList = new List<string>(ids);
            }
        }

        return loadedList;
    }

    public static void ClearData()
    {
        PlayerPrefs.DeleteKey(FoundObjectsKey);
    }
}
