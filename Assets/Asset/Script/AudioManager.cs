using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private Dictionary<Sfx, float> lastPlayTimeDictionary = new Dictionary<Sfx, float>();
    public float defaultCooldown = 0.5f; // �⺻ ����

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex; // channel index

    public enum Sfx
    {
        levelUp, dead, select1, select2, bullet, hit, kill, playerHit
    }

    void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
        // ����� �÷��̾� �ʱ�ȭ
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        // ȿ���� �÷��̾� �ʱ�ȭ
        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
        }


    }

    public void Playsfx(Sfx sfx)
    {

        float currentTime = Time.time;

        if (lastPlayTimeDictionary.ContainsKey(sfx) && currentTime - lastPlayTimeDictionary[sfx] < defaultCooldown)
        {
            // ������ �������� ������ �ƹ� �͵� ���� ����
            return;
        }


        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClip[(int)sfx];
            sfxPlayers[loopIndex].Play();
            lastPlayTimeDictionary[sfx] = currentTime; // ����� �ð��� ���
            break;
        }

        sfxPlayers[0].clip = sfxClip[(int)sfx];
        sfxPlayers[0].Play();
    }
}