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

    public static GameManager instance;
    public PlayerController player;
    public PoolManager pool;
    public Spawner spawner;
    [Header("Player Setting")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 10, 30, 60, 100, 150, 210, 280, 360, 450, 600 }; //

    public LevelUp uiLevelUp;

    public float playerHelath;
    public float maxHelath = 100;

    public GameObject gameOverUI;
    public GameObject resultUI;
    public GameObject cleaner;

    public GameObject HUD;

    void Start()
    {
        uiLevelUp.Select(1);
        playerHelath = maxHelath;
        Resume();

        AudioManager.instance.PlayBgm(true, 2);
    }
    void Awake()
    {
        instance = this;
        playerHelath = maxHelath;
        isLive = true;
        isCheck = false;
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

        yield return new WaitForSeconds(1.0f);

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
        StartCoroutine(GameOverRoutine());
        AudioManager.instance.PlayBgm(true, 1);
    }

    public void GameClear()
    {
        StartCoroutine(GameClearRoutine());
        AudioManager.instance.PlayBgm(true, 1);
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
            if (exp >= nextExp[Mathf.Min(level, nextExp.Length - 1)])
            {
                level++;
                exp = 0;
                uiLevelUp.Show();
            }


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