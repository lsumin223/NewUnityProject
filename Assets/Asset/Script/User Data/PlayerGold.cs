using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    public static PlayerGold instance;

    public int playerGold;


    void Awake()
    {
        instance = this;
    }
}

