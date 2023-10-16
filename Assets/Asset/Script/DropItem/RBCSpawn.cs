using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBCSpawn : MonoBehaviour
{
    public GameObject money;

    private BoxCollider2D area;
    private int count = 1;

    private float interval = 3.0f;

    private List<GameObject> spawnList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        InvokeRepeating("MoneySpawn", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void MoneySpawn()
    {
        for (int index = 0; index < count; index++)
        {
            Vector2 spawnPos = RandomPosition();

            if (IsDuplicatePosition(spawnPos))
            {
                spawnPos = RandomPosition();
            }

            GameObject clone = Instantiate(money, spawnPos, Quaternion.identity);
            spawnList.Add(clone);


        }

    }

    private Vector2 RandomPosition()
    {
        Vector2 size = area.size;

        float PosX = transform.position.x + Random.Range(-size.x / 2f, size.x / 2f);
        float PosY = transform.position.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(PosX, PosY);

        return spawnPos;
    }

    private bool IsDuplicatePosition(Vector2 position)
    {
        foreach (GameObject spawn in spawnList)
        {
            if (spawn != null && Vector2.Distance(spawn.transform.position, position) > 70.0f
                && Vector2.Distance(GameManager.instance.player.transform.position, position) > 1000.0f)
            {
                // The new position is too close to an existing item
                return true;
            }
        }

        return false;
    }

}
