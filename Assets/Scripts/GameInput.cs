using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnDash;
    public event EventHandler OnFire;
    private PlayerInputAction playerInputAction;

    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Enable();

        playerInputAction.Player.Dash.performed += Dash_performed;
        playerInputAction.Player.Fire.performed += Fire_performed;
    }

    private void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnFire?.Invoke(this, EventArgs.Empty);
    }

    private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnDash?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
