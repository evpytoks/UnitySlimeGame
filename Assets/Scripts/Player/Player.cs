using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private Rigidbody2D rb;

    private const float MIN_MOVING_SPEED = 0.1f;

    [SerializeField] private float movingSpeed = 10f;
    private bool isWalking = false;
    private Vector2 lastMoveDirection = Vector2.right;

    private void Awake() 
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement() 
    {
        Vector2 inputVector = Input.Instance.GetMovementVector();
        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (inputVector.magnitude > MIN_MOVING_SPEED) 
        {
            isWalking = true;
            lastMoveDirection = inputVector.normalized;
        } 
        else 
        {
            isWalking = false;
        }
    }

    public bool IsWalking() 
    {
        return isWalking;
    }

    public Vector2 GetLastMoveDirection() 
    {
        return lastMoveDirection;
    }

    public void ChangeSpeed(float speedChenge)
    {
        movingSpeed *= speedChenge;
    }
}