using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animController;
    public Rigidbody2D target;
    public GameObject dropItem;
    public GameObject dropGold;

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
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.isLive || myAnim.GetBool("Hit"))
        {
            return;
        }
           

        if (!isDead)
        {
            Vector2 dirVec = target.position - myRigid.position;
            Vector2 nextVec = dirVec.normalized * Time.fixedDeltaTime * speed;

            myRigid.MovePosition(myRigid.position + nextVec);
            if (!isHit)
            {
                myRigid.velocity = Vector2.zero;
            }
        }
    }

    private void LateUpdate()
    {
        mySprite.flipX = target.position.x > myRigid.position.x;
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isDead = false;
        myCollider.enabled = true;
        myRigid.simulated = true;
        mySprite.sortingOrder = 2;
        health = maxHealth;
    }
    public void Init(SpawnData data)
    {
        myAnim.runtimeAnimatorController = animController[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
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
            Dead();
            myAnim.SetBool("Dead", true);
            DropItem();

            if (GameManager.instance.isLive)
            {
                GameManager.instance.kill++;
                GameManager.instance.GetExp(enemyExp);
            }
                
            AudioManager.instance.Playsfx(AudioManager.Sfx.kill);

        }

    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isHit = true;
        if (collision.gameObject.CompareTag("Player"))
            StartCoroutine(KnockBack());

        else if (collision.gameObject.CompareTag("Protect"))
            StartCoroutine(ObjKnockBack());
       

    }*/

    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        myRigid.AddForce(dirVec.normalized * 1, ForceMode2D.Impulse);
        isHit = false;
    }

    IEnumerator ObjKnockBack()
    {
        yield return wait;
        Debug.Log("µÇ³ª?");
        Vector3 playerPos = TowerManager.instance.tower.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        myRigid.AddForce(dirVec.normalized * 1, ForceMode2D.Impulse);
        isHit = false;
    }


    void Dead()
    {
        gameObject.SetActive(false);
    }

    private void DropItem()
    {
        Vector2 deadPos = transform.position;
        

        randValue = Random.Range(0, 10);

        if (randValue >= 4)
        {
            GameObject clone = Instantiate(dropItem, deadPos, Quaternion.identity);
        }
        else
        {
            if(randValue <= 1)
            {
                GameObject clone = Instantiate(dropGold, deadPos, Quaternion.identity);
            }
        }

    }

}