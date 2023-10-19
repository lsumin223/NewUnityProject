using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public int characterType; // 추가
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
            PlayerCharacter.instance.playerCharacter = 0; // 추가

            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {
                PlayerGold.instance.playerGold = saveData.gold;
                PlayerCharacter.instance.playerCharacter = saveData.characterType; // 추가

            }
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        saveData.characterType = PlayerCharacter.instance.playerCharacter;     // 추가


        saveData.gold = PlayerGold.instance.playerGold;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

}