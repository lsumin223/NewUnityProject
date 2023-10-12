using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUIScript : MonoBehaviour
{
    public Image stageImage;
    public Text stageNameText;
    public Text stageStoryText;

    [SerializeField]
    private Sprite[] stageSprites;


    private string[] stageName = { "1 스테이지", "2 스테이지" ,"3 스테이지"};

    private string[] stageStory = { " 1 스테이지 입니다.", " 2 스테이지 입니다.", " 3 스테이지 입니다."};



    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        stageImage = transform.Find("Stage Image").GetComponent<Image>();
        stageNameText = transform.Find("Stage Name Text").GetComponent<Text>();
        stageStoryText = transform.Find("Stage Story Text").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (stageImage.sprite != stageSprites[index])
        {
            stageImage.sprite = stageSprites[index];
            stageNameText.text = stageName[index];
            stageStoryText.text = stageStory[index];
        }

    }

    public void onClickBack()
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("Main Scene");
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
    }

    public void onClickNextStage()
    {
        index++;
        if (index >= stageSprites.Length)
        {
            index = 0;
            AudioManager.instance.Playsfx(AudioManager.Sfx.select1);

        }



    }

    public void onClickBackStage()
    {
        index--;
        if (index < 0)
        {
            index = stageSprites.Length - 1;
            AudioManager.instance.Playsfx(AudioManager.Sfx.select1);

        }


    }

    public void onClickStartButton()
    {

        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("SampleScene");
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);


        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }


    }


}
