using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive : MonoBehaviour
{
    // Start is called before the first frame update

    public ItemData.ItemType type;
    public float rate;


    public void Init(ItemData data)
    {
        name = "Passive" + data.id;
        transform.parent = GameManager.instance.player.transform;
        transform.localPosition = Vector3.zero;

        type = data.itemType;
        rate = data.damages[0];

        ApplyPassive();
    }

    public void LevelUp(float rate)
    {
        this.rate = rate;
        ApplyPassive();
    }

    private void ApplyPassive()
    {
        switch (type)
        {
            case ItemData.ItemType.Attack:
                AttackUp();
                break;
            case ItemData.ItemType.Speed:
                SpeedUp();
                break;
            case ItemData.ItemType.Cool:
                RateUp();
                break;

        }
    }

    private void RateUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach(Weapon weapon in weapons)
        {
            switch(weapon.id)
            {
                case 0:
                    weapon.speed = 150 + (150 * rate);
                    break;

                case 1:
                    weapon.speed = 0.5f * (1f - rate);
                    break;
                case 2:
                    weapon.speed = 15 * (1f - rate);
                    break;
                case 3:
                    weapon.speed = 20 * (1f - rate);
                    break;
            }
        }

    }

    private void SpeedUp()
    {
        float speed = GameManager.instance.player.speed;
        GameManager.instance.player.speed = speed + (speed * rate);
    }

    private void AttackUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach (Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:
                    weapon.damage = 10 + (10 * rate);
                    break;

                case 1:
                    weapon.damage = 5 + (5 * rate);
                    break;
                case 2:
                    weapon.damage = 10 + (10 * rate); 
                    break;
                case 3:
                    weapon.damage = 20 + (20 * rate);
                    break;
            }
        }

    }


}
