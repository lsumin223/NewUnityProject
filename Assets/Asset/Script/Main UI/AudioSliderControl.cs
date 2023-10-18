using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioSliderControl : MonoBehaviour
{
    public Slider volumeBGM;
    public Slider volumeSFX;
    public Toggle dmgToggle;
    public Toggle effectToggle;

    private void Awake()
    {
        dmgToggle.isOn = !AudioManager.instance.isDamText;
        effectToggle.isOn = !AudioManager.instance.isEffOn;
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
        AudioManager.instance.Playsfx(AudioManager.Sfx.select2);
        AudioManager.instance.isDamText = !value;
    }

    public void ToggleEffect(bool value)
    {
        AudioManager.instance.Playsfx(AudioManager.Sfx.select2);
        AudioManager.instance.isEffOn = !value;
    }

}