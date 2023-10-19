using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 inputVec;
    public Scaner scan;

    public float speed = 6.0f;

    private Rigidbody2D myRigid;
    private SpriteRenderer mySprite;
    public Animator myAnim;

    public Image damageScreen;
    public GameObject damageObject;

    private int isInvincible = 0;
    private float timer = 0f;


    void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        scan = GetComponent<Scaner>();

        myAnim.SetInteger("PlayerType", PlayerPrefs.GetInt("PlayerCharacter"));

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.playerHelath < 0 || GameManager.instance.isCheck)
        {
            GameManager.instance.isLive = false;
            inputVec = Vector2.zero;
            return;
        }

        if (isInvincible != 0)
        {
            timer += Time.deltaTime;
            if (timer >= 0.1)
            {
                isInvincible = 0;
                timer = 0;
                if (AudioManager.instance.isEffOn)
                    myAnim.SetTrigger("Hit");
            }
        }

        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
      
            Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
            myRigid.MovePosition(myRigid.position + nextVec);
        
    }

        void LateUpdate()
    {
        myAnim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            mySprite.flipX = inputVec.x < 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (GameManager.instance.isLive)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("ObgEnemy"))
            {
                if (isInvincible == 0)
                {
                    GameManager.instance.playerHelath -= Time.deltaTime * 10;
                    AudioManager.instance.Playsfx(AudioManager.Sfx.playerHit);

                    StartCoroutine(DamageEffect());
                    isInvincible++;
                }
            }


            if (GameManager.instance.playerHelath < 0)
            {
                for (int index = 0; index < transform.childCount; index++)
                {
                    if (!transform.GetChild(index).gameObject.CompareTag("Area"))
                        transform.GetChild(index).gameObject.SetActive(false);
                }

                myAnim.SetBool("Dead", true);

                GameManager.instance.GameOver();
                AudioManager.instance.Playsfx(AudioManager.Sfx.dead);
            }


        }
    }
    IEnumerator DamageEffect()
    {
        if(AudioManager.instance.isEffOn)
        {
            damageObject.SetActive(true);
            damageScreen.color = new Color(1, 0, 0, UnityEngine.Random.Range(0.2f, 0.3f));
            yield return new WaitForSeconds(0.1f);
            damageScreen.color = Color.clear;
            damageObject.SetActive(false);
        }
        
    }

}