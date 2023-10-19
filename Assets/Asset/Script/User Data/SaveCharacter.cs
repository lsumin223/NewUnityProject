using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveCharacter : MonoBehaviour
{
    public int PlayerCharacter;

    public void Start()
    {
        if (System.IO.File.Exists("GameData.json"))
        {
            string jsonData = System.IO.File.ReadAllText("GameData.json");
            SaveCharacter data = JsonUtility.FromJson<SaveCharacter>(jsonData);
            PlayerCharacter = data.PlayerCharacter;
        }
        else
        {
            PlayerCharacter = 0;
        }
    }

    public void OnApplicationQuit()
    {
        SaveCharacter data = new SaveCharacter();
        data.PlayerCharacter = PlayerCharacter;
        string jsonData = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText("GameData.json", jsonData);
    }

}