using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSpawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData; // 모든 몬스터 유형을 나타내는 배열

    public GameObject[] prefabs;

    private int level;
    private float levelTime;
    private float timer;
    private int curLevel = 0;

    private void Start()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        levelTime = GameManager.instance.maxGameTime / spawnData.Length;
    }

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / levelTime), spawnData.Length - 1);

        if (timer > spawnData[level].spawnTime)
        {
            timer = 0;
            Spawn(level);
        }
    }

    void Spawn(int level)
    {
        this.level = level;
        if (level >= 2)
            level = 1;

        int randomMonsterIndex = Random.Range(0, level +1);
        
        Debug.Log(level);

        SpawnData monsterData = spawnData[randomMonsterIndex];

        GameObject enemy = GameManager.instance.pool.Get(randomMonsterIndex);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;

        enemy.GetComponent<Enemy>().Init(monsterData);

        /*
         *  this.level = level;
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, level+1));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
        */

    }
}