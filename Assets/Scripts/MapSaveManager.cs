using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class MapSaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "MapData";

    public static void Save(MapData map)
    {
        string dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(map);
        File.WriteAllText(dir + fileName, json);
        PlayerPrefs.SetString("Map", json);
        PlayerPrefs.Save();
    }

    public static MapData Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        MapData map = new MapData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            map = JsonUtility.FromJson<MapData>(json);
        }
        else
        {
            Debug.Log("Saved Map Does Not Exist");
        }

        return map;
    }
}
