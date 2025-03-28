using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public static Input Instance {get; private set;}
    private PlayerInputActions inputActions;

    private void Awake() 
    {
        Instance = this;
        inputActions = new PlayerInputActions();
        inputActions.Enable();
    }

    public Vector2 GetMovementVector() 
    {
        return inputActions.Player.Walk.ReadValue<Vector2>();
    }

    public Vector3 GetMousePosition() 
    {
        return Mouse.current.position.ReadValue();
    }
}
