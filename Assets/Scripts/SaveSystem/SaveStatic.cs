using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveStatic
{

    public static string directory = "/Save/";
    public static string fileName = "SaveGame.json";

    public static void Save(SaveObject so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveObject Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveObject so = null;

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveObject>(json);
        }

        return so;
    }

}
