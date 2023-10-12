using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPrint : MonoBehaviour
{

    public GameObject time;
    public GameObject gold;
    public GameObject endLevel;
    public GameObject kill;
    public GameObject button;
    public GameObject title;

    private string timeText;
    private string goldText;
    private string levelText;
    private string killText;

    private void Update()
    {

        if (!GameManager.instance.isLive)
            PrintResultCont();

    }

    public void ChangeString()
    {
        int max = Mathf.FloorToInt(GameManager.instance.maxGameTime);
        int survive = max - (Mathf.FloorToInt(max -GameManager.instance.gameTime));
        int min = Mathf.FloorToInt(survive / 60);
        int sec = Mathf.FloorToInt(survive % 60);
        timeText = string.Format("{0}분 {1}초", min, sec);
        goldText = "0";
        levelText = GameManager.instance.level.ToString();
        killText = GameManager.instance.kill.ToString();
    }

    public void PrintResultCont()
    {
        ChangeString();

        time.transform.GetComponent<Text>().text = timeText;

        gold.transform.GetComponent<Text>().text = goldText;
        endLevel.transform.GetComponent<Text>().text = levelText;
        kill.transform.GetComponent<Text>().text = killText;

        CheckSurvie();

    }

    public void CheckSurvie()
    {

        if (GameManager.instance.isCheck)
        {
            button.transform.GetComponent<Text>().text = "메인으로";
            title.transform.GetComponent<Text>().text = "게임클리어";
        }
        else if (!GameManager.instance.isCheck)
        {
            button.transform.GetComponent<Text>().text = "다시도전";
            title.transform.GetComponent<Text>().text = "게임오버";
        }
    }
}
