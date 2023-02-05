using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains the dictionary of sound effects and has methods for playing/stopping sounds
public class SoundManager : MonoBehaviour
{
    public static SoundManager SoundInstance = null;

    private AudioSource[] audioSourceObjects;

    private Dictionary<string, AudioClip> soundDictionary = new Dictionary<string, AudioClip>();
    
    // Creates SoundManager singleton
    void Awake()
    {
        if (SoundInstance == null)
            SoundInstance = this;
        else if (SoundInstance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        audioSourceObjects = gameObject.GetComponents<AudioSource>();
        if (audioSourceObjects == null || audioSourceObjects.Length != 2)
            Debug.Log("AudioSource not found");
        else
            Debug.Log(audioSourceObjects.Length + " AudioSource objects found");

        LoadSFX();
        PlayMusic("htl 1");
    }

    //Maps sound clips to key strings in a dictionary
    private void LoadSFX()
    {
        soundDictionary.Add("click", Resources.Load("Sounds/Click") as AudioClip);
        soundDictionary.Add("htl", Resources.Load("Sounds/htl") as AudioClip);
        soundDictionary.Add("htl 1", Resources.Load("Sounds/htl 1") as AudioClip);
        soundDictionary.Add("wind", Resources.Load("Sounds/wind") as AudioClip);
        soundDictionary.Add("just_pop", Resources.Load("Sounds/just_pop") as AudioClip);
        soundDictionary.Add("just_dig", Resources.Load("Sounds/just_dig") as AudioClip);
        soundDictionary.Add("digpop", Resources.Load("Sounds/digpop") as AudioClip);
        //Debug.Log("Loaded " + soundDictionary.Count + " clips");
    }

    //Plays music using its name.  Will loop
    public void PlayMusic(string clipName)
    {
        audioSourceObjects[0].clip = soundDictionary.GetValueOrDefault(clipName);
        audioSourceObjects[0].loop = true;
        //audioSourceObjects[0].Play();
        audioSourceObjects[0].Play();
    }

    //Stops the music
    public void StopMusic()
    {
        audioSourceObjects[0].Stop();
    }

    //Plays a clip using its name
    public void PlaySFX(string clipName)
    {
        Debug.Log(soundDictionary.Count + " " + audioSourceObjects.Length);
        audioSourceObjects[1].clip = soundDictionary.GetValueOrDefault(clipName);
        audioSourceObjects[1].loop = false;
        audioSourceObjects[1].Play();
    }
}
