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
        timeText = GameManager.instance.maxGameTime.ToString();
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

    }
}
