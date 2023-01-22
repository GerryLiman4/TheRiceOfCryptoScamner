using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private readonly int JumpHash = Animator.StringToHash("Jump");
    private const float CrossFadeDuration = 0.1f;
    private float jumpTimer;
    private float jumpTime;
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public override StateID CurrentStateID { get; set; }

    public override void Enter()
    {
        base.Enter();
        stateMachine.animator.CrossFadeInFixedTime(JumpHash, 0);
        jumpTime = stateMachine.playerMovementController.jumpTime;
        jumpTimer = 0;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        Debug.Log(stateMachine.playerRigidbody.velocity.y);
        if (stateMachine.playerRigidbody.velocity.y >= 0) return;
        Debug.Log("Masuk Sini");
        stateMachine.SwitchState(new PlayerFallState(this.stateMachine));
    }

    public override void LateTick()
    {
        // if (stateMachine.playerInputReader.movement == Vector2.zero) stateMachine.SwitchState(new PlayerIdleState(this.stateMachine));
    }

    public override void Tick(float deltaTime)
    {
        base.Tick(deltaTime);
       
        if (!stateMachine.playerInputReader.isJumping && jumpTimer < stateMachine.playerMovementController.maxHoldTime)
        {
            stateMachine.SwitchState(new PlayerFallState(this.stateMachine));
            return;
        }
        jumpTimer += Time.deltaTime;
        
        if (jumpTimer > jumpTime) return;
        stateMachine.playerMovementController.Jump(jumpTimer);
        
    }


    protected override void Flip(Vector2 direction)
    {
        if (direction.x > 0 && stateMachine.transform.localScale.x > 0) return;
        else if (direction.x < 0 && stateMachine.transform.localScale.x < 0) return;
        else if (direction.x == 0) return;

        stateMachine.transform.localScale = new Vector3(-stateMachine.transform.localScale.x, stateMachine.transform.localScale.y, stateMachine.transform.localScale.z);
    }

    protected override void OnJump()
    {

    }

    protected override void OnMove(Vector2 direction)
    {
        stateMachine.playerMovementController.Move(stateMachine.playerInputReader.movement);
        Flip(stateMachine.playerInputReader.movement);
    }

    protected override void OnStop()
    {

    }
}
