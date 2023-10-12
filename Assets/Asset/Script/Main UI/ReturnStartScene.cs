using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnStartScene : MonoBehaviour
{

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
            SceneManager.LoadScene(0);
        }
            
        else if (!GameManager.instance.isCheck)
        {
            SceneManager.LoadScene(2);
        }
        
    }
}
