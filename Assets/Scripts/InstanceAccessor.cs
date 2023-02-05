using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to access methods from SoundManager.  Needed so gameObjects could reference the methods (ie. Button OnClick() events)
public class InstanceAccessor : MonoBehaviour
{
    public void PlayMusic(string clipName)
    {
        SoundManager.SoundInstance.PlayMusic(clipName);
    }

    //Stops the music
    public void StopMusic()
    {
        SoundManager.SoundInstance.StopMusic();
    }

    public void PlaySFX(string clipName)
    {
        SoundManager.SoundInstance.PlaySFX(clipName);
    }
}
