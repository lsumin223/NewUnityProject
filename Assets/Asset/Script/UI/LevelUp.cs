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
            item.gameObject.SetActive(false);
        }


        List<Item> unMaxLevelItems = new List<Item>();
        foreach (Item item in items)
        {
            if (item.level != item.data.damages.Length)
            {
                unMaxLevelItems.Add(item);
            }
        }

        List<Item> selectedItems = new List<Item>();
        while (selectedItems.Count < 3 && unMaxLevelItems.Count > 0)
        {
            int randomIndex = Random.Range(0, unMaxLevelItems.Count);
            Item randomItem = unMaxLevelItems[randomIndex];

            if (randomItem.level == randomItem.data.damages.Length)
            {
                unMaxLevelItems.RemoveAt(randomIndex);
            }
            else if (!selectedItems.Contains(randomItem))
            {
                selectedItems.Add(randomItem);
                randomItem.gameObject.SetActive(true);
            }

            unMaxLevelItems.RemoveAt(randomIndex);
        }

        foreach (Item item in unMaxLevelItems)
        {
            item.gameObject.SetActive(false);
        }
    }

}