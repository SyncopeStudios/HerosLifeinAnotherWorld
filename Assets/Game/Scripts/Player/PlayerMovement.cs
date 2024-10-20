using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] public float speed;
    [SerializeField] private AudioClip SfxWalk;

    public Vector2 MoveDirection => moveDirection;

    private PlayerAnimations playerAnimations;
    private PlayerActions actions;
    private Player player;
    private Rigidbody2D rb2D;
    private Vector2 moveDirection;
    private bool isMoving;

    private void Awake()
    {
        player = GetComponent<Player>();
        actions = new PlayerActions();
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (player.Stats.Health <= 0) return;
        rb2D.MovePosition(rb2D.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;

        if (moveDirection == Vector2.zero)
        {
            playerAnimations.SetMoveBoolTransition(false);
            StopWalkingSound();
            return;
        }

        playerAnimations.SetMoveBoolTransition(true);
        playerAnimations.SetMoveAnimation(moveDirection);
        PlayWalkingSound();
    }

    private void PlayWalkingSound()
    {
        if (!isMoving) // Only play if not already playing
        {
            if (SfxWalk != null) // Check if there's a valid walking sound
            {
                AudioManager.Instance.PlaySoundEffect(SfxWalk);
                isMoving = true;
            }
        }
    }

    private void StopWalkingSound()
    {
        if (isMoving)
        {
            AudioManager.Instance.StopSFXSound();
            isMoving = false;
        }
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
    
}
