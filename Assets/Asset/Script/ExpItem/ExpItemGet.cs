using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItemGet : MonoBehaviour
{

    private int itemExp;

    private void Awake()
    {
        itemExp = 3;
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
