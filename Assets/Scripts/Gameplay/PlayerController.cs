using UnityEngine;
using System;

/// <summary>
/// Player character controller - handles movement, jumping, and vehicle interaction
/// Designed for toddler-friendly one-tap controls
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 3f;
    [SerializeField] private float currentSpeed;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool allowDoubleJump = true;
    [SerializeField] private float coyoteTime = 0.2f; // Grace period after leaving ground
    [SerializeField] private float jumpBufferTime = 0.2f; // Input buffer

    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [Header("State")]
    public PlayerState currentState = PlayerState.Walking;
    public bool isGrounded;
    private bool canDoubleJump;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    [Header("Vehicle")]
    private VehicleController currentVehicle;
    public bool isRidingVehicle => currentVehicle != null;

    // Components
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Events
    public event Action OnJump;
    public event Action OnLand;
    public event Action<CollectibleType> OnCollectItem;
    public event Action OnMountVehicle;
    public event Action OnDismountVehicle;

    // Animation parameter IDs (cached for performance)
    private int animIDSpeed;
    private int animIDGrounded;
    private int animIDJump;
    private int animIDRiding;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Cache animation parameter IDs
        animIDSpeed = Animator.StringToHash("Speed");
        animIDGrounded = Animator.StringToHash("Grounded");
        animIDJump = Animator.StringToHash("Jump");
        animIDRiding = Animator.StringToHash("Riding");

        currentSpeed = walkSpeed;
    }

    private void Start()
    {
        // Subscribe to input
        if (InputHandler.Instance != null)
        {
            InputHandler.Instance.OnTapAnywhere += HandleJumpInput;
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from input
        if (InputHandler.Instance != null)
        {
            InputHandler.Instance.OnTapAnywhere -= HandleJumpInput;
        }
    }

    private void Update()
    {
        CheckGroundStatus();
        UpdateTimers();
        UpdateState();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    /// <summary>
    /// Check if player is on the ground
    /// </summary>
    private void CheckGroundStatus()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Just landed
        if (!wasGrounded && isGrounded)
        {
            OnLand?.Invoke();
            canDoubleJump = allowDoubleJump;

            // Play landing sound
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX("Land");
            }
        }

        // Coyote time - grace period after leaving ground
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Update timers (coyote time, jump buffer)
    /// </summary>
    private void UpdateTimers()
    {
        if (jumpBufferCounter > 0)
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Update player state machine
    /// </summary>
    private void UpdateState()
    {
        switch (currentState)
        {
            case PlayerState.Walking:
                // Auto-walk forward
                break;

            case PlayerState.Jumping:
                // In air
                if (isGrounded && rb.velocity.y <= 0.1f)
                {
                    currentState = PlayerState.Walking;
                }
                break;

            case PlayerState.RidingVehicle:
                // On vehicle
                break;

            case PlayerState.Tiptoeing:
                // Quiet walk (Level 3)
                break;
        }
    }

    /// <summary>
    /// Apply movement to rigidbody
    /// </summary>
    private void ApplyMovement()
    {
        // Auto-walk to the right (or vehicle speed if riding)
        float moveSpeed = isRidingVehicle ? currentVehicle.currentSpeed : currentSpeed;

        Vector2 velocity = rb.velocity;
        velocity.x = moveSpeed;
        rb.velocity = velocity;
    }

    /// <summary>
    /// Handle jump input
    /// </summary>
    private void HandleJumpInput()
    {
        // Add to jump buffer
        jumpBufferCounter = jumpBufferTime;

        // Try to jump
        TryJump();
    }

    /// <summary>
    /// Attempt to jump
    /// </summary>
    private void TryJump()
    {
        // Can jump if grounded (or within coyote time)
        if (coyoteTimeCounter > 0f || canDoubleJump)
        {
            Jump();
        }
    }

    /// <summary>
    /// Perform jump
    /// </summary>
    private void Jump()
    {
        // Determine if this is a double jump
        bool isDoubleJump = !isGrounded && canDoubleJump;

        if (isDoubleJump)
        {
            canDoubleJump = false;
        }

        // Reset coyote time
        coyoteTimeCounter = 0f;

        // Apply jump force
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset Y velocity
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // Update state
        currentState = PlayerState.Jumping;

        // Trigger event
        OnJump?.Invoke();

        // Play sound
        if (AudioManager.Instance != null)
        {
            string soundName = isDoubleJump ? "DoubleJump" : "Jump";
            AudioManager.Instance.PlaySFX(soundName);
        }

        // Trigger animation
        animator.SetTrigger(animIDJump);

        Debug.Log(isDoubleJump ? "Double Jump!" : "Jump!");
    }

    /// <summary>
    /// Mount a vehicle
    /// </summary>
    public void MountVehicle(VehicleController vehicle)
    {
        if (currentVehicle != null) return; // Already on vehicle

        currentVehicle = vehicle;
        currentState = PlayerState.RidingVehicle;

        // Position player on vehicle
        transform.SetParent(vehicle.transform);
        transform.localPosition = vehicle.riderPosition;

        // Notify vehicle
        vehicle.Mount(this);

        // Trigger event
        OnMountVehicle?.Invoke();

        // Play sound
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX("MountVehicle");
        }

        Debug.Log($"Mounted {vehicle.vehicleType}");
    }

    /// <summary>
    /// Dismount current vehicle
    /// </summary>
    public void DismountVehicle()
    {
        if (currentVehicle == null) return; // Not on vehicle

        VehicleController vehicle = currentVehicle;

        // Unparent from vehicle
        transform.SetParent(null);

        // Notify vehicle
        vehicle.Dismount();

        currentVehicle = null;
        currentState = PlayerState.Walking;
        currentSpeed = walkSpeed;

        // Trigger event
        OnDismountVehicle?.Invoke();

        Debug.Log("Dismounted vehicle");
    }

    /// <summary>
    /// Enable tiptoe mode (Level 3 - quiet walking)
    /// </summary>
    public void SetTiptoeMode(bool enabled)
    {
        if (enabled)
        {
            currentState = PlayerState.Tiptoeing;
            currentSpeed = walkSpeed * 0.5f; // Half speed
        }
        else
        {
            currentState = PlayerState.Walking;
            currentSpeed = walkSpeed;
        }
    }

    /// <summary>
    /// Update character animation
    /// </summary>
    private void UpdateAnimation()
    {
        animator.SetFloat(animIDSpeed, Mathf.Abs(rb.velocity.x));
        animator.SetBool(animIDGrounded, isGrounded);
        animator.SetBool(animIDRiding, isRidingVehicle);
    }

    /// <summary>
    /// Collect an item (called by Collectible scripts)
    /// </summary>
    public void CollectItem(CollectibleType type)
    {
        OnCollectItem?.Invoke(type);

        // Forward to collection system
        if (CollectionSystem.Instance != null)
        {
            CollectionSystem.Instance.CollectItem(type);
        }
    }

    private void OnDrawGizmos()
    {
        // Draw ground check radius
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}

/// <summary>
/// Player state enumeration
/// </summary>
public enum PlayerState
{
    Walking,
    Jumping,
    RidingVehicle,
    Tiptoeing
}
