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
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true; // �Ͻ����� �� isPaused�� true�� ����
        hp.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
        hp.SetActive(true);
    }
}