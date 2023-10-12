using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomUIScript : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public Text customInfoText;
    public Toggle[] toggles;

    private int selectedToggleIndex = -1;

    private string[] info = {" 데미지가 10% 상승합니다.",
        " 속도가 5% 상승합니다.",
    " 쿨타임이 2.5% 감소합니다.",
    " 최대체력이 20 상승합니다.",
    " 경험치 획득률이 10% 상승합니다."};


    // Start is called before the first frame update
    void Start()
    {

        UpdateSelectedToggle();
        customInfoText = transform.Find("Custom Info Text").GetComponent<Text>();
        toggles = toggleGroup.GetComponentsInChildren<Toggle>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickBack()
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("Main Scene");
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);
    }

    public void OnClickToggle()
    {
        UpdateSelectedToggle();
        if(selectedToggleIndex == -1)
        {
            customInfoText.text = "";
        }
        else customInfoText.text = info[selectedToggleIndex];
        AudioManager.instance.Playsfx(AudioManager.Sfx.select1);

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

}
