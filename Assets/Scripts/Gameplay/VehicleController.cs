using UnityEngine;
using System;

/// <summary>
/// Vehicle controller - handles toy car and scooter mechanics
/// </summary>
public class VehicleController : MonoBehaviour
{
    [Header("Vehicle Settings")]
    public VehicleType vehicleType = VehicleType.ToyCar;
    public float speedMultiplier = 1.5f;
    public float jumpMultiplier = 1.33f;
    public float currentSpeed = 3f;

    [Header("Mounting")]
    public Vector3 riderPosition = Vector3.zero; // Local position where player sits
    public Transform mountPoint; // Visual mount point

    [Header("Special Ability")]
    public float specialAbilityCooldown = 1f; // Horn/bell cooldown
    private float lastSpecialAbilityTime;

    [Header("Audio")]
    [SerializeField] private AudioClip engineSound;
    [SerializeField] private AudioClip hornSound;
    [SerializeField] private AudioClip bellSound;
    [SerializeField] private AudioClip mountSound;

    [Header("Visual Effects")]
    [SerializeField] private GameObject sparkleTrail; // Particle trail
    [SerializeField] private GameObject speedLines; // Speed effect

    private PlayerController currentRider;
    private bool isMounted = false;
    private Animator animator;

    // Events
    public event Action OnMount;
    public event Action OnDismount;
    public event Action OnSpecialAbility;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        // Calculate current speed based on multiplier
        if (PlayerController player = FindObjectOfType<PlayerController>())
        {
            currentSpeed = 2f * speedMultiplier; // Base walk speed * multiplier
        }
    }

    private void Start()
    {
        // Deactivate effects initially
        if (sparkleTrail != null) sparkleTrail.SetActive(false);
        if (speedLines != null) speedLines.SetActive(false);
    }

    /// <summary>
    /// Mount player on vehicle
    /// </summary>
    public void Mount(PlayerController player)
    {
        if (isMounted) return;

        currentRider = player;
        isMounted = true;

        // Activate visual effects
        if (sparkleTrail != null) sparkleTrail.SetActive(true);
        if (speedLines != null) speedLines.SetActive(true);

        // Play mount sound
        if (mountSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(mountSound.name);
        }

        // Play engine sound (loop)
        if (engineSound != null && AudioManager.Instance != null)
        {
            // TODO: Implement looping engine sound
        }

        // Trigger animation
        if (animator != null)
        {
            animator.SetBool("IsMounted", true);
        }

        // Trigger event
        OnMount?.Invoke();

        Debug.Log($"{player.name} mounted {vehicleType}");
    }

    /// <summary>
    /// Dismount player from vehicle
    /// </summary>
    public void Dismount()
    {
        if (!isMounted) return;

        currentRider = null;
        isMounted = false;

        // Deactivate effects
        if (sparkleTrail != null) sparkleTrail.SetActive(false);
        if (speedLines != null) speedLines.SetActive(false);

        // Stop engine sound
        // TODO: Stop looping sound

        // Trigger animation
        if (animator != null)
        {
            animator.SetBool("IsMounted", false);
        }

        // Trigger event
        OnDismount?.Invoke();

        Debug.Log($"Dismounted {vehicleType}");
    }

    /// <summary>
    /// Use special ability (horn for car, bell for scooter)
    /// </summary>
    public void UseSpecialAbility()
    {
        if (!isMounted) return;

        // Check cooldown
        if (Time.time - lastSpecialAbilityTime < specialAbilityCooldown)
        {
            return; // Still on cooldown
        }

        lastSpecialAbilityTime = Time.time;

        // Play appropriate sound
        if (AudioManager.Instance != null)
        {
            switch (vehicleType)
            {
                case VehicleType.ToyCar:
                    if (hornSound != null)
                    {
                        AudioManager.Instance.PlaySFX(hornSound.name);
                    }
                    break;

                case VehicleType.Scooter:
                    if (bellSound != null)
                    {
                        AudioManager.Instance.PlaySFX(bellSound.name);
                    }
                    break;
            }
        }

        // Trigger animation
        if (animator != null)
        {
            animator.SetTrigger("SpecialAbility");
        }

        // Trigger event
        OnSpecialAbility?.Invoke();

        Debug.Log($"{vehicleType} special ability used!");
    }

    /// <summary>
    /// Detect player entering mount range
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isMounted) return;

        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null && !player.isRidingVehicle)
        {
            // Show "Tap to ride!" prompt
            // TODO: Implement UI prompt
            Debug.Log($"Near {vehicleType} - tap to ride!");
        }
    }

    /// <summary>
    /// Player left mount range
    /// </summary>
    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            // Hide prompt
            // TODO: Hide UI prompt
        }
    }

    /// <summary>
    /// Get vehicle stats
    /// </summary>
    public string GetVehicleStats()
    {
        return $"{vehicleType}: Speed x{speedMultiplier}, Jump x{jumpMultiplier}";
    }
}

/// <summary>
/// Vehicle types
/// </summary>
public enum VehicleType
{
    ToyCar,
    Scooter
}
