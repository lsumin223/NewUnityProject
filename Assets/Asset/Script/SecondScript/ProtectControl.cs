using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 inputVec;
    private float speed = 6.0f;

    private Rigidbody2D myRigid;
    private SpriteRenderer mySprite;


    void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (TowerManager.instance.playerHelath < 0 || GameManager.instance.isCheck || GameManager.instance.playerHelath <0)
        {
            GameManager.instance.isLive = false;
            TowerManager.instance.isLive = false;
            inputVec = Vector2.zero;
            return;
        }

    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (TowerManager.instance.isLive)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("ObgEnemy"))
            {
                TowerManager.instance.playerHelath -= Time.deltaTime * 10;
                AudioManager.instance.Playsfx(AudioManager.Sfx.playerHit);
            }

            if (TowerManager.instance.playerHelath < 0)
            {
                for (int index = 0; index < transform.childCount; index++)
                {
                    if (!transform.GetChild(index).gameObject.CompareTag("Area"))
                        transform.GetChild(index).gameObject.SetActive(false);
                }

                GameManager.instance.GameOver();
                AudioManager.instance.Playsfx(AudioManager.Sfx.dead);
            }


        }
    }

}
