using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;

    public AudioSource[] soundEffects;
    private void Awake()
    {
        instance = this;
    }
    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
        // Adding some variance to the pitch of the audio clip
        soundEffects[soundToPlay].pitch = Random.Range(.7f, 1.1f);
        soundEffects[soundToPlay].Play();
    }
}
