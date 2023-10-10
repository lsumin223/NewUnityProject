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
