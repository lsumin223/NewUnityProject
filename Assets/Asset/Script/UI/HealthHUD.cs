using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Slider curHealth;
    Image thisImg;
    public Sprite changeImg;

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

    }

    private void ChangeImage()
    {
        thisImg.sprite = changeImg;
    }
}
