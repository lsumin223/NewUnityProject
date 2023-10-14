using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, Time, Health, Gold, Totalgold, ObjHealth}
    public InfoType type;
    Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
                mySlider.value = curExp / maxExp;
                break;

            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", GameManager.instance.level);
                break;

            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.instance.kill);

                break;

            case InfoType.Time:
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;

            case InfoType.Health:
                float curHealth = GameManager.instance.playerHelath;
                float maxHealth = GameManager.instance.maxHelath;
                mySlider.value = curHealth / maxHealth;
                break;

            case InfoType.Gold:
                int gold = GameManager.instance.gold;
                myText.text = string.Format("{0:F0}G", gold);
                break;

            case InfoType.Totalgold:
                int Tgold = PlayerPrefs.GetInt("PlayerGold") + GameManager.instance.gold;
                myText.text = string.Format("{0:F0}G", Tgold);
                break;


            case InfoType.ObjHealth:
                float curObjHealth = TowerManager.instance.playerHelath;
                float maxObjHealth = TowerManager.instance.maxHelath;
                mySlider.value = curObjHealth / maxObjHealth;
                break;
        }
    }
}
