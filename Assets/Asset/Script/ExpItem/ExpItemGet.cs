using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItemGet : MonoBehaviour
{

    private int itemExp;

    private float timer;
    private float limitTimer;

    private Scaner scan;

    private void Awake()
    {
        itemExp = 3;
        limitTimer = Random.Range(15, 20);
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, GameManager.instance.player.transform.position);

        timer = timer + Time.deltaTime;
        if (timer >= limitTimer)
            RemoveItem();

    }

    private void RemoveItem()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GetExp(itemExp);
            gameObject.SetActive(false);
        }
    }


}

