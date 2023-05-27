//---------------------------------------------------------------------------------------------------------------------
// This script manages audio playback, including sound effects and background music, in the game.
//---------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource[] _soundEffects;      // Array of sound effect AudioSources
    [SerializeField] AudioSource _backgroundMusic;     // AudioSource for background music

    float _soundEffectsVolume = 1f;  // Volume level for sound effects
    float _musicVolume = 1f;         // Volume level for background music

    private List<AudioSource> _soundEffectPool = new List<AudioSource>();  // List of pooled AudioSources for sound effects

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitializeSoundEffectPool();
    }

    // Initialize the sound effect pool
    private void InitializeSoundEffectPool()
    {
        for (int i = 0; i < _soundEffects.Length; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = _soundEffects[i].clip;
            source.playOnAwake = false;
            _soundEffectPool.Add(source);
        }
    }

    // Play a sound effect by index
    public void PlaySFX(int soundToPlay)
    {
        AudioSource source = GetAvailableSoundEffect();
        if (source != null)
        {
            source.Stop();
            source.pitch = Random.Range(0.7f, 1.1f);
            source.Play();
        }
    }

    // Get an available sound effect AudioSource from the pool
    private AudioSource GetAvailableSoundEffect()
    {
        for (int i = 0; i < _soundEffectPool.Count; i++)
        {
            if (!_soundEffectPool[i].isPlaying)
            {
                return _soundEffectPool[i];
            }
        }
        return null;
    }

    // Set the volume level for sound effects
    public void SetSoundEffectsVolume(float volume)
    {
        _soundEffectsVolume = volume;
        UpdateSoundEffectsVolume();
    }

    // Set the volume level for background music
    public void SetMusicVolume(float volume)
    {
        _musicVolume = volume;
        UpdateMusicVolume();
    }

    // Update the volume levels for all sound effects
    private void UpdateSoundEffectsVolume()
    {
        for (int i = 0; i < _soundEffects.Length; i++)
        {
            _soundEffects[i].volume = _soundEffectsVolume;
        }
    }

    // Update the volume level for background music
    private void UpdateMusicVolume()
    {
        if (_backgroundMusic != null)
        {
            _backgroundMusic.volume = _musicVolume;
        }
    }

    // Fade out the background music over the specified duration
    public void FadeOutBackgroundMusic(float duration)
    {
        StartCoroutine(FadeOutBackgroundMusicCoroutine(duration));
    }

    // Coroutine for fading out the background music
    private IEnumerator FadeOutBackgroundMusicCoroutine(float duration)
    {
        float elapsedTime = 0f;
        float startVolume = _backgroundMusic.volume;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            _backgroundMusic.volume = Mathf.Lerp(startVolume, 0f, t);
            yield return null;
        }

        _backgroundMusic.Stop();
    }
}
