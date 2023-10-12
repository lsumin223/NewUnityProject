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

    private string[] info = {" �������� 10% ����մϴ�.",
        " �ӵ��� 5% ����մϴ�.",
    " ��Ÿ���� 2.5% �����մϴ�.",
    " �ִ�ü���� 20 ����մϴ�.",
    " ����ġ ȹ����� 10% ����մϴ�."};


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

}
