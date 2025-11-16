using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Main game manager - handles game state, scene transitions, and global coordination
/// Singleton pattern ensures only one instance exists
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public GameState currentState = GameState.MainMenu;

    [Header("Settings")]
    public GameSettings settings;

    [Header("Events")]
    public event Action<GameState> OnGameStateChanged;
    public event Action OnLevelComplete;
    public event Action OnGameComplete;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeGame()
    {
        // Load settings
        settings = SaveSystem.LoadSettings();
        if (settings == null)
        {
            settings = new GameSettings(); // Use defaults
        }

        // Apply settings
        ApplySettings(settings);

        Debug.Log("Game initialized successfully");
    }

    /// <summary>
    /// Change the current game state
    /// </summary>
    public void ChangeState(GameState newState)
    {
        if (currentState == newState) return;

        Debug.Log($"Game state changed: {currentState} -> {newState}");
        currentState = newState;
        OnGameStateChanged?.Invoke(newState);

        HandleStateChange(newState);
    }

    private void HandleStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                Time.timeScale = 1f;
                break;

            case GameState.Playing:
                Time.timeScale = 1f;
                break;

            case GameState.Paused:
                Time.timeScale = 0f;
                break;

            case GameState.LevelComplete:
                Time.timeScale = 0f;
                OnLevelComplete?.Invoke();
                break;

            case GameState.GameComplete:
                Time.timeScale = 0f;
                OnGameComplete?.Invoke();
                break;
        }
    }

    /// <summary>
    /// Load a specific level by index
    /// </summary>
    public void LoadLevel(int levelIndex)
    {
        Debug.Log($"Loading level {levelIndex}");
        SceneManager.LoadScene(levelIndex);
        ChangeState(GameState.Playing);
    }

    /// <summary>
    /// Load level by name
    /// </summary>
    public void LoadLevel(string levelName)
    {
        Debug.Log($"Loading level {levelName}");
        SceneManager.LoadScene(levelName);
        ChangeState(GameState.Playing);
    }

    /// <summary>
    /// Restart the current level
    /// </summary>
    public void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
        ChangeState(GameState.Playing);
    }

    /// <summary>
    /// Load the next level in sequence
    /// </summary>
    public void NextLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int nextSceneIndex = currentScene.buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextSceneIndex);
        }
        else
        {
            // All levels complete!
            ChangeState(GameState.GameComplete);
        }
    }

    /// <summary>
    /// Pause the game
    /// </summary>
    public void PauseGame()
    {
        ChangeState(GameState.Paused);
    }

    /// <summary>
    /// Resume the game
    /// </summary>
    public void ResumeGame()
    {
        ChangeState(GameState.Playing);
    }

    /// <summary>
    /// Return to main menu
    /// </summary>
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        ChangeState(GameState.MainMenu);
    }

    /// <summary>
    /// Apply game settings
    /// </summary>
    public void ApplySettings(GameSettings newSettings)
    {
        settings = newSettings;

        // Apply audio settings
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetMasterVolume(settings.masterVolume);
            AudioManager.Instance.SetMusicVolume(settings.musicVolume);
            AudioManager.Instance.SetSFXVolume(settings.sfxVolume);
            AudioManager.Instance.EnableBabySafeMode(settings.babySafeMode);
        }

        // Apply visual settings
        // (Colorblind mode, text size, etc. - implement as needed)

        // Save settings
        SaveSystem.SaveSettings(settings);

        Debug.Log("Settings applied");
    }

    /// <summary>
    /// Save current game progress
    /// </summary>
    public void SaveGame()
    {
        SaveData saveData = CreateSaveData();
        SaveSystem.SaveGame(saveData);
        Debug.Log("Game saved");
    }

    /// <summary>
    /// Load saved game progress
    /// </summary>
    public void LoadGame()
    {
        SaveData saveData = SaveSystem.LoadGame();
        if (saveData != null)
        {
            ApplySaveData(saveData);
            Debug.Log("Game loaded");
        }
        else
        {
            Debug.Log("No save data found");
        }
    }

    private SaveData CreateSaveData()
    {
        SaveData data = new SaveData();

        // Collect data from various systems
        if (CollectionSystem.Instance != null)
        {
            data.statistics.totalStarsCollected = CollectionSystem.Instance.totalStarsEver;
            data.statistics.totalCookiesCollected = CollectionSystem.Instance.totalCookiesEver;
            data.statistics.totalHeartsCollected = CollectionSystem.Instance.totalHeartsEver;
        }

        // Add more data as needed

        return data;
    }

    private void ApplySaveData(SaveData data)
    {
        // Apply loaded data to game systems
        if (CollectionSystem.Instance != null)
        {
            CollectionSystem.Instance.totalStarsEver = data.statistics.totalStarsCollected;
            CollectionSystem.Instance.totalCookiesEver = data.statistics.totalCookiesCollected;
            CollectionSystem.Instance.totalHeartsEver = data.statistics.totalHeartsCollected;
        }

        // Apply more data as needed
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // Auto-save when app is paused/backgrounded
            SaveGame();
        }
    }

    private void OnApplicationQuit()
    {
        // Auto-save when quitting
        SaveGame();
    }
}

/// <summary>
/// Game state enumeration
/// </summary>
public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    LevelComplete,
    GameComplete
}
