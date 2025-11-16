using System;
using UnityEngine;

/// <summary>
/// Game settings - audio, visual, accessibility options
/// </summary>
[Serializable]
public class GameSettings
{
    [Header("Audio Settings")]
    [Range(0f, 1f)]
    public float masterVolume = 0.8f;

    [Range(0f, 1f)]
    public float musicVolume = 0.7f;

    [Range(0f, 1f)]
    public float sfxVolume = 0.75f;

    public bool vibrationEnabled = true;
    public bool babySafeMode = false; // Mutes all sounds

    [Header("Visual Settings")]
    public bool colorblindMode = false;
    public TextSize textSize = TextSize.Normal;

    [Header("Gameplay Settings")]
    public bool hintsEnabled = true;
    public DifficultyMode difficulty = DifficultyMode.Easy;

    [Header("Accessibility")]
    public bool childLockEnabled = false;
    public bool autoPlayMode = false; // Watch mode

    /// <summary>
    /// Reset to default settings
    /// </summary>
    public void ResetToDefaults()
    {
        masterVolume = 0.8f;
        musicVolume = 0.7f;
        sfxVolume = 0.75f;
        vibrationEnabled = true;
        babySafeMode = false;
        colorblindMode = false;
        textSize = TextSize.Normal;
        hintsEnabled = true;
        difficulty = DifficultyMode.Easy;
        childLockEnabled = false;
        autoPlayMode = false;
    }
}

public enum TextSize
{
    Small,
    Normal,
    Large
}

public enum DifficultyMode
{
    Easy,       // Default - very forgiving
    Normal,     // Standard difficulty
    WalkOnly    // Challenge mode - no vehicles
}
