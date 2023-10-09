using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    public int per;

    private Rigidbody2D myRigid;

    private void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.per = per;

        if (per > -1)
        {
            myRigid.velocity = dir * 15f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || per == -1)
            return;

        per--;

        if(per == -1)
        {
            myRigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }

}
