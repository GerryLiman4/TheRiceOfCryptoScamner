using System;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private readonly int IdleHash = Animator.StringToHash("Idle");
    private const float CrossFadeDuration = 0.1f;
    public override StateID CurrentStateID { get; set; }
    public override StateID PreviousStateID { get; set; }

    public PlayerIdleState(PlayerStateMachine stateMachine, StateID previousStateID) : base(stateMachine,previousStateID)
    {
        this.stateMachine = stateMachine;
        this.PreviousStateID = previousStateID;
    }


    public override void Enter()
    {
        base.Enter();
        stateMachine.animator.CrossFade(IdleHash, 0);
        CurrentStateID = StateID.Idle;
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
        if (stateMachine.playerInputReader.movement != Vector2.zero)
        {
            stateMachine.SwitchState(new PlayerWalkingState(this.stateMachine, CurrentStateID));
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
        stateMachine.SwitchState(new PlayerJumpState(this.stateMachine, CurrentStateID));
    }

    protected override void OnMove(Vector2 direction)
    {
        Flip(stateMachine.playerInputReader.movement);
        if (stateMachine.playerInputReader.isSprinting)
        {
            stateMachine.SwitchState(new PlayerRunningState(this.stateMachine, CurrentStateID));
            return;
        }
        stateMachine.SwitchState(new PlayerWalkingState(this.stateMachine, CurrentStateID));
    }

    protected override void OnStop()
    {
        
    }

    protected override void OnSprint()
    {
        
    }
}
