using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float gameTime;
    public float maxGameTime = 2 * 10.0f;

    public bool isCheck;
    public bool isLive;
    public bool isLevelUp;

    public static GameManager instance;
    public PlayerController player;
    public PoolManager pool;
    public Spawner spawner;
    [Header("Player Setting")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 10, 30, 60, 100, 150, 210, 280, 360, 450, 600 }; //
    public int gold;
    public LevelUp uiLevelUp;
    public int totalGold;

    public float playerHelath;
    public float maxHelath = 100;

    public GameObject gameOverUI;
    public GameObject resultUI;
    public GameObject cleaner;

    public GameObject HUD;

    void Start()
    {
        if (PlayerPrefs.GetInt("CheckD") == 1)
        {
            maxHelath = 15;
        }
        else if (PlayerPrefs.GetInt("CheckD") ==2)
        {
            maxHelath = 20;
        }

        uiLevelUp.Select(1);
        playerHelath = maxHelath;
        Resume();

        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        AudioManager.instance.PlayBgm(true, 2);

    }
    void Awake()
    {
        instance = this;

        playerHelath = maxHelath;

        isLive = true;
        isCheck = false;
        isLevelUp = false;
    }


    IEnumerator GameOverRoutine()
    {
        isLive = false;

        yield return new WaitForSeconds(1.0f);
        resultUI.SetActive(true);
        HUD.SetActive(false);
        AudioManager.instance.PlayBgm(false);

        Stop();
    }
    IEnumerator GameClearRoutine()
    {
        isLive = false;
        isCheck = true;
        cleaner.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        resultUI.SetActive(true);
        HUD.SetActive(false);
        AudioManager.instance.PlayBgm(false);

        Stop();


    }

    public void GameRetry()
    {
        SceneManager.LoadScene(1);
        AudioManager.instance.PlayBgm(true, 1);

    }

    public void GameOver()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                AudioManager.instance.stage = 0;
                break;

            case 8:
                AudioManager.instance.stage = 1;
                break;

            default:
                AudioManager.instance.stage = 2;
                break;
        }

        StartCoroutine(GameOverRoutine());
        AudioManager.instance.PlayBgm(true, 1);
    }

    public void GameClear()
    {
        StartCoroutine(GameClearRoutine());
        AudioManager.instance.PlayBgm(true, 1);
        AudioManager.instance.stage = 0;
    }

    private void Update()
    {
        if (!isLive)
            return;

        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
            GameClear();
        }
    }
    // Start is called before the first frame update
    public void GetExp(int newExp)
    {
        if (isLive)
        {
            exp += newExp;

            if (PlayerPrefs.GetInt("PlayerCharacter") == 0)
            {
                exp += Mathf.FloorToInt(newExp * 0.5f);
            }

            Debug.Log("exp" + exp);
            if (exp >= nextExp[Mathf.Min(level, nextExp.Length - 1)])
            {
                level++;
                exp = 0;
                uiLevelUp.Show();
                isLevelUp = true;
            }
        }

    }
    public void GetGold(int totalGold)
    {
        if (isLive)
        {
            gold += totalGold;
        }
    }
    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;

    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }

}