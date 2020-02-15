using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	
	public static AudioManager instance = null;

	AudioSource[] audioSources;
	AudioData AUDIO;

    [SerializeField]
    AudioSource backgroundSource;

    enum SOURCES
    {
        GENERIC
    }

    #region Mono
    void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
        SetupAudioSources();
		SetupVariable ();

	}

    private void Start()
    {
        playRandomBackground();
    }

    void playRandomBackground()
    {
        int index = UnityEngine.Random.Range(0, AUDIO.BackgroundMusic.Length);
        backgroundSource.clip = AUDIO.BackgroundMusic[index];
        backgroundSource.loop = true;
        backgroundSource.volume = 0.75f;
        backgroundSource.Play();
    }

    void SetupAudioSources()
    {
        int count = Enum.GetValues(typeof(SOURCES)).Length;
        for (int i = 0; i < count; i++)
        {
            gameObject.AddComponent(typeof(AudioSource));
        }

    }

    void SetupVariable() {
        audioSources = GetComponents<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            source.playOnAwake = false;
        }

       AUDIO = GetComponent<AudioData> ();
	}
    #endregion

    #region Controls
    void PLAYSPELL(SOURCES source, AudioClip clip, float volume = 1.0f, bool loop = false)
    {
        AudioSource audioSource = audioSources[(int)source];
        audioSource.loop = loop;
        audioSource.PlayOneShot(clip, volume);
    }



    void PLAYGENERIC(AudioClip clip, float volume = 1.0f)
    {
        getGenericSource().PlayOneShot(clip, volume);
    }


    void fadeAudio(AudioSource source, float volume = 0, float time = 1f)
    {
        Hashtable ht = new Hashtable();
        ht.Add("audiosource", source);
        ht.Add("volume", volume);
        ht.Add("time", time);
        iTween.AudioTo(gameObject, ht);
    }

    void stopSource(SOURCES source)
    {
        AudioSource audioSource = audioSources[(int)source];
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void STOPALL() 
    {
        foreach (AudioSource source in audioSources)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
        }
	}


    private AudioSource getGenericSource()
    {
        return audioSources[(int)SOURCES.GENERIC];
    }

    
    #endregion

}
