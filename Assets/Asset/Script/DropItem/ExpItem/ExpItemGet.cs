using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItemGet : MonoBehaviour
{

    private int itemExp;
    private float timer;
    private float hello;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("CheckE") == 1)
        {
            itemExp = 4;
            timer = 0;
        }
        if (PlayerPrefs.GetInt("CheckE") == 2)
        {
            itemExp = 4;
            timer = 0;
        }
        else
        {
            itemExp = 3;
            timer = 0;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        hello = Random.Range(15, 20);

        if (timer >= hello)
        {
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance.isLive)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.GetExp(itemExp);
                gameObject.SetActive(false);
            }
        }

    }
}
