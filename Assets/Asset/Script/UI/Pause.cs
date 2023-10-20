using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false; // �ʱⰪ�� true�� ����
    public GameObject pauseMenu;
    public GameObject hp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // "Escape" Ű�� ����
        {
            if (isPaused)
                ResumeGame(); // �Ͻ������� ���� ResumeGame ȣ��
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        if (GameManager.instance.isLive)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            isPaused = true; // �Ͻ����� �� isPaused�� true�� ����
            hp.SetActive(false);
            Time.timeScale = 0;
        }
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
        else if (GameManager.instance.isLevelUp)
        {
            Time.timeScale = 0;
            hp.SetActive(false);
        }
    }

}