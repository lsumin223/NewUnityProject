using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private Dictionary<Sfx, float> lastPlayTimeDictionary = new Dictionary<Sfx, float>();
    public float defaultCooldown = 0.5f; // 기본 간격

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
        PlayBgm(true, 1);  // Start에서 호출하도록 변경
    }

    void Init()
    {
        // 배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;

        // 초기 클립 설정
        if (bgmClip1 != null)
            bgmPlayer.clip = bgmClip1;
        else
            Debug.LogError("BgmClip1이 초기화되지 않았습니다.");

        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();

        // 효과음 플레이어 초기화
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
            if (bgmPlayer != null)  // null 체크 추가
            {
                if (bgmIndex == 1)
                    bgmPlayer.clip = bgmClip1;
                else if (bgmIndex == 2)
                    bgmPlayer.clip = bgmClip2;

                bgmPlayer.Play();
            }
            else
            {
                Debug.LogError("BgmPlayer가 초기화되지 않았습니다.");
            }
        }
        else
        {
            if (bgmPlayer != null)  // null 체크 추가
            {
                bgmPlayer.Stop();
            }
            else
            {
                Debug.LogError("BgmPlayer가 초기화되지 않았습니다.");
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
            // 간격이 충족되지 않으면 아무 것도 하지 않음
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
                sfxPlayers[loopIndex].volume = sfxVolume * 0.1f; // 예시로 볼륨을 절반으로 설정
            }
            else
            {
                sfxPlayers[loopIndex].volume = sfxVolume; // 다른 사운드는 기본 볼륨으로 설정
            }

            sfxPlayers[loopIndex].clip = sfxClip[(int)sfx];
            sfxPlayers[loopIndex].Play();
            lastPlayTimeDictionary[sfx] = currentTime; // 재생한 시간을 기록
            break;
        }

        sfxPlayers[0].clip = sfxClip[(int)sfx];
        sfxPlayers[0].Play();
    }
}