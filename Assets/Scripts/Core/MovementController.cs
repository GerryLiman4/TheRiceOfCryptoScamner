using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public
    abstract class MovementController : MonoBehaviour
{
    protected Vector2 moveDirection;

    protected Vector2 moveVelocity;
    
    [SerializeField] protected float moveSpeed;

    [SerializeField] protected float jumpSpeed;

    protected Rigidbody2D rigidBody2D;
    public abstract void Initialize(Rigidbody2D rigidBody2D, float moveSpeed = 0, float jumpSpeed = 0f);
    public abstract void Move(Vector2 directionInput);

}
