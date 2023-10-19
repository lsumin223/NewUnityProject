using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive : MonoBehaviour
{
    // Start is called before the first frame update

    public ItemData.ItemType type;
    public float rate;
    public int level;

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

    public void ApplyPassive()
    {
        switch (type)
        {
            case ItemData.ItemType.Attack:
                AttackUp();
                break;

            case ItemData.ItemType.Cool:
                RateUp();
                break;
            case ItemData.ItemType.Speed:
                SpeedUp();
                break;
        }
    }


    public void RateUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach (Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:
                    if (PlayerPrefs.GetInt("CheckC") == 1)
                    {
                        weapon.speed = 150 + (150 * rate) + 15;
                    }
                    else
                    {
                        weapon.speed = 150 + (150 * rate);
                    }
                    break;

                case 1:
                    if (PlayerPrefs.GetInt("CheckC") == 1)
                    {
                        weapon.speed = 0.3f * (1f - rate) - 0.03f;
                    }
                    else
                    {
                        weapon.speed = 0.3f * (1f - rate);
                    }
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("CheckC") == 1)
                    {
                        weapon.speed = 15 * (1f - rate) - 1.5f;
                    }
                    else
                    {
                        weapon.speed = 15 * (1f - rate);
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("CheckC") == 1)
                    {
                        weapon.speed = 20 * (1f - rate) - 2;
                    }
                    else
                    {
                        weapon.speed = 20 * (1f - rate);
                    }
                    break;
            }
        }

    }

    public void SpeedUp()
    {
        if (PlayerPrefs.GetInt("CheckB") == 1)
        {
            float speed = GameManager.instance.player.speed;
            GameManager.instance.player.speed = speed + (speed * rate) + (speed * 0.1f);
        }
        else
        {
            float speed = GameManager.instance.player.speed;
            GameManager.instance.player.speed = speed + (speed * rate);
        }
    }

    public void AttackUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach (Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:

                    if (PlayerPrefs.GetInt("CheckA") == 1)
                    {
                        weapon.damage = (weapon.damage + (weapon.damage * 0.1f)) + ((weapon.damage + (weapon.damage * 0.1f)) * rate);
                    }
                    else
                    {
                        weapon.damage = weapon.damage + (weapon.damage * rate);
                    }
                    break;

                case 1:

                    if (PlayerPrefs.GetInt("CheckA") == 1)
                    {
                        weapon.damage = (weapon.damage + (weapon.damage * 0.1f)) + ((weapon.damage + (weapon.damage * 0.1f)) * rate);
                    }
                    else
                    {
                        weapon.damage = weapon.damage + (weapon.damage * rate);
                    }
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("CheckA") == 1)
                    {
                        weapon.damage = (weapon.damage + (weapon.damage * 0.1f)) + ((weapon.damage + (weapon.damage * 0.1f)) * rate);
                    }
                    else
                    {
                        weapon.damage = weapon.damage + (weapon.damage * rate);
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("CheckA") == 1)
                    {
                        weapon.damage = (weapon.damage + (weapon.damage * 0.1f)) + ((weapon.damage + (weapon.damage * 0.1f)) * rate);
                    }
                    else
                    {
                        weapon.damage = weapon.damage + (weapon.damage * rate);
                    }
                    break;
            }
        }

    }


}