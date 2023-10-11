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
        SceneManager.LoadScene("Start Scene");
    }

    public void onClickCustom(){
        SceneManager.LoadScene("Custom Scene");
    }

    public void onClickProductSelect(){
        SceneManager.LoadScene("ProductSelect Scene");
    }

    public void onClickData(){
        SceneManager.LoadScene("Data Scene");
    }

    public void onClickOption(){
        SceneManager.LoadScene("Option Scene");
    }
}
