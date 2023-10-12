using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    Collider2D coll;
    // Start is called before the first frame update
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        float diffX = playerPos.x - myPos.x;
        float diffY = playerPos.y - myPos.y;
        float dirX = Mathf.Abs(diffX) / 56 > Mathf.Abs(diffY) / 34 ? Mathf.Sign(diffX) : 0;

        float dirY = Mathf.Abs(diffY) / 34 > Mathf.Abs(diffX) / 56 ? Mathf.Sign(diffY) : 0;

        switch (transform.tag)
        {
            case "Ground":
                if (dirX != 0)
                {
                    transform.Translate(Vector3.right * dirX * 112);
                }
                else if (dirY != 0)
                {
                    transform.Translate(Vector3.up * dirY * 68);
                }
                break;

            case "Enemy":
                if (coll.enabled) 
                {
                    Vector3 dist = playerPos - myPos;
                    Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
                    transform.Translate(ran + dist * 2);
                }
                break;
        }
    }
    }
