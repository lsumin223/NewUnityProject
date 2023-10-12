using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioSliderControl : MonoBehaviour
{
    public Slider volumeBGM;
    public Slider volumeSFX;
    public Toggle dmgToggle;

    private void Awake()
    {
        dmgToggle.isOn = AudioManager.instance.isDamText;
    }
    private void Start()
    {
        volumeBGM.value = AudioManager.instance.bgmVolume;
        volumeSFX.value = AudioManager.instance.sfxVolume;
    }


    public void BGMVolume()
    {
        AudioManager.instance.BGMVolume(volumeBGM.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(volumeSFX.value);
    }

    public void ToggleDamage(bool value)
    {
        if(value)
            AudioManager.instance.isDamText = value;
        else
            AudioManager.instance.isDamText = value;

        Debug.Log(AudioManager.instance.isDamText);
    }

}