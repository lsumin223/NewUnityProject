using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public int stage;
    public int characterType; // �߰�
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
            PlayerCharacter.instance.playerCharacter = 0; // �߰�
            PlayerStage.instance.playerStage = 0;

            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {
                PlayerGold.instance.playerGold = saveData.gold;
                PlayerCharacter.instance.playerCharacter = saveData.characterType; // �߰�
                PlayerStage.instance.playerStage = saveData.stage;

            }
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        saveData.characterType = PlayerCharacter.instance.playerCharacter;     // �߰�

        saveData.stage = PlayerStage.instance.playerStage;


        saveData.gold = PlayerGold.instance.playerGold;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

}