using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController player;
    public PoolManager pool;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update

}
