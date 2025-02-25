using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    // Constructor
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) 
        : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // Additional logic for when entering the grounded state can go here.
    }

    public override void Exit()
    {
        base.Exit();
        // Additional logic for when exiting the grounded state can go here.
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Q))
            stateMachine.ChangeState(player.counterAttack);

        if (Input.GetKeyDown(KeyCode.Mouse0) )
            stateMachine.ChangeState(player.primaryAttack);

        if (!player.IsGroundDetected())
            stateMachine.ChangeState(player.airState);

        if (Input.GetKeyDown(KeyCode.Space) )
            stateMachine.ChangeState(player.jumpState);
    }
}
