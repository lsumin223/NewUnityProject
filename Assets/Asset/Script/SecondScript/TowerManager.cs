using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerManager : MonoBehaviour
{

    public static TowerManager instance;
    public ProtectControl tower;


    [Header("Tower Setting")]
    public float playerHelath;
    public float maxHelath = 100;


    void Start()
    {
        playerHelath = maxHelath;
    }
    void Awake()
    {
        instance = this;
        playerHelath = maxHelath;
    }

}
    // Start is called before the first frame update
