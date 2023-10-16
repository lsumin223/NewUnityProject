using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Slider curHealth;
    Image thisImg;
    public Sprite changeImg;
    public Sprite OriginImg;

    private bool isCheck;


    private void Awake()
    {
        thisImg = GetComponent<Image>();
        isCheck = false;
    }

    void LateUpdate()
    {
        Debug.Log(isCheck);
        if (curHealth.value <= 0.5 && !isCheck)
        {
            ChangeImage();
        }
        else if(curHealth.value > 0.5 && isCheck)
        {
            ReturnImage();
        }

    }

    private void ChangeImage()
    {
        thisImg.sprite = changeImg;
        isCheck = true;
    }
    private void ReturnImage()
    {
        thisImg.sprite = OriginImg;
        isCheck = false;
    }
}
