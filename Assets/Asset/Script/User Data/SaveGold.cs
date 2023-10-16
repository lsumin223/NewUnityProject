using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveGold : MonoBehaviour
{
    public int PlayerGold;

    public void Start()
    {
        if (System.IO.File.Exists("GameData.json"))
        {
            string jsonData = System.IO.File.ReadAllText("GameData.json");
            SaveGold data = JsonUtility.FromJson<SaveGold>(jsonData);
            PlayerGold = data.PlayerGold;
        }
        else
        {
            PlayerGold = 0;
        }
    }

    public void OnApplicationQuit()
    {
        SaveGold data = new SaveGold();
        data.PlayerGold = PlayerGold;
        string jsonData = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText("GameData.json", jsonData);
    }

}