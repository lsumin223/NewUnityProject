using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldData : MonoBehaviour
{

    public int Playergold;

   
    public void ResultGold()// ���� �÷����� �� ���
    {

        if (PlayerPrefs.GetInt("PlayerGold") > 0)
            Playergold += PlayerPrefs.GetInt("PlayerGold");
        PlayerPrefs.SetInt("PlayerGold", Playergold + GameManager.instance.gold);


    }
    
}