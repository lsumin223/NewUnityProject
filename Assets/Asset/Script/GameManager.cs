using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTime;
    public float maxGameTime = 2 * 10.0f;

    public bool isDead;

    public static GameManager instance;
    public PlayerController player;
    public PoolManager pool;
    public Spawner spawner;
    [Header("Player Setting")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 10, 30, 60, 100, 150, 210, 280, 360, 450, 600 }; // 레벨당 필요 경험치

    public float playerHelath;
    public float maxHelath = 20;

    void Awake()
    {
        instance = this;
        playerHelath = maxHelath;
        isDead = false;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
    // Start is called before the first frame update

}
