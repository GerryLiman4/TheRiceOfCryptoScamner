using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    private readonly int FallHash = Animator.StringToHash("Fall");
    private const float CrossFadeDuration = 0.1f;
    private float jumpTimer;
    public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public override StateID CurrentStateID { get; set; }

    public override void Enter()
    {
        base.Enter();
        stateMachine.animator.CrossFadeInFixedTime(FallHash, 0);
        stateMachine.playerMovementController.Fall();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
      
    }

    public override void LateTick()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        base.Tick(deltaTime);
        
        if (stateMachine.playerRigidbody.velocity.y == 0)
        {
            stateMachine.SwitchState(new PlayerIdleState(this.stateMachine));
        }
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
        Flip(direction);
        stateMachine.playerMovementController.Move(direction);
    }

    protected override void OnStop()
    {
       
    }
}
