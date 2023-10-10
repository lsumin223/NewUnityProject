using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Item[] items;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
    }
    public void Show()
    {
        rect.localScale = new Vector3(4, 4, 4);
    }
    public void Hide()
    {
        rect.localScale = Vector3.zero;
    }

    public void Select(int index)
    {
        items[index].Onclick();
    }
}
