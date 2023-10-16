using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldData : MonoBehaviour
{

    public int Playergold;

   
    public void ResultGold()// 게임 플레이후 돈 결과
    {

        if (PlayerPrefs.GetInt("PlayerGold") > 0)
            Playergold += PlayerPrefs.GetInt("PlayerGold");
        PlayerPrefs.SetInt("PlayerGold", Playergold + GameManager.instance.gold);


    }
    
}