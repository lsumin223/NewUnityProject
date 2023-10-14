using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") || collision.CompareTag("ObgEnemy"))
            collision.gameObject.SetActive(false);

        AudioManager.instance.Playsfx(AudioManager.Sfx.hit);
    }

}
