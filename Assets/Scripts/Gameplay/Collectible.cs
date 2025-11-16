using UnityEngine;

/// <summary>
/// Individual collectible item - stars, cookies, hearts
/// Auto-collects when player comes near
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
public class Collectible : MonoBehaviour
{
    [Header("Collectible Settings")]
    [SerializeField] private CollectibleType type = CollectibleType.Star;
    [SerializeField] private int value = 1;
    [SerializeField] private float autoCollectRadius = 1f; // Auto-collect within this distance

    [Header("Visual Effects")]
    [SerializeField] private GameObject collectEffect; // Particle effect on collection
    [SerializeField] private float floatSpeed = 0.5f; // Gentle bobbing animation
    [SerializeField] private float floatHeight = 0.2f;

    [Header("Audio")]
    [SerializeField] private AudioClip collectSound;

    private Vector3 startPosition;
    private CircleCollider2D col;
    private SpriteRenderer spriteRenderer;
    private bool isCollected = false;

    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col.isTrigger = true;
        col.radius = autoCollectRadius;
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (!isCollected)
        {
            // Gentle floating animation
            FloatAnimation();
        }
    }

    /// <summary>
    /// Gentle bobbing animation
    /// </summary>
    private void FloatAnimation()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    /// <summary>
    /// Detect player entering collection radius
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;

        // Check if it's the player
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Collect(player);
        }
    }

    /// <summary>
    /// Collect this item
    /// </summary>
    private void Collect(PlayerController player)
    {
        if (isCollected) return;
        isCollected = true;

        // Notify player
        player.CollectItem(type);

        // Play collection effect
        PlayCollectionEffect();

        // Play sound
        if (collectSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFXAtPosition(collectSound.name, transform.position);
        }

        // Destroy the collectible
        Destroy(gameObject);
    }

    /// <summary>
    /// Play visual collection effect
    /// </summary>
    private void PlayCollectionEffect()
    {
        if (collectEffect != null)
        {
            // Spawn particle effect
            GameObject effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f); // Clean up after 2 seconds
        }

        // Could also add a "fly to UI counter" animation here
        // For now, just hide the sprite immediately
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }

    /// <summary>
    /// Draw collection radius in editor
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = GetGizmoColor();
        Gizmos.DrawWireSphere(transform.position, autoCollectRadius);
    }

    /// <summary>
    /// Get color for gizmo based on type
    /// </summary>
    private Color GetGizmoColor()
    {
        switch (type)
        {
            case CollectibleType.Star: return Color.yellow;
            case CollectibleType.Cookie: return new Color(0.8f, 0.5f, 0.2f); // Brown
            case CollectibleType.Heart: return Color.magenta;
            default: return Color.white;
        }
    }
}
