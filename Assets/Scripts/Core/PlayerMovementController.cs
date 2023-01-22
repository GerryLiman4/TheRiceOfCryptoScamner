using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MovementController
{
    [SerializeField] public float jumpTime = 0.25f;
    [SerializeField] public float maxHoldTime = 0.20f;
    [SerializeField] private float jumpBoostTreshold = 0.05f;
    [SerializeField] private float jumpBoostMultiplier = 1.25f;
    private Vector2 gravityPull;
    public override void Initialize(Rigidbody2D rigidBody2D, float moveSpeed = 0, float jumpSpeed = 0)
    {
        this.rigidBody2D = rigidBody2D;
        gravityPull = Physics2D.gravity;
        if (moveSpeed != 0)
        {
            this.moveSpeed = moveSpeed;
        }
        if (jumpSpeed != 0)
        {
            this.jumpSpeed = jumpSpeed;
        }
    }

    public override void Move(Vector2 directionInput)
    {
        moveVelocity = new Vector2(directionInput.x * moveSpeed, rigidBody2D.velocity.y);
    }
    public void Move(Vector2 directionInput, StateID state)
    {
        switch (state)
        {
            case StateID.Idle: 
                rigidBody2D.velocity = new Vector2(moveVelocity.x, gravityPull.y);
                moveVelocity = new Vector2(directionInput.x * moveSpeed, rigidBody2D.velocity.y);
                break;
            default :
                Move(directionInput);
                break;
        }
    }

    public void Fall()
    {
        rigidBody2D.velocity = new Vector2(moveVelocity.x, gravityPull.y);
        moveVelocity = new Vector2(rigidBody2D.velocity.x, rigidBody2D.velocity.y);
    }

    public void Jump(float holdTime)
    {
        if (holdTime > 0)
        {
            if (holdTime < jumpBoostTreshold)
            {
                moveVelocity = new Vector2(rigidBody2D.velocity.x, 1 * jumpSpeed * jumpBoostMultiplier);
            }
            else if (holdTime < maxHoldTime)
            {
                moveVelocity = new Vector2(rigidBody2D.velocity.x, 1 * jumpSpeed);
            }
            else
            {
                Fall();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        rigidBody2D.velocity = moveVelocity;
    }
}
