using UnityEngine;
using System;
using System.IO;

/// <summary>
/// Save system - handles saving and loading game data
/// Uses JSON for simple, human-readable saves
/// </summary>
public static class SaveSystem
{
    private static string SaveDirectory => Application.persistentDataPath;
    private static string SaveFilePath => Path.Combine(SaveDirectory, "savegame.json");
    private static string SettingsFilePath => Path.Combine(SaveDirectory, "settings.json");

    /// <summary>
    /// Save game data
    /// </summary>
    public static void SaveGame(SaveData data)
    {
        try
        {
            // Ensure directory exists
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            // Convert to JSON
            string json = JsonUtility.ToJson(data, true);

            // Write to file
            File.WriteAllText(SaveFilePath, json);

            Debug.Log($"Game saved to: {SaveFilePath}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save game: {e.Message}");
        }
    }

    /// <summary>
    /// Load game data
    /// </summary>
    public static SaveData LoadGame()
    {
        try
        {
            if (!File.Exists(SaveFilePath))
            {
                Debug.Log("No save file found, creating new save");
                return CreateNewSaveData();
            }

            // Read from file
            string json = File.ReadAllText(SaveFilePath);

            // Convert from JSON
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("Game loaded successfully");
            return data;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load game: {e.Message}");
            return CreateNewSaveData();
        }
    }

    /// <summary>
    /// Save game settings
    /// </summary>
    public static void SaveSettings(GameSettings settings)
    {
        try
        {
            string json = JsonUtility.ToJson(settings, true);
            File.WriteAllText(SettingsFilePath, json);
            Debug.Log("Settings saved");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save settings: {e.Message}");
        }
    }

    /// <summary>
    /// Load game settings
    /// </summary>
    public static GameSettings LoadSettings()
    {
        try
        {
            if (!File.Exists(SettingsFilePath))
            {
                Debug.Log("No settings file found, using defaults");
                return new GameSettings();
            }

            string json = File.ReadAllText(SettingsFilePath);
            GameSettings settings = JsonUtility.FromJson<GameSettings>(json);

            Debug.Log("Settings loaded");
            return settings;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load settings: {e.Message}");
            return new GameSettings();
        }
    }

    /// <summary>
    /// Delete save file
    /// </summary>
    public static void DeleteSave()
    {
        try
        {
            if (File.Exists(SaveFilePath))
            {
                File.Delete(SaveFilePath);
                Debug.Log("Save file deleted");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to delete save: {e.Message}");
        }
    }

    /// <summary>
    /// Check if save file exists
    /// </summary>
    public static bool SaveExists()
    {
        return File.Exists(SaveFilePath);
    }

    /// <summary>
    /// Create new save data with defaults
    /// </summary>
    private static SaveData CreateNewSaveData()
    {
        SaveData data = new SaveData();
        data.profile = new PlayerProfile
        {
            playerName = "Heraniya",
            totalPlays = 0,
            totalPlaytime = 0f,
            firstPlayDate = DateTime.Now.ToString(),
            lastPlayDate = DateTime.Now.ToString()
        };

        data.statistics = new Statistics();
        data.settings = new GameSettings();
        data.achievements = new AchievementData();

        return data;
    }
}

/// <summary>
/// Main save data structure
/// </summary>
[Serializable]
public class SaveData
{
    public PlayerProfile profile;
    public Statistics statistics;
    public GameSettings settings;
    public AchievementData achievements;
    public SessionData currentSession;
}

/// <summary>
/// Player profile data
/// </summary>
[Serializable]
public class PlayerProfile
{
    public string playerName;
    public int totalPlays;
    public float totalPlaytime;
    public string firstPlayDate;
    public string lastPlayDate;
}

/// <summary>
/// Statistics data
/// </summary>
[Serializable]
public class Statistics
{
    public int totalStarsCollected;
    public int totalCookiesCollected;
    public int totalHeartsCollected;
    public int carRides;
    public int scooterRides;
    public int perfectRuns;
    public float fastestTime = 999f;
}

/// <summary>
/// Achievement data
/// </summary>
[Serializable]
public class AchievementData
{
    public bool firstVisit;
    public bool returnVisit;
    public bool lovingSister;
    public bool starGazer;
    public bool starHunter;
    public bool starMaster;
    public bool cookieFinder;
    public bool heartCollector;
    public bool perfectLove;
    public bool perfectStars;
    public bool perfectEverything;
    public bool driversLicense;
    public bool scooterPro;
    public bool vehicleMaster;
    public bool walkingChampion;
    public bool speedyVisit;
    public bool quickVisit;
    public bool lightningVisit;
    public bool photographer;
    public bool memoryKeeper;
    public bool photoAlbum;
    public bool explorer;
    public bool petFriend;
    public bool quietVisitor;
}

/// <summary>
/// Current session data (for mid-level saves)
/// </summary>
[Serializable]
public class SessionData
{
    public string currentLevel;
    public int starsCollected;
    public int cookiesCollected;
    public int heartsCollected;
    public string vehicleUsed;
    public float playTime;
}
