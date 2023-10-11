using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onClickButton()
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("Main Scene"); 
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }

