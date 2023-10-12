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

        {"감기","",""},
        {"알약", "파트너 봇",""},
        {"레시노", "아데노", "엔테로"},
        {"","","" }


    };

    private string[,] dataInfoTexts = new string[,]
    {

        {"인류의 희망이 되기 위한 위대한 첫 걸음!\n실험 대상은 감기환자이다.","",""},
        {"아플 때 늘 함께해온 친구의 모양을 본 떠 만든 장비", "몰려드는 바이러스로부터 지켜줄 든든한 파트너!", "" },
        {"기도 감염을 일으키는 바이러스","호흡기 감염을 일으키는 바이러스","다양한 종류의 감염을 일으키는 바이러스" },
        {"","","" },


    };

    private int selectedButtonIndex;

    // Start is called before the first frame update
    void Start()
    {

        selectedButtonIndex = 0;
        MakeButtonArray();

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
            int buttonIndex = i; // 클로저에서 사용하기 위해 별도의 변수에 저장
            dataButtons[i].onClick.AddListener(() => OnClickDataButton(buttonIndex));
        }
    }


    private void OnClickDataButton(int buttonIndex)
    {

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
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("Main Scene");
    }

    public void OnClickJournal()
    {
        scrollView.content.gameObject.SetActive(false);

        scrollView.content = contents[0].GetComponent<RectTransform>();

        contents[0].SetActive(true);

        selectedButtonIndex = 0;
        MakeButtonArray();

    }

    public void OnClickParts()
    {
        scrollView.content.gameObject.SetActive(false);

        scrollView.content = contents[1].GetComponent<RectTransform>();

        contents[1].SetActive(true);

        selectedButtonIndex = 1;
        MakeButtonArray();

    }

    public void OnClickVirus()
    {
        scrollView.content.gameObject.SetActive(false);

        scrollView.content = contents[2].GetComponent<RectTransform>();

        contents[2].SetActive(true);

        selectedButtonIndex = 2;
        MakeButtonArray();

    }

    public void OnClickBB()
    {
        scrollView.content.gameObject.SetActive(false);

        scrollView.content = contents[3].GetComponent<RectTransform>();

        contents[3].SetActive(true);

        selectedButtonIndex = 3;
        MakeButtonArray();

    }

    public void OnClickDataExit()
    {

        dataInfoPanel.SetActive(false);

    }
}
