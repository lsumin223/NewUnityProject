using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData; // 모든 몬스터 유형을 나타내는 배열

    public GameObject[] prefabs;

    private int level;
    private float levelTime;
    private float timer;
    private float start;

    private void Start()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        levelTime = GameManager.instance.maxGameTime / spawnData.Length;
    }

    void Update()
    {
        start += Time.deltaTime;
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt((GameManager.instance.gameTime - 60) / levelTime), spawnData.Length - 1);
        if (start > 60)
        {
            if (timer > spawnData[level].spawnTime)
            {
                timer = 0;
                Spawn(level);
            }
        }
    }

    void Spawn(int level)
    {
       
        this.level = level;
        GameObject enemy = GameManager.instance.pool.Get(2);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<ObjAttackEnemy>().Init(spawnData[level]);

    }
}