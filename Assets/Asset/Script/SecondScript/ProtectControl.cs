using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 inputVec;

    private Rigidbody2D myRigid;
    private SpriteRenderer mySprite;
    private Animator myAnim;
    private Animator objAnim;

    public GameObject player;
    private bool isValue;


    public Image damageScreen;
    public GameObject damageObject;


    void Awake()
    {
        objAnim = GetComponent<Animator>();
        myRigid = player.GetComponent<Rigidbody2D>();
        mySprite = player.GetComponent<SpriteRenderer>();
        myAnim = player.GetComponent<Animator>();
        isValue = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isCheck || TowerManager.instance.playerHelath < 0)
        {
            GameManager.instance.isLive = false;
            return;
        }

        if (TowerManager.instance.playerHelath <= 0 && !isValue)
        {
            isValue = true;
            for (int index = 0; index < player.transform.childCount; index++)
            {
                if (!player.transform.GetChild(index).gameObject.CompareTag("Area"))
                    player.transform.GetChild(index).gameObject.SetActive(false);
            }
            myAnim.SetBool("Dead", true);
            objAnim.SetTrigger("Dead");
            GameManager.instance.GameOver();
            AudioManager.instance.Playsfx(AudioManager.Sfx.dead);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance.isLive)
        {
            if (collision.gameObject.CompareTag("ObgEnemy"))
            {
                Debug.Log("ตส?");
                StartCoroutine(DamageEffect());
            }
        }
    }

    IEnumerator DamageEffect()
    {
        damageObject.SetActive(true);
        damageScreen.color = new Color(1, 0, 0, UnityEngine.Random.Range(0.2f, 0.3f));
        yield return new WaitForSeconds(0.1f);
        damageScreen.color = Color.clear;
        damageObject.SetActive(false);
    }

}
