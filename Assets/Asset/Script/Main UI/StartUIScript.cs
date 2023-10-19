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
    public Button startButton;
    private int clearedStage;

    [SerializeField]
    private Sprite[] stageSprites;


    private string[] stageName = { "������", "����", "�Ƿ��� ��ȸ" };

    private string[] stageStory = { "�ӻ���� ����! �� �κ��� �� ������ ���� �� ���� ���̴�.",
        " �ҹ��� ��� �ƴ� ģ���� �ƴ� ������ �ƴ� ������ �ƴ� ���Ѻο��� ġ�� ��û�� �Դ�.",
        " ���Ѻθ� ġ���ߴٴ� ��縦 ���� ��ȸ���� ���� ����ʹٰ� ��û�� ���´�." };



    private int index = 0;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("PlayerStage") < 0 || PlayerPrefs.GetInt("PlayerStage") > 2)
        {
            clearedStage = 0;
            PlayerPrefs.SetInt("PlayerStage", 0);
        }
        else clearedStage = PlayerPrefs.GetInt("PlayerStage");
    }

    // Start is called before the first frame update
    void Start()
    {
        index = AudioManager.instance.stage;

        Debug.Log(AudioManager.instance.stage);
        stageImage = transform.Find("Stage Image").GetComponent<Image>();
        stageNameText = transform.Find("Stage Name Text").GetComponent<Text>();
        stageStoryText = transform.Find("Stage Story Text").GetComponent<Text>();
        startButton = transform.Find("Start Button").GetComponent<Button>();
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

        if (index > clearedStage)
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;
        }
    }

    public void onClickBack()
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("Main Scene");
    }

    public void onClickNextStage()
    {
        index++;
        if (index >= stageSprites.Length)
        {
            index = 0;
        }



    }

    public void onClickBackStage()
    {
        index--;
        if (index < 0)
        {
            index = stageSprites.Length - 1;
        }


    }

    public void onClickStartButton()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        Resources.UnloadUnusedAssets();
        switch (index)
        {
            case 0:
                SceneManager.LoadScene("SampleScene");
                break;
            case 1:
                SceneManager.LoadScene(8);
                break;
            case 2:
                break;
        }



    }


}
