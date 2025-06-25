using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// InputController is responsible for handling player input actions.
/// You can recieve input data value from this class.
/// 
/// Player actions include:
/// - Movement (is in 1D Axis, can only move left or right)
/// - Shooting (see if the player is shooting)
/// - Reloading (see if the player is reloading)
/// </summary>
public class InputController : MonoBehaviour
{
    public IA_Player inputActions;

    [Header("===== Player Actions =====")]
    public float moveDirection;

    public bool isShooting;
    public bool isReloading;
    private void Awake()
    {
        inputActions = new IA_Player();
    }

    /// <summary>
    /// Initializes the input actions and sets up the event listeners.
    /// Call this method to start receiving input events.
    /// </summary>
    public void Initialize()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<float>();
        Debug.Log("Move Direction: " + moveDirection);
    }

    /// <summary>
    /// Getter and Setter incase the class needs to access the input value
    /// </summary>

    public float Movement
    {
        get => moveDirection;
        set => moveDirection = value;
    }



}
