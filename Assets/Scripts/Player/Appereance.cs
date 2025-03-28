using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appereance : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private const string IS_WALKING = "IsWalk";

    private void Awake()
    {
       animator = GetComponent<Animator>();
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, Player.Instance.IsWalking());
        ChooseDirection();
    }

    private void ChooseDirection() {
        Vector2 lastMove = Player.Instance.GetLastMoveDirection();

        if (lastMove.x < 0) 
        {
            spriteRenderer.flipX = true;
        } 
        else if (lastMove.x > 0) 
        {
            spriteRenderer.flipX = false;
        }
    }
}