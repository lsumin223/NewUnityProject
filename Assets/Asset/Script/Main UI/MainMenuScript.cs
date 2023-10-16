using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickStart(){
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        SceneManager.LoadScene("Start Scene");
    }

    public void onClickCustom(){
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        SceneManager.LoadScene("Custom Scene");
    }

    public void onClickProductSelect(){
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        SceneManager.LoadScene("ProductSelect Scene");
    }

    public void onClickData(){
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        SceneManager.LoadScene("Data Scene");
    }

    public void onClickOption(){
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        SceneManager.LoadScene("Option Scene");
    }
    public void onClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
