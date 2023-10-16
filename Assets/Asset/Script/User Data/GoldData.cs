using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldData : MonoBehaviour
{

    public int Playergold;

    public ItemType item;
    public enum ItemType { Dmg, Spd, Cast, Hp, Exp }
    public void ResultGold()// 게임 플레이후 돈 결과
    {

        if (PlayerPrefs.GetInt("PlayerGold") > 0)
            Playergold += PlayerPrefs.GetInt("PlayerGold");
        PlayerPrefs.SetInt("PlayerGold", Playergold + GameManager.instance.gold);


    }
    public void BuyItem()
    {
        switch (item)
        {
            case ItemType.Dmg:

                break;
            case ItemType.Spd:

                break;
            case ItemType.Cast:

                break;
            case ItemType.Hp:

                break;
            case ItemType.Exp:

                break;
        }
    }
}