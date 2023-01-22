using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field:SerializeField] public PlayerInputReader playerInputReader { get;private set; }
    [field: SerializeField] public Animator animator { get;private set; }
    [field: SerializeField] public Rigidbody2D playerRigidbody { get; private set; }
    [field: SerializeField] public BoxCollider2D playerBoxCollider{ get; private set; }
    [field: SerializeField] public PlayerMovementController playerMovementController { get; private set; }
    [field: SerializeField] public GroundDetector groundDetector{ get; private set; }
    private void Start()
    {
        SwitchState(new PlayerIdleState(this, StateID.Idle));
        playerMovementController.Initialize(playerRigidbody);
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A)) {
    //        SwitchState(new PlayerWalkingState(this));
    //    }
    //}
}
