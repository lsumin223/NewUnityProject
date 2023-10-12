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
        SceneManager.LoadScene(0);
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        AudioManager.instance.PlayBgm(true, 1);
    }
}
