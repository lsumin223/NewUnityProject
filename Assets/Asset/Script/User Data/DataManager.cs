using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public List<string> testDataA = new List<string>();
    public List<int> testDataB = new List<int>();
    
    public int gold;
}

public class DataManager : MonoBehaviour
{
    public enum status { Buy, Reset };
    string path;

    void Start()
    {
        path = Path.Combine(Application.dataPath + "/Data/", "database.json");
        JsonLoad();
    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {
            PlayerGold.instance.playerGold = 100;

            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {
                for (int i = 0; i < saveData.testDataA.Count; i++)
                {
                    PlayerGold.instance.testDataA.Add(saveData.testDataA[i]);
                }
                for (int i = 0; i < saveData.testDataB.Count; i++)
                {
                    PlayerGold.instance.testDataB.Add(saveData.testDataB[i]);
                }
                PlayerGold.instance.playerGold = saveData.gold;

            }
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();
        
    
       

        saveData.gold = PlayerGold.instance.playerGold;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

}