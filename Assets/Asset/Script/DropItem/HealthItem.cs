using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instance.playerHelath + 3 >= 10)
            {
                GameManager.instance.playerHelath = 10;
                gameObject.SetActive(false);
                AudioManager.instance.Playsfx(AudioManager.Sfx.heal);
            }
            else if (GameManager.instance.playerHelath + 3 < 10)
            {
                GameManager.instance.playerHelath += 3.0f;
                gameObject.SetActive(false);
                AudioManager.instance.Playsfx(AudioManager.Sfx.heal);
            }
            else if (GameManager.instance.playerHelath == 10)
            {
                gameObject.SetActive(false);
                AudioManager.instance.Playsfx(AudioManager.Sfx.heal);
            }

        }


    }
}
