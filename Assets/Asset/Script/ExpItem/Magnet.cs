using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float speed = 15.0f;
    public float magnetDist = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, GameManager.instance.player.transform.position);
        if(dist <= magnetDist)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                GameManager.instance.player.transform.position, speed*Time.deltaTime);

        }
    }
}
