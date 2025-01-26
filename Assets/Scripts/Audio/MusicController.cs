using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;

public class MusicController : MonoBehaviour
{
    static MusicController _instance;
    public static MusicController Instance {get {return _instance;}}


    [SerializeField]
    AudioMixerGroup m_MusicOutput;
    [SerializeField]
    AudioClip m_CurrentMusic;
    [SerializeField]
    bool musicPlayOnAwake = true;
    [SerializeField]
    float musicDelay = 0;
    [SerializeField, Range(0f, 1f)]
    float musicVolume = 1f;

    float m_CurrentVolume;

    protected AudioSource[] m_MusicAudioSource = new AudioSource[2];
    int m_CurrentMusicSource = 0;

    protected bool m_TransferMusicTime;

    bool m_WasPlayingMusic = false;

    void Awake()
    {
        m_CurrentVolume = musicVolume;


        _instance = this;

        for (int i = 0; i < 2; i++)
        {
            m_MusicAudioSource[i] = gameObject.AddComponent<AudioSource>();
            m_MusicAudioSource[i].priority = 1;
            m_MusicAudioSource[i].playOnAwake = false;
            m_MusicAudioSource[i].clip = m_CurrentMusic;
            m_MusicAudioSource[i].outputAudioMixerGroup = m_MusicOutput;
            m_MusicAudioSource[i].loop = false;
            m_MusicAudioSource[i].volume = musicVolume;
        }

        if (musicPlayOnAwake)
        {
            PlayMusic(m_CurrentMusic, true, 1.0f + musicDelay);
        }
    }


    private void Update()
    {
        //isPlaying will be false once the current clip end up playing
        if (m_WasPlayingMusic && (!m_MusicAudioSource[0].isPlaying || !m_MusicAudioSource[1].isPlaying))
        {
            //Back to looping music clip
            RescheduleLoopingMusic();
        }
    }
    void RescheduleLoopingMusic()
    {
        if (m_MusicAudioSource[m_CurrentMusicSource].isPlaying)
        {
            return;
        }
        double dspTime = AudioSettings.dspTime;
        //LES VALEURS EN DUR !!!
        double loopStart = 17.77;
        if (loopStart >= 0)
        {
            dspTime -= loopStart;
            m_MusicAudioSource[m_CurrentMusicSource].time = (float)loopStart;
        }

        double loopEnd = 90.66;
        if (loopEnd >= 0)
        {
            dspTime += loopEnd;
        }

        dspTime -= m_MusicAudioSource[m_CurrentMusicSource == 0 ? 1 : 0].time - loopStart;

        m_MusicAudioSource[m_CurrentMusicSource == 0 ? 1 : 0].volume = m_CurrentVolume;
        m_MusicAudioSource[m_CurrentMusicSource].volume = m_CurrentVolume / 4;
        m_MusicAudioSource[m_CurrentMusicSource].PlayScheduled(dspTime);
        m_MusicAudioSource[m_CurrentMusicSource].SetScheduledEndTime(dspTime - loopStart + loopEnd);
        m_CurrentMusicSource = m_CurrentMusicSource == 0 ? 1 : 0;
    }
    void PlayMusic(AudioClip music, bool intro, float delay = 0.0f)
    {
        double loopStart = 17.77;
        double loopEnd = 90.66;

        m_CurrentMusicSource = m_CurrentMusicSource == 0 ? 1 : 0;
        double dspTime = AudioSettings.dspTime + delay;
        if (m_MusicAudioSource[0].clip != music)
        {
            m_MusicAudioSource[0].clip = music;
            m_MusicAudioSource[0].time = 0f;
        }
        if (m_MusicAudioSource[1].clip != music)
        {
            m_MusicAudioSource[1].clip = music;
            m_MusicAudioSource[1].time = 0f;
        }

        if (!intro && loopStart >= 0)
        {
            m_MusicAudioSource[m_CurrentMusicSource].time = (float)loopStart;
        }

        m_MusicAudioSource[m_CurrentMusicSource].PlayScheduled(dspTime);

        if (loopEnd >= 0)
        {
            double endTime = dspTime - loopStart + loopEnd;
            m_MusicAudioSource[m_CurrentMusicSource].SetScheduledEndTime(endTime);
            if (loopStart >= 0)
            {
                m_MusicAudioSource[m_CurrentMusicSource == 0 ? 1 : 0].time = (float)loopStart;
            }
            m_MusicAudioSource[m_CurrentMusicSource == 0 ? 1 : 0].volume = m_CurrentVolume / 4;
            m_MusicAudioSource[m_CurrentMusicSource == 0 ? 1 : 0].PlayScheduled(endTime);
            m_MusicAudioSource[m_CurrentMusicSource == 0 ? 1 : 0].SetScheduledEndTime(endTime - loopStart + loopEnd);
        }

        m_WasPlayingMusic = true;
    }



    public void Play(bool skipIntro = false)
    {
        PlayJustMusic(skipIntro);
    }

    public void PlayJustMusic(bool skipIntro = false)
    {
        PlayMusic(m_CurrentMusic, !skipIntro);
    }

    public void Stop()
    {
        StopJustMusic();
    }

    public void StopJustMusic()
    {
        m_MusicAudioSource[0].Stop();
        m_MusicAudioSource[1].Stop();
        m_WasPlayingMusic = false;
    }

    public void Mute()
    {
        MuteJustMusic();
    }

    public void MuteJustMusic()
    {
        m_CurrentVolume = 0;
        m_MusicAudioSource[0].volume = m_CurrentVolume;
        m_MusicAudioSource[1].volume = m_CurrentVolume;
    }

    public void OpenMenu()
    {
        m_CurrentVolume = musicVolume / 2.0f;
        m_MusicAudioSource[0].volume = m_CurrentVolume;
        m_MusicAudioSource[1].volume = m_CurrentVolume;
    }

    public void CloseMenu()
    {
        m_CurrentVolume = musicVolume;
        m_MusicAudioSource[0].volume = m_CurrentVolume;
        m_MusicAudioSource[1].volume = m_CurrentVolume;
    }

    public void Unmute()
    {
        UnmuteJustMustic();
    }

    public void UnmuteJustMustic()
    {
        m_CurrentVolume = musicVolume;
        m_MusicAudioSource[0].volume = m_CurrentVolume;
        m_MusicAudioSource[1].volume = m_CurrentVolume;
    }

    public void Mute(float fadeTime)
    {
        MuteJustMusic(fadeTime);
    }

    public void MuteJustMusic(float fadeTime)
    {
        m_CurrentVolume = 0;
        m_MusicAudioSource[0].DOKill();
        m_MusicAudioSource[1].DOKill();
        m_MusicAudioSource[0].DOFade(m_CurrentVolume, fadeTime).SetUpdate(true);
        m_MusicAudioSource[1].DOFade(m_CurrentVolume, fadeTime).SetUpdate(true);
        //StartCoroutine(VolumeFade(m_MusicAudioSource[0], 0f, fadeTime));
        //StartCoroutine(VolumeFade(m_MusicAudioSource[1], 0f, fadeTime));
    }

    public void Unmute(float fadeTime)
    {
        UnmuteJustMusic(fadeTime);
    }

    public void UnmuteJustMusic(float fadeTime)
    {
        m_CurrentVolume = musicVolume;
        m_MusicAudioSource[0].DOKill();
        m_MusicAudioSource[1].DOKill();
        m_MusicAudioSource[0].DOFade(m_CurrentVolume, fadeTime).SetUpdate(true);
        m_MusicAudioSource[1].DOFade(m_CurrentVolume, fadeTime).SetUpdate(true);
        //StartCoroutine(VolumeFade(m_MusicAudioSource[0], musicVolume, fadeTime));
        //StartCoroutine(VolumeFade(m_MusicAudioSource[1], musicVolume, fadeTime));
    }
    
    public bool IsMusicPlaying()
    {
        return m_MusicAudioSource[0].isPlaying && m_MusicAudioSource[0].volume > 0f
                && m_MusicAudioSource[1].isPlaying && m_MusicAudioSource[1].volume > 0f;
    }
}
