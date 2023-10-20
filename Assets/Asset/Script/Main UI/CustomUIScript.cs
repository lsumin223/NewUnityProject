using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CustomUIScript : MonoBehaviour
{
    public static CustomUIScript instance;
    public int BuyCoin;
    public ToggleGroup toggleGroup;
    public Text customInfoText;
    public Toggle[] toggles;
    public int i;
    private int selectedToggleIndex = -1;

    private string[] info = {" 데미지가 10% 상승합니다. 3000G ",
        " 속도가 10% 상승합니다. 3000G",
    " 쿨타임이 10% 감소합니다. 3000G" ,
    " 최대체력이 50% 상승합니다. 3000G",
    " 경험치 획득률이 10% 상승합니다. 3000G"};


    // Start is called before the first frame update
    void Start()
    {

        UpdateSelectedToggle();
        customInfoText = transform.Find("Custom Info Text").GetComponent<Text>();
        toggles = toggleGroup.GetComponentsInChildren<Toggle>();

     /*   PlayerPrefs.SetInt("PlayerGold", 100000);
        PlayerPrefs.SetInt("CheckA", 0);
         PlayerPrefs.SetInt("CheckB", 0);
         PlayerPrefs.SetInt("CheckC", 0);
         PlayerPrefs.SetInt("CheckD", 0);
         PlayerPrefs.SetInt("CheckE", 0); */ //상점구매 초기화
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickBack()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("Main Scene");
    }

    public void OnClickToggle()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select2);
        UpdateSelectedToggle();
        if (selectedToggleIndex == -1)
        {
            customInfoText.text = "";
        }
        else customInfoText.text = info[selectedToggleIndex];

    }

    private void UpdateSelectedToggle()
    {
        selectedToggleIndex = -1;
        // 모든 Toggle을 순회하면서 선택된 Toggle 찾기
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                // 선택된 Toggle의 순서를 변수에 저장
                selectedToggleIndex = i;

                // 선택된 Toggle의 정보를 사용할 수 있음
                Debug.Log($"Selected Toggle Index: {selectedToggleIndex}");
                break; // 선택된 Toggle을 찾았으므로 루프 종료
            }
        }
    }

    public int BuyA;
    public int BuyB;
    public int BuyC;
    public int BuyD;
    public int BuyE;


    public void Buy() //커스텀 능력치 구매 기록 저장
    {
      
        
        if (PlayerPrefs.GetInt("CheckA") <= 1)
        {
            if (PlayerPrefs.GetInt("PlayerGold") > PlayerPrefs.GetInt("ItemA") && toggles[0].isOn)
            {
                PlayerPrefs.SetInt("ItemA", 3000);
                BuyCoin = PlayerPrefs.GetInt("PlayerGold") - PlayerPrefs.GetInt("ItemA");
                PlayerPrefs.SetInt("PlayerGold", BuyCoin);
                BuyA = 1+PlayerPrefs.GetInt("CheckA");
                PlayerPrefs.SetInt("CheckA", BuyA);

            }
        }
        if (PlayerPrefs.GetInt("CheckB") <= 1)
        {

            if (PlayerPrefs.GetInt("PlayerGold") > PlayerPrefs.GetInt("ItemB") && toggles[1].isOn)
            {
                PlayerPrefs.SetInt("ItemB", 3000);
                BuyCoin = PlayerPrefs.GetInt("PlayerGold") - PlayerPrefs.GetInt("ItemB");
                PlayerPrefs.SetInt("PlayerGold", BuyCoin);
                BuyB = 1 + PlayerPrefs.GetInt("CheckB"); 
                PlayerPrefs.SetInt("CheckB", BuyB);

            }
        }

        if (PlayerPrefs.GetInt("CheckC") <= 1)
        {
            if (PlayerPrefs.GetInt("PlayerGold") > PlayerPrefs.GetInt("ItemC") && toggles[2].isOn)
            {
                PlayerPrefs.SetInt("ItemC", 3000);
                BuyCoin = PlayerPrefs.GetInt("PlayerGold") - PlayerPrefs.GetInt("ItemC");
                PlayerPrefs.SetInt("PlayerGold", BuyCoin);
                BuyC = 1 + PlayerPrefs.GetInt("CheckC"); 
                PlayerPrefs.SetInt("CheckC", BuyC);
            }
        }
        if (PlayerPrefs.GetInt("CheckD") <= 1)
        {
            if (PlayerPrefs.GetInt("PlayerGold") > PlayerPrefs.GetInt("ItemD") && toggles[3].isOn)
            {
                PlayerPrefs.SetInt("ItemD", 3000);
                BuyCoin = PlayerPrefs.GetInt("PlayerGold") - PlayerPrefs.GetInt("ItemD");
                PlayerPrefs.SetInt("PlayerGold", BuyCoin);
                BuyD = 1 + PlayerPrefs.GetInt("CheckD");
                PlayerPrefs.SetInt("CheckD", BuyD);
            }
        }
        if (PlayerPrefs.GetInt("CheckE") <= 1)
        {
            if (PlayerPrefs.GetInt("PlayerGold") > PlayerPrefs.GetInt("ItemE") && toggles[4].isOn)
            {
                PlayerPrefs.SetInt("ItemE", 3000);
                BuyCoin = PlayerPrefs.GetInt("PlayerGold") - PlayerPrefs.GetInt("ItemE");
                PlayerPrefs.SetInt("PlayerGold", BuyCoin);
                BuyE = 1 + PlayerPrefs.GetInt("CheckE");
                PlayerPrefs.SetInt("CheckE", BuyE);
            }
        }
    }

    public void ReSetItem() // 재조립버튼 누르면 구매한거 리셋(재화 돌려받음)
    {
        if ( PlayerPrefs.GetInt("CheckA") >=1)
        {
            PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") + PlayerPrefs.GetInt("ItemA")*PlayerPrefs.GetInt("CheckA"));
            PlayerPrefs.SetInt("CheckA", 0);

        }
        if (PlayerPrefs.GetInt("CheckB") >= 1)
        {

            PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") + PlayerPrefs.GetInt("ItemB") * PlayerPrefs.GetInt("CheckB"));
            PlayerPrefs.SetInt("CheckB", 0);

        }
        if (PlayerPrefs.GetInt("CheckC") >= 1)
        {
            PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") + PlayerPrefs.GetInt("ItemC") * PlayerPrefs.GetInt("CheckC"));
            PlayerPrefs.SetInt("CheckC", 0);

        }
        if (PlayerPrefs.GetInt("CheckD") >= 1)
        {
            PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") + PlayerPrefs.GetInt("ItemD") * PlayerPrefs.GetInt("CheckD"));
            PlayerPrefs.SetInt("CheckD", 0);

        }
        if (PlayerPrefs.GetInt("CheckE") >= 1)
        {
            PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") + PlayerPrefs.GetInt("ItemE") * PlayerPrefs.GetInt("CheckE"));
            PlayerPrefs.SetInt("CheckE", 0);

        }
    }
}
