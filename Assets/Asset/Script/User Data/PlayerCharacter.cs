using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public static PlayerCharacter instance;

    public int playerCharacter;


    void Awake()
    {
        instance = this;
    }
}

