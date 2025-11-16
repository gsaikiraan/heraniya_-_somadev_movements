using UnityEngine;
using System;

/// <summary>
/// Collection system - manages collectible items (stars, cookies, hearts)
/// Tracks current session and lifetime totals
/// </summary>
public class CollectionSystem : MonoBehaviour
{
    public static CollectionSystem Instance { get; private set; }

    [Header("Current Session")]
    public int starsCollected = 0;
    public int cookiesCollected = 0;
    public int heartsCollected = 0;

    [Header("Lifetime Totals")]
    public int totalStarsEver = 0;
    public int totalCookiesEver = 0;
    public int totalHeartsEver = 0;

    [Header("Level Totals")]
    public int totalStarsInLevel = 50;
    public int totalCookiesInLevel = 15;
    public int totalHeartsInLevel = 10;

    // Events
    public event Action<CollectibleType, int> OnItemCollected;
    public event Action<CollectibleType> OnCollectionComplete; // All of one type collected

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ResetSessionCollectibles();
    }

    /// <summary>
    /// Reset session collectibles (call at level start)
    /// </summary>
    public void ResetSessionCollectibles()
    {
        starsCollected = 0;
        cookiesCollected = 0;
        heartsCollected = 0;
    }

    /// <summary>
    /// Collect an item
    /// </summary>
    public void CollectItem(CollectibleType type, int amount = 1)
    {
        switch (type)
        {
            case CollectibleType.Star:
                starsCollected += amount;
                totalStarsEver += amount;
                CheckCollectionComplete(CollectibleType.Star, starsCollected, totalStarsInLevel);
                break;

            case CollectibleType.Cookie:
                cookiesCollected += amount;
                totalCookiesEver += amount;
                CheckCollectionComplete(CollectibleType.Cookie, cookiesCollected, totalCookiesInLevel);
                break;

            case CollectibleType.Heart:
                heartsCollected += amount;
                totalHeartsEver += amount;
                CheckCollectionComplete(CollectibleType.Heart, heartsCollected, totalHeartsInLevel);
                break;
        }

        // Trigger event
        OnItemCollected?.Invoke(type, GetCollectionCount(type));

        // Play feedback
        PlayCollectionFeedback(type);

        Debug.Log($"Collected {type}! Total: {GetCollectionCount(type)}");
    }

    /// <summary>
    /// Get current count for a collectible type
    /// </summary>
    public int GetCollectionCount(CollectibleType type)
    {
        switch (type)
        {
            case CollectibleType.Star: return starsCollected;
            case CollectibleType.Cookie: return cookiesCollected;
            case CollectibleType.Heart: return heartsCollected;
            default: return 0;
        }
    }

    /// <summary>
    /// Check if all of a type have been collected
    /// </summary>
    private void CheckCollectionComplete(CollectibleType type, int current, int total)
    {
        if (current >= total)
        {
            OnCollectionComplete?.Invoke(type);
            Debug.Log($"All {type}s collected!");
        }
    }

    /// <summary>
    /// Play audio/visual feedback for collection
    /// </summary>
    private void PlayCollectionFeedback(CollectibleType type)
    {
        if (AudioManager.Instance == null) return;

        switch (type)
        {
            case CollectibleType.Star:
                AudioManager.Instance.PlaySFX("CollectStar");
                break;

            case CollectibleType.Cookie:
                AudioManager.Instance.PlaySFX("CollectCookie");
                break;

            case CollectibleType.Heart:
                AudioManager.Instance.PlaySFX("CollectHeart");
                break;
        }
    }

    /// <summary>
    /// Get completion percentage for current session
    /// </summary>
    public float GetCompletionPercentage()
    {
        int totalCollected = starsCollected + cookiesCollected + heartsCollected;
        int totalAvailable = totalStarsInLevel + totalCookiesInLevel + totalHeartsInLevel;

        return (float)totalCollected / totalAvailable * 100f;
    }

    /// <summary>
    /// Check if perfect run (100% collection)
    /// </summary>
    public bool IsPerfectRun()
    {
        return starsCollected >= totalStarsInLevel &&
               cookiesCollected >= totalCookiesInLevel &&
               heartsCollected >= totalHeartsInLevel;
    }

    /// <summary>
    /// Get session summary
    /// </summary>
    public string GetSessionSummary()
    {
        return $"Stars: {starsCollected}/{totalStarsInLevel}, " +
               $"Cookies: {cookiesCollected}/{totalCookiesInLevel}, " +
               $"Hearts: {heartsCollected}/{totalHeartsInLevel}";
    }
}

/// <summary>
/// Types of collectible items
/// </summary>
public enum CollectibleType
{
    Star,
    Cookie,
    Heart
}
