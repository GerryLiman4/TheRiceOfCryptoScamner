using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    private readonly int WalkHash = Animator.StringToHash("Walk");
    private const float CrossFadeDuration = 0.1f;

    public PlayerWalkingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        this.stateMachine = stateMachine;
        
    }

    public override StateID CurrentStateID { get; set; }

    public override void Enter()
    {
        base.Enter();
        stateMachine.animator.CrossFadeInFixedTime(WalkHash, 0);
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
        base.LateTick();
    }

    public override void Tick(float deltaTime)
    {
        base.Tick(deltaTime);
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
        stateMachine.SwitchState(new PlayerJumpState(this.stateMachine));
    }

    protected override void OnMove(Vector2 direction)
    {
        stateMachine.playerMovementController.Move(stateMachine.playerInputReader.movement);
        Flip(stateMachine.playerInputReader.movement);
    }

    protected override void OnStop()
    {
        stateMachine.SwitchState(new PlayerIdleState(this.stateMachine));
    }
}
