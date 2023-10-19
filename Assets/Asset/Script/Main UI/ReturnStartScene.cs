using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnStartScene : MonoBehaviour
{
    public int stageNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnToMain()
    {
        if (GameManager.instance.isCheck)
        {
            AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
            AudioManager.instance.PlayBgm(true, 1);
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("PlayerStage", stageNumber);

        }

        else if (!GameManager.instance.isCheck)
        {
            AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
            AudioManager.instance.PlayBgm(true, 1);
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

    }
}
