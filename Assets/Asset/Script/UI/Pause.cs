using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false; // 초기값을 true로 설정
    public GameObject pauseMenu;
    public GameObject hp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // "Escape" 키로 수정
        {
            if (isPaused)
                ResumeGame(); // 일시정지일 때는 ResumeGame 호출
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true; // 일시정지 시 isPaused를 true로 설정
        hp.SetActive(false);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        if (!GameManager.instance.isLevelUp)
        {
            Time.timeScale = 1;
            hp.SetActive(true);
        }
    }

}