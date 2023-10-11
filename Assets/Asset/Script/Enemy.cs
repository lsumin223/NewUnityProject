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
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Attack"))
            return;

        health -= collision.GetComponent<Attack>().damage;

        //StartCoroutine(KnockBack());

        if (health > 0)
        {
            myAnim.SetTrigger("Hit");
        }
        else
        {
            isDead = true;
            myCollider.enabled = false;
            myRigid.simulated = false;
            mySprite.sortingOrder = 1;
            myAnim.SetBool("Dead", true);
            Dead();
            DropItem();
            GameManager.instance.kill++;
            GameManager.instance.GetExp(enemyExp);

        }

    }

    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        myRigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
    }


    void Dead()
    {
        gameObject.SetActive(false);
    }

    private void DropItem()
    {
        Vector2 deadPos = transform.position;
        

        randValue = Random.Range(0, 10);

        if(randValue >= 4)
        {
            GameObject clone = Instantiate(dropItem, deadPos, Quaternion.identity);
        }

    }

}