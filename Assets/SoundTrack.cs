using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrack : MonoBehaviour
{
    public AudioSource soundTrack;

    public void Awake()
    {
        DontDestroyOnLoad(soundTrack);
    }

    // Update is called once per frame
    void Update()
    {
        // Turns the music off/on
        if (DataManager.SoundOn)
        {
            soundTrack.volume = 1;
            soundTrack.mute = false;
        }
        else
        {
            soundTrack.volume = 0;
            soundTrack.mute = true;
        }
    }
}
