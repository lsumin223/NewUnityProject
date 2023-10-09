using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float speed = 2.5f;
    public Rigidbody2D target;

    private Rigidbody2D myRigid;
    private SpriteRenderer mySprite;
    private bool isDead;

    // Start is called before the first frame update
    void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isDead)
            return;

        Vector2 dirVec = target.position - myRigid.position;
        Vector2 nextVec = dirVec.normalized * Time.fixedDeltaTime * speed;

        myRigid.MovePosition(myRigid.position + nextVec);
        myRigid.velocity = Vector2.zero;
     
    }

    private void LateUpdate()
    {
        mySprite.flipX = target.position.x < myRigid.position.x;
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
}
