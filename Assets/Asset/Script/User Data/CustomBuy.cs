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
                CustomSlider.value = PlayerPrefs.GetInt("CheckA") / 1f;
                break;

            case InfoType.B:
                break;

            case InfoType.C:
                break;

            case InfoType.D:
                break;

            case InfoType.E:
                break;

        }

    }
}
