using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Slider curHealth;
    Image thisImg;
    public Sprite changeImg;
    public Sprite originImg;

    private void Awake()
    {
        thisImg = GetComponent<Image>();
    }

    void LateUpdate()
    {
        if (curHealth.value <=0.5)
        {
            ChangeImage();
        }
        else if (curHealth.value > 0.5)
        {
            ReturnImage();
        }
    }

    private void ChangeImage()
    {
        thisImg.sprite = changeImg;
    }

    private void ReturnImage()
    {
        thisImg.sprite = originImg;
    }
}
