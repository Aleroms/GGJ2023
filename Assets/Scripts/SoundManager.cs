using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager SoundInstance = null;

    private AudioSource audioSourceObject;

    private Dictionary<string, AudioClip> soundDictionary = new Dictionary<string, AudioClip>();
    
    // Creates SoundManager singleton
    void Awake()
    {
        if (SoundInstance == null)
            SoundInstance = this;
        else if (SoundInstance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        audioSourceObject = gameObject.GetComponent<AudioSource>();
        if (audioSourceObject == null)
            Debug.Log("AudioSource not found");

        LoadSFX();
    }

    //Maps sound clips to key strings in a dictionary
    private void LoadSFX()
    {
        soundDictionary.Add("click", Resources.Load("Sounds/Click") as AudioClip);
        Debug.Log(soundDictionary.Count);
    }

    //Plays a clip using its name
    public void PlaySFX(string clipName)
    {
        audioSourceObject.clip = soundDictionary.GetValueOrDefault(clipName);
        audioSourceObject.Play();
    }
}
