using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public override void Enter()
    {
        stateMachine.playerInputReader.Jump += OnJump;
        stateMachine.playerInputReader.Move += OnMove;
        stateMachine.playerInputReader.Stop += OnStop;
    }


    public override void Exit()
    {
        stateMachine.playerInputReader.Jump -= OnJump;
        stateMachine.playerInputReader.Move -= OnMove;
        stateMachine.playerInputReader.Stop -= OnStop;
    }                                       
    protected abstract void Flip(Vector2 direction);

    public override void Tick(float deltaTime) {
        stateMachine.groundDetector.CheckGround();
        stateMachine.playerMovementController.Move(stateMachine.playerInputReader.movement);
    }

    public override void LateTick()
    {
        Debug.Log("fall" + !stateMachine.groundDetector.isGrounded);
        if (!stateMachine.groundDetector.isGrounded)
        {
            stateMachine.SwitchState(new PlayerFallState(this.stateMachine));
        }
    }

    protected abstract void OnJump();
    protected abstract void OnMove(Vector2 direction);
    protected abstract void OnStop();
}
