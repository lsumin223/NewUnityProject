using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProductSelectUIScript : MonoBehaviour
{
    public Text characterInfoText;

    private int number = 0;
    private int beforeNumber = 0;

    private string[] characterInfos = { " 기본 제품 입니다.",
        " 파워형 제품 입니다. (구현 예정)",
        " 스피드형 제품 입니다. (구현 예정)",
        " 쿨감형 제품 입니다. (구현 예정)" };

    [SerializeField]
    private Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {

        characterInfoText = transform.Find("Character Information Text").GetComponent<Text>();

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

    public void onClickBasicCharacter()
    {
        beforeNumber = number;
        number = 0;
    }

    public void onClickPowerCharacter()
    {
        beforeNumber = number;
        number = 1;
    }

    public void onClickSpeedCharacter()
    {
        beforeNumber = number;
        number = 2;
    }

    public void onClickCoolDownCharacter()
    {
        beforeNumber = number;
        number = 3;
    }

    public void onClickBack()
    {

        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("Main Scene");

    }

}
