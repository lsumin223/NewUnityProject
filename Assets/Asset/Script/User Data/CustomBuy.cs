using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomBuy : MonoBehaviour
{
    public enum InfoType { A,B,C,D,E }
    public InfoType type;
    Slider CustomSlider;
    private void Awake()
    {
        CustomSlider = GetComponent<Slider>();
    }
    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.A:
                CustomSlider.value = PlayerPrefs.GetInt("CheckA") / 2f;
                break;

            case InfoType.B:
                CustomSlider.value = PlayerPrefs.GetInt("CheckB") / 2f;
                break;


            case InfoType.C:
                CustomSlider.value = PlayerPrefs.GetInt("CheckC") / 2f;
                break;

            case InfoType.D:
                CustomSlider.value = PlayerPrefs.GetInt("CheckD") / 2f;
                break;

            case InfoType.E:
                CustomSlider.value = PlayerPrefs.GetInt("CheckE") / 2f;
                break;

        }

    }
}
