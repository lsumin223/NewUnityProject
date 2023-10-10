using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 inputVec;
    public Scaner scan;

    private float speed = 3.0f;

    private Rigidbody2D myRigid;
    private SpriteRenderer mySprite;
    private Animator myAnim;

    
    void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        scan = GetComponent<Scaner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.playerHelath < 0)
            GameManager.instance.isDead = true;

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
        if (!GameManager.instance.isDead)
        {

            GameManager.instance.playerHelath -= Time.deltaTime * 10;

            if (GameManager.instance.playerHelath < 0)
            {
                for (int index = 2; index < transform.childCount; index++)
                {
                     transform.GetChild(index).gameObject.SetActive(false);
                }

                myAnim.SetTrigger("Dead");
            }

           
        }
    }

}
