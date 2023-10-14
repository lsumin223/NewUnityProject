using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    public GameObject[] prefabs;

    private int level;
    private float levelTime;
    private float timer;

    private void Start()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        levelTime = GameManager.instance.maxGameTime / spawnData.Length;
    }

    // Update is called once per frame
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

        int randomMonsterIndex = Random.Range(0, level + 1);

        SpawnData monsterData = spawnData[randomMonsterIndex];

        GameObject enemy = GameManager.instance.pool.Get(randomMonsterIndex); 
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        


        if (enemy.CompareTag("Enemy"))
            enemy.GetComponent<Enemy>().Init(monsterData);
        else if (enemy.CompareTag("ObgEnemy"))
            enemy.GetComponent<ObjAttackEnemy>().Init(monsterData);
    }
}

/*
 * void Spawn(int level)
    {
        this.level = level;

        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, level+1));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        if(enemy.CompareTag("Enemy"))
            enemy.GetComponent<Enemy>().Init(spawnData[level]);
        else if (enemy.CompareTag("ObgEnemy"))
            enemy.GetComponent<ObjAttackEnemy>().Init(spawnData[level]);
    }
 */