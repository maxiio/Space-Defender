using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class data_base
{

    public static void Serialize(Unit_class unitClass)
    {
        string json = JsonUtility.ToJson(unitClass);
        SaveToFile(json);
        Debug.Log("Json saved.");
    }

    public static Unit_class Deserialize()
    {
        Unit_class unitClass = new Unit_class();
        JsonUtility.FromJsonOverwrite(ReadFromFile(), unitClass);
        Debug.Log("Data Loaded");
        return unitClass;
    }

    private static void SaveToFile(string jsonStream)
    {
        StreamWriter writer;
        FileInfo info = new FileInfo(Application.persistentDataPath + "/DB.xml");
        info.Delete();
        writer = info.CreateText();
        writer.Write(jsonStream);
        writer.Close();
        Debug.Log("File written.");
    }

    private static string ReadFromFile()
    {
        if (File.Exists(Application.persistentDataPath + "/DB.xml"))
        {
            StreamReader r = File.OpenText(Application.persistentDataPath + "/DB.xml");

            string _info = r.ReadToEnd();
            r.Close();

            Debug.Log("File Read");
            return _info;
        }
        else
        {
            File.Create(Application.persistentDataPath + "/DB.xml");
            Debug.Log("SaveCreated");
            return String.Empty;
        }
    }
}
[Serializable]
public class Unit_class
{
    public int highScore;
    public int level;
    public GameObject currentSkin;
}
