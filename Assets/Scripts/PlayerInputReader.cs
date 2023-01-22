using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour,_2DPlatformerControls.IPlayerInGameActions
{
    private _2DPlatformerControls platformerControls;

    public event Action Jump;
    public event Action<Vector2> Move;
    public event Action Stop;
    public event Action Sprint;
    public Vector2 movement;
    public bool isJumping;
    public bool isSprinting;

    public void OnJump(InputAction.CallbackContext context)
    {
        isJumping = context.performed;
        if (!context.performed) return;
        Jump?.Invoke();
    }   

    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        if (context.performed)
        {
         
            Move?.Invoke(movement);
            return;
        }
        Stop?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        platformerControls = new _2DPlatformerControls();
        platformerControls.PlayerInGame.SetCallbacks(this);
        platformerControls.PlayerInGame.Enable();
    }

    private void OnDestroy()
    {
        platformerControls.PlayerInGame.Disable();
        Jump = null;
        Stop = null;
        Move = null;
    }

    public void OnRunning(InputAction.CallbackContext context)
    {
        isSprinting = context.performed;
        if (!isSprinting) return;
        Sprint?.Invoke();
    }
}
