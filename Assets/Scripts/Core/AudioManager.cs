using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Audio manager - handles all music and sound effects
/// Supports baby-safe mode, volume control, and audio mixing
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private int maxSFXSources = 8; // Object pooling for SFX

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float masterVolume = 0.8f;
    [Range(0f, 1f)] public float musicVolume = 0.7f;
    [Range(0f, 1f)] public float sfxVolume = 0.75f;

    [Header("Baby-Safe Mode")]
    [SerializeField] private bool babySafeMode = false;

    [Header("Audio Clips")]
    [SerializeField] private List<AudioClip> musicTracks = new List<AudioClip>();
    [SerializeField] private List<AudioClip> sfxClips = new List<AudioClip>();

    // Audio clip dictionary for quick lookup
    private Dictionary<string, AudioClip> musicDict = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> sfxDict = new Dictionary<string, AudioClip>();

    // SFX source pool
    private List<AudioSource> sfxSourcePool = new List<AudioSource>();
    private int currentSFXIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudioManager();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeAudioManager()
    {
        // Create music source if not assigned
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true;
            musicSource.playOnAwake = false;
        }

        // Create SFX source if not assigned
        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.playOnAwake = false;
        }

        // Create SFX source pool
        for (int i = 0; i < maxSFXSources; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
            sfxSourcePool.Add(source);
        }

        // Build audio clip dictionaries
        BuildAudioDictionaries();

        // Apply initial volumes
        ApplyVolumes();

        Debug.Log("Audio Manager initialized");
    }

    private void BuildAudioDictionaries()
    {
        // Music
        musicDict.Clear();
        foreach (AudioClip clip in musicTracks)
        {
            if (clip != null && !musicDict.ContainsKey(clip.name))
            {
                musicDict.Add(clip.name, clip);
            }
        }

        // SFX
        sfxDict.Clear();
        foreach (AudioClip clip in sfxClips)
        {
            if (clip != null && !sfxDict.ContainsKey(clip.name))
            {
                sfxDict.Add(clip.name, clip);
            }
        }
    }

    /// <summary>
    /// Play music track
    /// </summary>
    public void PlayMusic(string trackName, bool loop = true)
    {
        if (babySafeMode) return;

        if (musicDict.TryGetValue(trackName, out AudioClip clip))
        {
            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
            Debug.Log($"Playing music: {trackName}");
        }
        else
        {
            Debug.LogWarning($"Music track not found: {trackName}");
        }
    }

    /// <summary>
    /// Stop music
    /// </summary>
    public void StopMusic()
    {
        musicSource.Stop();
    }

    /// <summary>
    /// Crossfade to new music track
    /// </summary>
    public void CrossfadeMusic(string newTrackName, float duration = 2f)
    {
        if (babySafeMode) return;

        StartCoroutine(CrossfadeCoroutine(newTrackName, duration));
    }

    private IEnumerator CrossfadeCoroutine(string newTrackName, float duration)
    {
        float elapsed = 0f;
        float startVolume = musicSource.volume;

        // Fade out current music
        while (elapsed < duration / 2f)
        {
            elapsed += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVolume, 0f, elapsed / (duration / 2f));
            yield return null;
        }

        // Switch track
        PlayMusic(newTrackName);
        musicSource.volume = 0f;

        // Fade in new music
        elapsed = 0f;
        while (elapsed < duration / 2f)
        {
            elapsed += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(0f, musicVolume * masterVolume, elapsed / (duration / 2f));
            yield return null;
        }

        musicSource.volume = musicVolume * masterVolume;
    }

    /// <summary>
    /// Play sound effect
    /// </summary>
    public void PlaySFX(string sfxName)
    {
        if (babySafeMode) return;

        if (sfxDict.TryGetValue(sfxName, out AudioClip clip))
        {
            // Get next available SFX source from pool
            AudioSource source = sfxSourcePool[currentSFXIndex];
            currentSFXIndex = (currentSFXIndex + 1) % maxSFXSources;

            source.clip = clip;
            source.volume = sfxVolume * masterVolume;
            source.Play();

            Debug.Log($"Playing SFX: {sfxName}");
        }
        else
        {
            Debug.LogWarning($"SFX not found: {sfxName}");
        }
    }

    /// <summary>
    /// Play sound effect at specific position (3D audio)
    /// </summary>
    public void PlaySFXAtPosition(string sfxName, Vector3 position)
    {
        if (babySafeMode) return;

        if (sfxDict.TryGetValue(sfxName, out AudioClip clip))
        {
            AudioSource.PlayClipAtPoint(clip, position, sfxVolume * masterVolume);
        }
    }

    /// <summary>
    /// Set master volume
    /// </summary>
    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);
        ApplyVolumes();
    }

    /// <summary>
    /// Set music volume
    /// </summary>
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        ApplyVolumes();
    }

    /// <summary>
    /// Set SFX volume
    /// </summary>
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        ApplyVolumes();
    }

    /// <summary>
    /// Apply volume settings to all audio sources
    /// </summary>
    private void ApplyVolumes()
    {
        if (musicSource != null)
        {
            musicSource.volume = musicVolume * masterVolume;
        }

        if (sfxSource != null)
        {
            sfxSource.volume = sfxVolume * masterVolume;
        }

        foreach (AudioSource source in sfxSourcePool)
        {
            if (source != null)
            {
                source.volume = sfxVolume * masterVolume;
            }
        }
    }

    /// <summary>
    /// Enable/disable baby-safe mode (mutes all audio)
    /// </summary>
    public void EnableBabySafeMode(bool enabled)
    {
        babySafeMode = enabled;

        if (babySafeMode)
        {
            // Mute everything
            musicSource.mute = true;
            sfxSource.mute = true;
            foreach (AudioSource source in sfxSourcePool)
            {
                source.mute = true;
            }
        }
        else
        {
            // Unmute
            musicSource.mute = false;
            sfxSource.mute = false;
            foreach (AudioSource source in sfxSourcePool)
            {
                source.mute = false;
            }
        }

        Debug.Log($"Baby-Safe Mode: {enabled}");
    }

    /// <summary>
    /// Duck music (reduce volume temporarily)
    /// Used when important sound effects play
    /// </summary>
    public void DuckMusic(float amount = 0.3f, float duration = 0.5f)
    {
        StartCoroutine(DuckMusicCoroutine(amount, duration));
    }

    private IEnumerator DuckMusicCoroutine(float amount, float duration)
    {
        float originalVolume = musicSource.volume;
        float targetVolume = originalVolume * (1f - amount);

        // Duck down
        musicSource.volume = targetVolume;

        // Wait
        yield return new WaitForSeconds(duration);

        // Return to original
        musicSource.volume = originalVolume;
    }
}
