using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTime;
    public float maxGameTime = 2 * 10.0f;

    public bool isDead;
    public bool isLive;

    public static GameManager instance;
    public PlayerController player;
    public PoolManager pool;
    public Spawner spawner;
    [Header("Player Setting")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 10, 30, 60, 100, 150, 210, 280, 360, 450, 600 }; //

    public LevelUp uiLevelUp;

    public float playerHelath;
    public float maxHelath = 100;

    void Start()
    {
        uiLevelUp.Select(1); 
        playerHelath = maxHelath;
    }
    void Awake()
    {
        instance = this;
        playerHelath = maxHelath;
        isDead = false;
    }

    private void Update()
    {
        if (!isLive)
            return;
        
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
    // Start is called before the first frame update
    public void GetExp()
    {
        exp++;
        if (exp == nextExp[level])
        {
            level++;
            exp = 0;
            uiLevelUp.Show();
        }

    }
    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}