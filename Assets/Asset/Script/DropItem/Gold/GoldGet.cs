using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGet : MonoBehaviour
{
    private int money;
    private float timer;
    private float hello;

    private void Awake()
    {
        money = 10;
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        hello = Random.Range(10, 20);

        if (timer >= hello)
        {
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.instance.isLive)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.GetGold(money);
                gameObject.SetActive(false);
            }
        }
       
    }
}

