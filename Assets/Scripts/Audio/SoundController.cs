using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSourceController
{
    AudioSource m_AudioSource;
    GameObject m_CurrentEntity;
    bool m_followEntity = true;
    AudioClip m_CurrentClip;

    public bool IsPlaying
    {
        get
        {
            return m_AudioSource.isPlaying;
        }
    }
    public AudioSourceController(AudioSource audioSource)
    {
        m_AudioSource = audioSource;
    }

    public AudioClip GetClip()
    {
        return m_CurrentClip;
    }

    public void PlayOneShot(GameObject entity, AudioClip soundClip, float volume, bool followEntity)
    {
        m_followEntity = followEntity;
        m_CurrentEntity = entity;
        m_CurrentClip = soundClip;
        m_AudioSource.transform.position = entity.transform.position;
        m_AudioSource.PlayOneShot(soundClip, volume);
    }

    public void PlayLooped(GameObject entity, AudioClip soundClip, float volume, bool followEntity)
    {
        m_followEntity = followEntity;
        m_CurrentEntity = entity;
        m_CurrentClip = soundClip;
        m_AudioSource.transform.position = entity.transform.position;
        m_AudioSource.clip = soundClip;
        m_AudioSource.volume = volume;
        m_AudioSource.loop = true;
        m_AudioSource.Play();
    }

    public void Stop()
    {
        m_AudioSource.Stop();
    }

    // maybe just change its parent is better than update the position every frame, don't know if changing the hierarchy cost a lot of perfomance
    public void Update()
    {
        if (m_AudioSource.isPlaying && m_CurrentEntity != null && m_followEntity)
        {
            m_AudioSource.transform.position = m_CurrentEntity.transform.position;
        }
    }
}

public class SoundController : MonoBehaviour
{
    public static SoundController Instance
    {
        get
        {
            if (s_Instance != null)
                return s_Instance;

            s_Instance = FindObjectOfType<SoundController>();

            return s_Instance;
        }
    }

    protected static SoundController s_Instance;

    //[SerializeField]
    //private Slider m_SFXSlider;

    //[SerializeField]
    //private float m_SFXVolume = 0.5f;

    //public float SFXVolume
    //{
    //    get { return m_SFXVolume; }
    //    set 
    //    { 
    //        m_SFXVolume = Mathf.Clamp01(value);
    //        if(VfxController.Instance) VfxController.Instance.PlayTickSound(gameObject);
    //    }
    //}

    [Space]
    [SerializeField]
    AudioMixerGroup m_Mixer;

    [Header("Audio Source 3D (with attenuation)")]
    [SerializeField]
    private AudioSource m_originalAudioSource3D = null;

    [SerializeField]
    private int m_MaxNumberOfAudioSource3D = 15;

    [Header("Audio Source 3D (without attenuation)")]
    [SerializeField]
    private AudioSource m_originalAudioSource2D = null;

    [SerializeField]
    private int m_MaxNumberOfAudioSource2D = 10;

    List<AudioSourceController> m_AudioSources3D;
    List<AudioSourceController> m_AudioSources2D;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        m_AudioSources3D = new List<AudioSourceController>();
        m_AudioSources2D = new List<AudioSourceController>();

        if (m_originalAudioSource3D)
        {
            CopyAudioSource(m_AudioSources3D, m_MaxNumberOfAudioSource3D, m_originalAudioSource3D, "_3D_AudioSource_");
        }

        if (m_originalAudioSource2D)
        {
            CopyAudioSource(m_AudioSources2D, m_MaxNumberOfAudioSource2D, m_originalAudioSource2D, "_2D_AudioSource_");
        }
    }

    private void CopyAudioSource(List<AudioSourceController> audioSources, int maxAudioSource, AudioSource originalAudioSource, string prefixName)
    {
        originalAudioSource.outputAudioMixerGroup = m_Mixer;
        for (int i = 0; i < m_MaxNumberOfAudioSource3D; i++)
        {
            GameObject audioObject = new GameObject(prefixName + (i + 1));
            audioObject.transform.parent = transform;
            AudioSource newAudioSource = CopyAudioSource(originalAudioSource, audioObject);
            AudioSourceController newSourceController = new AudioSourceController(newAudioSource);

            audioSources.Add(newSourceController);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (AudioSourceController sourceController in m_AudioSources3D)
        {
            sourceController.Update();
        }
        foreach (AudioSourceController sourceController in m_AudioSources2D)
        {
            sourceController.Update();
        }
    }

    public AudioSourceController PlaySound(AudioClip sound, GameObject entity, float volume = 1.0f, bool followEntity = true, bool loopSound = false)
    {
        if (sound == null)
        {
            // Au cas ou on tente de jouer un son null
            return null;
        }

        AudioSourceController sourceController = m_AudioSources3D.Find(x => !x.IsPlaying);
        if (sourceController != null)
        {
            if (loopSound)
            {
                sourceController.PlayLooped(entity, sound, volume, followEntity);
            }
            else
            {
                sourceController.PlayOneShot(entity, sound, volume, followEntity);
            }
        }
        return sourceController;
    }

    public AudioSourceController PlaySound2D(AudioClip sound, GameObject entity, float volume = 1.0f, bool followEntity = true)
    {
        if (sound == null)
        {
            // Au cas ou on tente de jouer un son null
            return null;
        }

        AudioSourceController sourceController = m_AudioSources2D.Find(x => !x.IsPlaying);
        if (sourceController != null)
        {
            sourceController.PlayOneShot(entity, sound, volume, followEntity);
        }
        return sourceController;
    }


    AudioSource CopyAudioSource(AudioSource original, GameObject destination)
    {
        AudioSource audioSource = destination.AddComponent<AudioSource>();

        audioSource.outputAudioMixerGroup = original.outputAudioMixerGroup;
        audioSource.bypassEffects = original.bypassEffects;
        audioSource.bypassListenerEffects = original.bypassListenerEffects;
        audioSource.bypassReverbZones = original.bypassReverbZones;
        audioSource.playOnAwake = original.playOnAwake;
        audioSource.loop = original.loop;
        audioSource.priority = original.priority;
        audioSource.volume = original.volume;
        audioSource.pitch = original.pitch;
        audioSource.panStereo = original.panStereo;
        audioSource.spatialBlend = original.spatialBlend;
        audioSource.reverbZoneMix = original.reverbZoneMix;
        audioSource.rolloffMode = original.rolloffMode;
        audioSource.maxDistance = original.maxDistance;
        audioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, original.GetCustomCurve(AudioSourceCurveType.CustomRolloff));
        audioSource.SetCustomCurve(AudioSourceCurveType.ReverbZoneMix, original.GetCustomCurve(AudioSourceCurveType.ReverbZoneMix));
        audioSource.SetCustomCurve(AudioSourceCurveType.SpatialBlend, original.GetCustomCurve(AudioSourceCurveType.SpatialBlend));
        audioSource.SetCustomCurve(AudioSourceCurveType.Spread, original.GetCustomCurve(AudioSourceCurveType.Spread));

        return audioSource;
    }
}
