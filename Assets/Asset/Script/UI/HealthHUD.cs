using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Slider curHealth;
    Image thisImg;
    public Sprite changeImg;

    private GameObject healthBar;

    private void Awake()
    {
        thisImg = GetComponent<Image>();
        healthBar = GetComponent<GameObject>();
    }

    void LateUpdate()
    {
        if (curHealth.value <=0.5)
        {
            ChangeImage();
        }

        if(curHealth.value <= 0)
        {
            healthBar.SetActive(false);
        }

    }

    private void ChangeImage()
    {
        thisImg.sprite = changeImg;
    }
}
