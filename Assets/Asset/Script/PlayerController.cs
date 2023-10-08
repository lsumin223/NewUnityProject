using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 inputVec;

    private float speed = 3.0f;
    private bool isDead = false;

    private Rigidbody2D myRigid;
    private SpriteRenderer mySprite;
    private Animator myAnim;
    
    void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
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

    private void Die()
    {
        myAnim.SetTrigger("Dead");
        myRigid.velocity = Vector2.zero;
        isDead = true;
    }

}
