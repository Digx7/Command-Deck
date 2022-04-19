using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class MapSaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "MapData";

    public static void Save(MapManager map)
    {
        string dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(map);
        File.WriteAllText(dir + fileName, json);
    }

    public static MapManager Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        MapManager map = new MapManager();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            map = JsonUtility.FromJson<MapManager>(json);
        }
        else
        {
            Debug.Log("Saved Map Does Not Exist");
        }

        return map;
    }
}
