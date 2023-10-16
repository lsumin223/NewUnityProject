using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    public static PlayerGold instance;

    public List<string> testDataA = new List<string>();
    public List<int> testDataB = new List<int>();

    public int playerGold;
  

    void Awake()
    {
        instance = this;
    }
}

