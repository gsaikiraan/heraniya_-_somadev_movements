using UnityEngine;
using System;

/// <summary>
/// Input handler - processes all player input
/// Designed for simple tap-anywhere controls perfect for toddlers
/// </summary>
public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }

    [Header("Input Settings")]
    [SerializeField] private bool enableTouchInput = true;
    [SerializeField] private bool enableMouseInput = true; // For testing on desktop
    [SerializeField] private bool enableKeyboardInput = true; // For testing

    // Events
    public event Action OnTapAnywhere;
    public event Action<Vector2> OnTapPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        ProcessInput();
    }

    /// <summary>
    /// Process all input types
    /// </summary>
    private void ProcessInput()
    {
        // Touch input (primary for mobile)
        if (enableTouchInput && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                HandleTap(touch.position);
            }
        }

        // Mouse input (for desktop testing)
        else if (enableMouseInput && Input.GetMouseButtonDown(0))
        {
            HandleTap(Input.mousePosition);
        }

        // Keyboard input (for testing - Space = tap)
        else if (enableKeyboardInput && Input.GetKeyDown(KeyCode.Space))
        {
            HandleTap(Vector2.zero);
        }
    }

    /// <summary>
    /// Handle tap input
    /// </summary>
    private void HandleTap(Vector2 screenPosition)
    {
        // Trigger tap-anywhere event
        OnTapAnywhere?.Invoke();

        // Trigger position-specific event
        OnTapPosition?.Invoke(screenPosition);

        Debug.Log($"Tap detected at: {screenPosition}");
    }

    /// <summary>
    /// Get world position of tap
    /// </summary>
    public Vector3 GetTapWorldPosition(Vector2 screenPosition)
    {
        return Camera.main.ScreenToWorldPoint(screenPosition);
    }

    /// <summary>
    /// Check if input is currently disabled (during cutscenes, etc.)
    /// </summary>
    public bool IsInputEnabled()
    {
        // Could check game state here
        if (GameManager.Instance != null)
        {
            return GameManager.Instance.currentState == GameState.Playing;
        }

        return true;
    }
}
