using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Item[] items;
    public GameObject healthbar;


    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
    }
    public void Show()
    {
        healthbar.SetActive(false);
        rect.localScale = new Vector3(4, 4, 4);
        GameManager.instance.Stop();
    }
    public void Hide()
    {
        healthbar.SetActive(true);
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
    }

    public void Select(int index)
    {
        items[index].Onclick();
    }
}
