using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 게임 플레이후 돈 결과
public class GoldData : MonoBehaviour
{
public void Start()
    {
        PlayerPrefs.SetInt("FirstGold", 100); 
        PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("nowGold"));
    }
}
