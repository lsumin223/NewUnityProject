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

    private string[] info = {" �������� 10% ����մϴ�. 3000G ",
        " �ӵ��� 10% ����մϴ�. 3000G",
    " ��Ÿ���� 10% �����մϴ�. 3000G" ,
    " �ִ�ü���� 50% ����մϴ�. 3000G",
    " ����ġ ȹ����� 10% ����մϴ�. 3000G"};


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
         PlayerPrefs.SetInt("CheckE", 0); */ //�������� �ʱ�ȭ
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
        // ��� Toggle�� ��ȸ�ϸ鼭 ���õ� Toggle ã��
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                // ���õ� Toggle�� ������ ������ ����
                selectedToggleIndex = i;

                // ���õ� Toggle�� ������ ����� �� ����
                Debug.Log($"Selected Toggle Index: {selectedToggleIndex}");
                break; // ���õ� Toggle�� ã�����Ƿ� ���� ����
            }
        }
    }

    public int BuyA;
    public int BuyB;
    public int BuyC;
    public int BuyD;
    public int BuyE;


    public void Buy() //Ŀ���� �ɷ�ġ ���� ��� ����
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

    public void ReSetItem() // ��������ư ������ �����Ѱ� ����(��ȭ ��������)
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
