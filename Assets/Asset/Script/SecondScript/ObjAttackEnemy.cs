using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAttackEnemy : MonoBehaviour
{

    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animController;
    public Rigidbody2D target;


    private Rigidbody2D myRigid;
    private Collider2D myCollider;
    private SpriteRenderer mySprite;
    private Animator myAnim;
    private bool isDead;
    private bool isHit;
    private int randValue;

    private int enemyExp;

    WaitForFixedUpdate wait;

    // Start is called before the first frame update
    void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

        enemyExp = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if (!isDead)
        {
            Vector2 dirVec = target.position - myRigid.position;
            Vector2 nextVec = dirVec.normalized * Time.fixedDeltaTime * speed;

            myRigid.MovePosition(myRigid.position + nextVec);
            myRigid.velocity = Vector2.zero;
        }
    }

    private void LateUpdate()
    {
        mySprite.flipX = target.position.x > myRigid.position.x;
    }

    private void OnEnable()
    {
        target = TowerManager.instance.tower.GetComponent<Rigidbody2D>();
        isDead = false;
        myCollider.enabled = true;
        myRigid.simulated = true;
        mySprite.sortingOrder = 2;
        myAnim.SetBool("Dead", isDead);
        health = maxHealth;
    }
    public void Init(SpawnData data)
    {
        myAnim.runtimeAnimatorController = animController[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Protect"))
        {
            TowerManager.instance.playerHelath -= 5;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.CompareTag("Protect"))
        {
            TowerManager.instance.playerHelath -= 5; 
            gameObject.SetActive(false); 
        }*/


        if (!collision.CompareTag("Attack"))
            return;

        int damage = Mathf.RoundToInt(collision.GetComponent<Attack>().damage);

        health -= collision.GetComponent<Attack>().damage;
        AudioManager.instance.Playsfx(AudioManager.Sfx.hit);

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        DmgTxtControl.instance.CreatDamageTxt(pos, damage);


        if (health > 0)
        {
            myAnim.SetTrigger("Hit");
            StartCoroutine(KnockBack());
        }
        else
        {
            isDead = true;
            myCollider.enabled = false;
            myRigid.simulated = false;
            mySprite.sortingOrder = 1;
            myAnim.SetBool("Dead", true);
            Dead();
            if (GameManager.instance.isLive)
            {
                GameManager.instance.kill++;
                GameManager.instance.GetExp(enemyExp);
            }
     
            AudioManager.instance.Playsfx(AudioManager.Sfx.kill);

        }

    }

    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        myRigid.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);
    }


    void Dead()
    {
        gameObject.SetActive(false);
    }


}