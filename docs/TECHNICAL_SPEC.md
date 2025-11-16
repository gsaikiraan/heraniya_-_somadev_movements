# 🔧 Technical Specification
## Heraniya's Journey to See Somdev

---

## Architecture Overview

### System Architecture

```
┌─────────────────────────────────────────┐
│         Game Application Layer          │
├─────────────────────────────────────────┤
│  ┌─────────┐  ┌──────────┐  ┌────────┐ │
│  │  Game   │  │  Level   │  │   UI   │ │
│  │ Manager │  │ Manager  │  │Manager │ │
│  └─────────┘  └──────────┘  └────────┘ │
├─────────────────────────────────────────┤
│  ┌─────────┐  ┌──────────┐  ┌────────┐ │
│  │ Player  │  │Collection│  │Vehicle │ │
│  │Controller│  │ System   │  │ System │ │
│  └─────────┘  └──────────┘  └────────┘ │
├─────────────────────────────────────────┤
│  ┌─────────┐  ┌──────────┐  ┌────────┐ │
│  │  Audio  │  │   Save   │  │ Input  │ │
│  │ Manager │  │  System  │  │Handler │ │
│  └─────────┘  └──────────┘  └────────┘ │
├─────────────────────────────────────────┤
│         Game Engine Layer               │
│    (Unity / Phaser / Godot)             │
└─────────────────────────────────────────┘
```

---

## Core Systems

### 1. Game Manager

**Responsibilities:**
- Game state management (Menu, Playing, Paused, Ended)
- Scene loading and transitions
- Save/load coordination
- Settings management
- Global event handling

**Key Methods:**
```csharp
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // State management
    public GameState CurrentState { get; private set; }
    public void ChangeState(GameState newState);

    // Level management
    public void LoadLevel(int levelIndex);
    public void RestartLevel();
    public void NextLevel();

    // Save/Load
    public void SaveGame();
    public void LoadGame();

    // Settings
    public GameSettings Settings { get; private set; }
    public void ApplySettings(GameSettings settings);
}

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    LevelComplete,
    GameComplete
}
```

---

### 2. Player Controller

**Responsibilities:**
- Character movement (auto-walk, jump)
- Input handling
- Animation control
- Collision detection
- Vehicle interaction

**Key Methods:**
```csharp
public class PlayerController : MonoBehaviour
{
    // Movement
    public float walkSpeed = 2f;
    public float jumpForce = 10f;
    public bool isGrounded;

    // State
    public PlayerState currentState;
    private bool canDoubleJump;

    // Methods
    public void Jump();
    public void MountVehicle(Vehicle vehicle);
    public void DismountVehicle();
    private void UpdateMovement();
    private void UpdateAnimation();

    // Events
    public event Action OnJump;
    public event Action OnLand;
    public event Action OnCollectItem;
}

public enum PlayerState
{
    Walking,
    Jumping,
    RidingVehicle,
    Tiptoeing
}
```

---

### 3. Collection System

**Responsibilities:**
- Collectible item management
- Collection detection
- Counter updates
- Visual/audio feedback
- Achievement tracking

**Key Methods:**
```csharp
public class CollectionSystem : MonoBehaviour
{
    public int starsCollected;
    public int cookiesCollected;
    public int heartsCollected;

    public void CollectItem(CollectibleType type);
    private void UpdateCounters();
    private void TriggerFeedback(CollectibleType type);

    public event Action<CollectibleType> OnItemCollected;
}

public enum CollectibleType
{
    Star,
    Cookie,
    Heart
}

public class Collectible : MonoBehaviour
{
    public CollectibleType type;
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectionSystem.Instance.CollectItem(type);
            PlayCollectionEffect();
            Destroy(gameObject);
        }
    }
}
```

---

### 4. Vehicle System

**Responsibilities:**
- Vehicle behavior
- Mount/dismount logic
- Speed modifications
- Special abilities (horn, bell)
- Vehicle UI

**Key Methods:**
```csharp
public class Vehicle : MonoBehaviour
{
    public VehicleType type;
    public float speedMultiplier;
    public float jumpMultiplier;

    public void Mount(PlayerController player);
    public void Dismount();
    public void UseSpecialAbility(); // Horn/Bell

    private bool isMounted;
    private PlayerController currentPlayer;
}

public enum VehicleType
{
    ToyCar,
    Scooter
}
```

---

### 5. Audio Manager

**Responsibilities:**
- Music playback
- Sound effect triggering
- Volume control
- Audio mixing/ducking
- Baby-safe mode

**Key Methods:**
```csharp
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    // Music
    public void PlayMusic(string trackName, bool loop = true);
    public void StopMusic();
    public void CrossfadeMusic(string newTrack, float duration);

    // SFX
    public void PlaySFX(string sfxName);
    public void PlaySFXAtPosition(string sfxName, Vector3 position);

    // Volume
    public void SetMasterVolume(float volume);
    public void SetMusicVolume(float volume);
    public void SetSFXVolume(float volume);

    // Special modes
    public void EnableBabySafeMode(bool enable);

    // Ducking (automatic volume reduction)
    private void DuckMusic(float amount, float duration);
}
```

---

### 6. Save System

**Responsibilities:**
- Data serialization
- Save/load operations
- Cloud sync (optional)
- Achievement persistence

**Data Structure:**
```csharp
[Serializable]
public class SaveData
{
    public PlayerProfile profile;
    public Statistics stats;
    public Dictionary<string, bool> achievements;
    public List<string> unlockedFrames;
    public GameSettings settings;
    public SessionData currentSession;
    public List<PhotoData> gallery;

    public string ToJson()
    {
        return JsonUtility.ToJson(this, true);
    }

    public static SaveData FromJson(string json)
    {
        return JsonUtility.FromJson<SaveData>(json);
    }
}

[Serializable]
public class PlayerProfile
{
    public string playerName;
    public int totalPlays;
    public float totalPlaytime;
    public DateTime firstPlayDate;
    public DateTime lastPlayDate;
}

[Serializable]
public class Statistics
{
    public int totalStarsCollected;
    public int totalCookiesCollected;
    public int totalHeartsCollected;
    public int carRides;
    public int scooterRides;
    public int perfectRuns;
    public float fastestTime;
}
```

**Save/Load Implementation:**
```csharp
public class SaveSystem
{
    private static string SavePath =>
        Path.Combine(Application.persistentDataPath, "savegame.json");

    public static void SaveGame(SaveData data)
    {
        try
        {
            string json = data.ToJson();
            File.WriteAllText(SavePath, json);
            Debug.Log("Game saved successfully");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save game: {e.Message}");
        }
    }

    public static SaveData LoadGame()
    {
        if (!File.Exists(SavePath))
        {
            return CreateNewSaveData();
        }

        try
        {
            string json = File.ReadAllText(SavePath);
            return SaveData.FromJson(json);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load game: {e.Message}");
            return CreateNewSaveData();
        }
    }

    private static SaveData CreateNewSaveData()
    {
        // Create default save data
        return new SaveData();
    }
}
```

---

## Performance Optimization

### Object Pooling

```csharp
public class ObjectPool
{
    private GameObject prefab;
    private Queue<GameObject> pool = new Queue<GameObject>();
    private int initialSize = 20;

    public ObjectPool(GameObject prefab, int initialSize = 20)
    {
        this.prefab = prefab;
        this.initialSize = initialSize;

        // Pre-populate pool
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject Get()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            // Pool exhausted, create new object
            GameObject obj = GameObject.Instantiate(prefab);
            return obj;
        }
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}

// Usage
public class PoolManager : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject cookiePrefab;
    public GameObject sparkleEffectPrefab;

    private ObjectPool starPool;
    private ObjectPool cookiePool;
    private ObjectPool sparklePool;

    void Awake()
    {
        starPool = new ObjectPool(starPrefab, 30);
        cookiePool = new ObjectPool(cookiePrefab, 15);
        sparklePool = new ObjectPool(sparkleEffectPrefab, 50);
    }
}
```

---

### Memory Management

```csharp
public class AssetManager : MonoBehaviour
{
    // Cache frequently used assets
    private Dictionary<string, Sprite> spriteCache = new Dictionary<string, Sprite>();
    private Dictionary<string, AudioClip> audioCache = new Dictionary<string, AudioClip>();

    public Sprite LoadSprite(string path)
    {
        if (spriteCache.ContainsKey(path))
        {
            return spriteCache[path];
        }

        Sprite sprite = Resources.Load<Sprite>(path);
        spriteCache[path] = sprite;
        return sprite;
    }

    public void UnloadUnusedAssets()
    {
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }

    // Call between levels
    public void ClearCache()
    {
        spriteCache.Clear();
        audioCache.Clear();
        UnloadUnusedAssets();
    }
}
```

---

## Platform-Specific Considerations

### Mobile Input

```csharp
public class InputHandler : MonoBehaviour
{
    public event Action OnTapAnywhere;

    void Update()
    {
        // Handle both touch and mouse input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                OnTapAnywhere?.Invoke();
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            OnTapAnywhere?.Invoke();
        }
    }
}
```

### Resolution Scaling

```csharp
public class ResolutionManager : MonoBehaviour
{
    void Awake()
    {
        // Set target resolution
        int targetWidth = 1920;
        int targetHeight = 1080;

        // Maintain aspect ratio
        float targetAspect = (float)targetWidth / targetHeight;
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
}
```

---

## Testing Framework

### Unit Test Example

```csharp
using NUnit.Framework;

public class CollectionSystemTests
{
    [Test]
    public void CollectStar_IncreasesCounter()
    {
        // Arrange
        CollectionSystem system = new CollectionSystem();
        int initialStars = system.starsCollected;

        // Act
        system.CollectItem(CollectibleType.Star);

        // Assert
        Assert.AreEqual(initialStars + 1, system.starsCollected);
    }

    [Test]
    public void CollectAllHearts_TriggersAchievement()
    {
        // Arrange
        CollectionSystem system = new CollectionSystem();

        // Act
        for (int i = 0; i < 10; i++)
        {
            system.CollectItem(CollectibleType.Heart);
        }

        // Assert
        Assert.IsTrue(system.HasAchievement("PerfectLove"));
    }
}
```

---

## Build Configuration

### Unity Build Settings

```csharp
// Editor script for automated builds
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build.Reporting;

public class BuildScript
{
    [MenuItem("Build/Build iOS")]
    public static void BuildiOS()
    {
        BuildPlayerOptions buildOptions = new BuildPlayerOptions();
        buildOptions.scenes = GetScenes();
        buildOptions.locationPathName = "Builds/iOS";
        buildOptions.target = BuildTarget.iOS;
        buildOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildOptions);
        LogBuildResult(report);
    }

    [MenuItem("Build/Build Android")]
    public static void BuildAndroid()
    {
        BuildPlayerOptions buildOptions = new BuildPlayerOptions();
        buildOptions.scenes = GetScenes();
        buildOptions.locationPathName = "Builds/Android/game.apk";
        buildOptions.target = BuildTarget.Android;
        buildOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildOptions);
        LogBuildResult(report);
    }

    private static string[] GetScenes()
    {
        return new string[]
        {
            "Assets/Scenes/MainMenu.unity",
            "Assets/Scenes/Level1_LivingRoom.unity",
            "Assets/Scenes/Level2_Hallway.unity",
            "Assets/Scenes/Level3_Bedroom.unity"
        };
    }

    private static void LogBuildResult(BuildReport report)
    {
        if (report.summary.result == BuildResult.Succeeded)
        {
            Debug.Log($"Build succeeded: {report.summary.totalSize} bytes");
        }
        else
        {
            Debug.LogError("Build failed");
        }
    }
}
#endif
```

---

## Performance Targets

### Metrics

| Metric | Target | Minimum |
|--------|--------|---------|
| Frame Rate | 60 FPS | 30 FPS |
| Memory Usage | < 150MB | < 200MB |
| Load Time (Initial) | < 3s | < 5s |
| Load Time (Level) | < 0.5s | < 1s |
| Battery Drain | < 5%/30min | < 10%/30min |
| App Size | < 100MB | < 150MB |

### Optimization Checklist

- [ ] Sprite atlasing (combine textures)
- [ ] Object pooling for frequent spawns
- [ ] Frustum culling enabled
- [ ] Audio compression (OGG format)
- [ ] Texture compression (ASTC/ETC2)
- [ ] Code stripping enabled
- [ ] Managed code stripping (Medium/High)
- [ ] Remove unused assets
- [ ] Optimize draw calls (< 50 per frame)
- [ ] Reduce overdraw

---

**Last Updated:** 2025-11-16
**Version:** 1.0
**Status:** Draft
