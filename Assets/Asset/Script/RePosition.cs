using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        float diffX = playerPos.x - myPos.x;
        float diffY = playerPos.y - myPos.y;
        float dirX = Mathf.Abs(diffX) / 60 > Mathf.Abs(diffY) / 40 ? Mathf.Sign(diffX) : 0;

        float dirY = Mathf.Abs(diffY) / 40 > Mathf.Abs(diffX) / 60 ? Mathf.Sign(diffY) : 0;

        switch (transform.tag)
        {
            case "Ground":
                if (dirX != 0)
                {
                    transform.Translate(Vector3.right * dirX * 120);
                }
                else if (dirY != 0)
                {
                    transform.Translate(Vector3.up * dirY * 80);
                }
                break;
            case "Enemy":
                
                break;
        }
    }
}