using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBCGet : MonoBehaviour
{

    public float health = 0;

    private SpriteRenderer mySprite;
    public Sprite changeSprite;

    private int randValue;

    public GameObject goldItem;
    public GameObject healthItem;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Attack"))
            return;

        int damage = Mathf.RoundToInt(collision.GetComponent<Attack>().damage);

        health -= collision.GetComponent<Attack>().damage;
        AudioManager.instance.Playsfx(AudioManager.Sfx.hit);

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        DmgTxtControl.instance.CreatDamageTxt(pos, damage);

        if (health<=10)
        {
            mySprite.sprite = changeSprite;
        }

        if(health <=0)
        {
            gameObject.SetActive(false);
            DropItem();
        }
    }

    private void DropItem()
    {
        Vector2 deadPos = transform.position;


        randValue = Random.Range(0, 10);
        Debug.Log(randValue);

        if (randValue <= 1)
        {
            Debug.Log("Ã¼·Â");
            GameObject clone = Instantiate(healthItem, deadPos, Quaternion.identity);
        }
        else
        {
            Debug.Log("µ·");
            GameObject clone = Instantiate(goldItem, deadPos, Quaternion.identity);
            
        }

    }
}
