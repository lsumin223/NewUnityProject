using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform myRect;
    private void Awake()
    {
        myRect = GetComponent<RectTransform>();

    }

    private void FixedUpdate()
    {
        myRect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
    }

}