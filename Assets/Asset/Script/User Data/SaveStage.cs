using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveStage : MonoBehaviour
{
    public int PlayerStage;

    public void Start()
    {
        if (System.IO.File.Exists("GameData.json"))
        {
            string jsonData = System.IO.File.ReadAllText("GameData.json");
            SaveStage data = JsonUtility.FromJson<SaveStage>(jsonData);
            PlayerStage = data.PlayerStage;
        }
        else
        {
            PlayerStage = 0;
        }
    }

    public void OnApplicationQuit()
    {
        SaveStage data = new SaveStage();
        data.PlayerStage = PlayerStage;
        string jsonData = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText("GameData.json", jsonData);
    }

}