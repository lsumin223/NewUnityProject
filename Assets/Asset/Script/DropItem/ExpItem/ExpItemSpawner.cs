using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItemSpawner : MonoBehaviour
{
    public GameObject expItem;

    private BoxCollider2D area;
    private int count = 5;

    private List<GameObject> spawnList =  new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        ExpSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ExpSpawn()
    {
        for(int index = 0; index < count; index++)
        {
            Vector2 spawnPos = RandomPosition();

            if (IsDuplicatePosition(spawnPos))
            {
                spawnPos = RandomPosition();
            }

            GameObject clone = Instantiate(expItem, spawnPos, Quaternion.identity);
            spawnList.Add(clone);

        }
        
    }

    private Vector2 RandomPosition()
    {
        Vector2 size = area.size;

        float PosX = transform.position.x + Random.Range(-size.x /2f, size.x/2f);
        Debug.Log("PosX"+ PosX);
        float PosY = transform.position.y + Random.Range(-size.y / 2f, size.y / 2f);
        Debug.Log("PosY" + PosY);

        Vector2 spawnPos = new Vector2(PosX, PosY);

        return spawnPos;
    }

    private bool IsDuplicatePosition(Vector2 position)
    {
        foreach (GameObject spawn in spawnList)
        {
            if (spawn != null && Vector2.Distance(spawn.transform.position, position) < 70.0f 
                && Vector2.Distance(GameManager.instance.player.transform.position, position) < 50.0f)
            {
                // The new position is too close to an existing item
                return true;
            }
        }

        return false;
    }

}
