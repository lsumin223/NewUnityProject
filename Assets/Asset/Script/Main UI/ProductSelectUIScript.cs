using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProductSelectUIScript : MonoBehaviour
{
    public Text characterInfoText;

    private int number;
    private int beforeNumber = 0;

    private string[] characterInfos = { " 기본 제품 입니다.",
        " 파워형 제품 입니다. ",
        " 쿨감형 제품 입니다. " };

    [SerializeField]
    private Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        characterInfoText = transform.Find("Character Information Text").GetComponent<Text>();

        if (PlayerPrefs.GetInt("PlayerCharacter") < 0 || PlayerPrefs.GetInt("PlayerCharacter") > 2)
        {
            number = 0;
            PlayerPrefs.SetInt("PlayerCharacter", 0);
        }
        else number = PlayerPrefs.GetInt("PlayerCharacter");

    }

    // Update is called once per frame
    void Update()
    {

            characterInfoText.text = characterInfos[number];
            Image buttonColor = buttons[number].GetComponent<Image>();
            Image beforeButton = buttons[beforeNumber].GetComponent<Image>();

            if (beforeButton != null)
            {
                beforeButton.color = Color.gray;
            }

            if (buttonColor != null)
            {
                buttonColor.color = new Color(186 / 255.0f, 208 / 250.0f, 1f, 1f);
            }


    }

    public void onClickUseButton()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        PlayerPrefs.SetInt("PlayerCharacter", number);
    }

    public void onClickBasicCharacter()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select2);
        beforeNumber = number;
        number = 0;
    }

    public void onClickPowerCharacter()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select2);
        beforeNumber = number;
        number = 1;
    }

    public void onClickCoolDownCharacter()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select2);
        beforeNumber = number;
        number = 2;
    }

    public void onClickBack()
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("Main Scene");

    }

}
