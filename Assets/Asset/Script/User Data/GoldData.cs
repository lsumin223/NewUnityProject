using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ���� �÷����� �� ���
public class GoldData : MonoBehaviour
{
public void Start()
    {
        PlayerPrefs.SetInt("FirstGold", 100); 
        PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("nowGold"));
    }
}
