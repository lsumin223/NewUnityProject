using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Scriptble Object/ItemData")]

public class ItemData : ScriptableObject
{
    public enum ItemType { Melee,Range }

    public ItemType itemType;
    public int Id;
    public string itemName;
    [TextArea]
    public string itemDesc;
    public Sprite itemIcon;


    public float baseDamage;
    public int baseCount;
    public float[] damages;
    public int[] counts;

    public GameObject projectile;
}
