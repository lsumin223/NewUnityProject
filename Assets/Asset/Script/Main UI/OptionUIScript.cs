using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickBack()
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("Main Scene");
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
    }
}
