using UnityEngine;
using System;


public class AudioManager : MonoBehaviour
{
    public enum SoundType
    {
        MENU,
        GAME,
        SHOT,
        SHOT_BALLISTIC,
        HIT,
        PLACE
    }

    public static AudioManager Instance { get; private set; }

    [SerializeField]
    private Sound[] sounds;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();

            s.audioSource.playOnAwake = false;

            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.loop;
            s.audioSource.mute = s.mute;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Play(SoundType soundType)
    {
        Sound s = Array.Find(sounds, sound => sound.soundType == soundType);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }
        Debug.Log(s.audioSource);
        s.audioSource.Play();
    }

    public void Stop(SoundType soundType)
    {
        Sound s = Array.Find(sounds, sound => sound.soundType == soundType);
        if (s == null)
        {
            Debug.LogWarning("Sound not found");
            return;
        }
        s.audioSource.Stop();
    }
}
