using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    public ItemData data;
    public int level;
    public Weapon weapon;
    public Passive passive;

    Image icon;
    Text textLevel;
    Text textName;
    Text textDesc;

    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.itemIcon;

        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
        textName = texts[1];
        textDesc = texts[2];
        textName.text = data.itemName;

    }
    public void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;
        textLevel.text = "Lv." + (level);
        switch (data.itemType)
        {
            case ItemData.ItemType.Melee:
            case ItemData.ItemType.Skill:
            case ItemData.ItemType.Range:
                if (level >= 0 && level < data.damages.Length - 1)
                {
                    textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100, data.counts[level]);
                }
                break;
            case ItemData.ItemType.Cool:
            case ItemData.ItemType.Attack:
            case ItemData.ItemType.Speed:
                textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100);
                break;
        }

    }

    public void Onclick()
    {
        GameManager.instance.isLevelUp = false;

        switch (data.itemType)
        {
            case ItemData.ItemType.Melee:
            case ItemData.ItemType.Skill:
            case ItemData.ItemType.Range:
                if (level == 0)
                {
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<Weapon>();
                    weapon.Init(data);
                }
                else
                {
                    float nextDamage = data.baseDamage;
                    int nextCount = 0;

                    nextDamage += Mathf.RoundToInt(data.baseDamage * data.damages[level]);
                    nextCount += data.counts[level];

                    weapon.LevelUp(nextDamage, nextCount);
                }
                break;
            case ItemData.ItemType.Cool:
            case ItemData.ItemType.Attack:
            case ItemData.ItemType.Speed:
                if (level == 0)
                {
                    GameObject newPassive = new GameObject();
                    passive = newPassive.AddComponent<Passive>();
                    passive.Init(data);
                }
                else
                {
                    float nextRate = data.damages[level];
                    passive.LevelUp(nextRate);
                }
                break;

        }
        level++;

        if (level == data.damages.Length)
        {
            GetComponent<Button>().interactable = false;
        }
    }


}