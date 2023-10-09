using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTime;
    public float maxGameTime = 2 * 10.0f;


    public static GameManager instance;
    public PlayerController player;
    public PoolManager pool;

    void Awake()
    {
        instance = this;
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
