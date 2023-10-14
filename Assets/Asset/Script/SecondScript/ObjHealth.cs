using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjHealth : MonoBehaviour
{
    RectTransform myRect;
    private void Awake()
    {
        myRect = GetComponent<RectTransform>();

    }

    private void FixedUpdate()
    {
        myRect.position = Camera.main.WorldToScreenPoint(TowerManager.instance.tower.transform.position);
    }

}