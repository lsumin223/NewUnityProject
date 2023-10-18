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
        Next();
        healthbar.SetActive(false);
        rect.localScale = new Vector3(4, 4, 4);
        GameManager.instance.Stop();
        AudioManager.instance.Playsfx(AudioManager.Sfx.levelUp);
    }
    public void Hide()
    {
        healthbar.SetActive(true);
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
        AudioManager.instance.Playsfx(AudioManager.Sfx.select2);
    }

    public void Select(int index)
    {
        items[index].Onclick();
    }

    void Next()
    {
        foreach (Item item in items)
        {
            Debug.Log(item);
            item.gameObject.SetActive(false);
        }

        int[] ran = new int[2];
        while (true)
        {
            ran[0] = Random.Range(0, items.Length);
            ran[1] = Random.Range(0, items.Length);

            if (ran[0] != ran[1])
                break;
        }

        for (int index = 0; index < ran.Length; index++)
        {
            Item ranItem = items[ran[index]];

            if (ranItem.level == ranItem.data.damages.Length)
            {
                Item newRanItem = FindRandomItem(ranItem);
                if(newRanItem == null)
                {
                }
                else
                    newRanItem.gameObject.SetActive(true);
            }
            else
                ranItem.gameObject.SetActive(true);
        }
    }

    Item FindRandomItem(Item currentItem)
    {
        List<Item> unMaxLevel = new List<Item>();

        foreach (Item item in items)
        {
            if(item != currentItem && item.level < item.data.damages.Length)
            {
                unMaxLevel.Add(item);
            }
        }

        if(unMaxLevel.Count > 0)
        {
            int randomIndex = Random.Range(0, unMaxLevel.Count);
            return unMaxLevel[randomIndex];
        }
        else
        {
            return null; 
        }

    }

}