using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataUIScript : MonoBehaviour
{
    public ScrollRect scrollView;
    public GameObject dataInfoPanel;

    [SerializeField]
    private GameObject[] contents;

    private Button[] dataButtons;

    public Image dataImage;
    public Text dataInfo;
    public Text dataName;

    private string[,] dataNameTexts = new string[,]
    {

        {"����","���� ����","",""},
        {"�˾�", "������","�濪","�޽�"},
        {"���ó�", "�Ƶ���", "���׷�","�����"},
        {"","","",""}


    };

    private string[,] dataInfoTexts = new string[,]
    {

        {"�η��� ����� �Ǳ� ���� ������ ù ����!\n���� ����� ���� ���̷����̴�.","���Ѻ� ���� ���� ������ ������ ���� ������!\nȯ���� �ǰ����°� �ſ� ��������.","",""},
        {"���� �� �� �Բ��ؿ� ģ���� ����� �� �� ���� ���", "�츮 ���� �鿪�� å������ ����� ģ��!", "� ���� ����� ������ �ٰ� ������� �װ�","�����ϸ� ���� ���� �������� �ǻ���� ����" },
        {"�⵵ ������ ����Ű�� ���̷���","ȣ��� ������ ����Ű�� ���̷���","�پ��� ������ ������ ����Ű�� ���̷���","����ī �ܵ��� �ϸ����� ��ī��, �� ����� ������ �״� �� ����" },
        {"","","","" },


    };

    private int selectedButtonIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MakeButtonArray()
    {
        dataButtons = contents[selectedButtonIndex].GetComponentsInChildren<Button>();

        for (int i = 0; i < dataButtons.Length; i++)
        {
            int buttonIndex = i; // Ŭ�������� ����ϱ� ���� ������ ������ ����
            dataButtons[i].onClick.AddListener(() => OnClickDataButton(buttonIndex));
        }
    }


    private void OnClickDataButton(int buttonIndex)
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select2);

        RectTransform buttonRectTransform = dataButtons[buttonIndex].GetComponent<RectTransform>();
        RectTransform imageRectTransform = dataImage.GetComponent<RectTransform>();
        imageRectTransform.sizeDelta = buttonRectTransform.sizeDelta;


        dataImage.sprite = dataButtons[buttonIndex].GetComponent<Image>().sprite;
        
        dataInfo.text = dataInfoTexts[selectedButtonIndex, buttonIndex];
        dataName.text = dataNameTexts[selectedButtonIndex, buttonIndex];

        dataInfoPanel.SetActive(true);

    }

    public void OnClickBack()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("Main Scene");
    }

    public void OnClickJournal()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        scrollView.content.gameObject.SetActive(false);

        scrollView.content = contents[0].GetComponent<RectTransform>();

        contents[0].SetActive(true);

        selectedButtonIndex = 0;
        MakeButtonArray();

    }

    public void OnClickParts()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        scrollView.content.gameObject.SetActive(false);

        scrollView.content = contents[1].GetComponent<RectTransform>();

        contents[1].SetActive(true);

        selectedButtonIndex = 1;
        MakeButtonArray();

    }

    public void OnClickVirus()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        scrollView.content.gameObject.SetActive(false);

        scrollView.content = contents[2].GetComponent<RectTransform>();

        contents[2].SetActive(true);

        selectedButtonIndex = 2;
        MakeButtonArray();

    }

    public void OnClickBB()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        scrollView.content.gameObject.SetActive(false);

        scrollView.content = contents[3].GetComponent<RectTransform>();

        contents[3].SetActive(true);

        selectedButtonIndex = 3;
        MakeButtonArray();

    }

    public void OnClickDataExit()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        dataInfoPanel.SetActive(false);

    }
}
