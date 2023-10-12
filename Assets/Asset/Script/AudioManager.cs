using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private Dictionary<Sfx, float> lastPlayTimeDictionary = new Dictionary<Sfx, float>();
    public float defaultCooldown = 0.5f; // �⺻ ����

    [Header("#BGM")]
    public AudioClip bgmClip1;
    public AudioClip bgmClip2;
    public float bgmVolume;
    AudioSource bgmPlayer;
    AudioHighPassFilter bgmEffect;

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
        if (instance == null)
        {
            instance = this;
            Init();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PlayBgm(true, 1);  // Start���� ȣ���ϵ��� ����
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

        // �ʱ� Ŭ�� ����
        if (bgmClip1 != null)
            bgmPlayer.clip = bgmClip1;
        else
            Debug.LogError("BgmClip1�� �ʱ�ȭ���� �ʾҽ��ϴ�.");

        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();

        // ȿ���� �÷��̾� �ʱ�ȭ
        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].bypassListenerEffects = true;
            sfxPlayers[index].volume = sfxVolume;
        }


    }

    public void PlayBgm(bool isPlay, int bgmIndex = 1)
    {
        if (isPlay)
        {
            if (bgmPlayer != null)  // null üũ �߰�
            {
                if (bgmIndex == 1)
                    bgmPlayer.clip = bgmClip1;
                else if (bgmIndex == 2)
                    bgmPlayer.clip = bgmClip2;

                bgmPlayer.Play();
            }
            else
            {
                Debug.LogError("BgmPlayer�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
            }
        }
        else
        {
            if (bgmPlayer != null)  // null üũ �߰�
            {
                bgmPlayer.Stop();
            }
            else
            {
                Debug.LogError("BgmPlayer�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
            }
        }
    }

    public void EffectBgm(bool isPlay)
    {
        bgmEffect.enabled = isPlay;
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

            if (sfx == Sfx.bullet)
            {
                sfxPlayers[loopIndex].volume = sfxVolume * 0.1f; // ���÷� ������ �������� ����
            }
            else
            {
                sfxPlayers[loopIndex].volume = sfxVolume; // �ٸ� ����� �⺻ �������� ����
            }

            sfxPlayers[loopIndex].clip = sfxClip[(int)sfx];
            sfxPlayers[loopIndex].Play();
            lastPlayTimeDictionary[sfx] = currentTime; // ����� �ð��� ���
            break;
        }

        sfxPlayers[0].clip = sfxClip[(int)sfx];
        sfxPlayers[0].Play();
    }
}