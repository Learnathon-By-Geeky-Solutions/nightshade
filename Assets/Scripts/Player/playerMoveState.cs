using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace.Players
{
    public class PlayerMoveState : PlayerGroundedState
    {
        private const float FLOAT_TOLERANCE = 0.0001f;  // Small tolerance for floating-point comparison

        public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
        {
        }

       

        public override void Update()
        {
            base.Update();

            // Set velocity with xInput * moveSpeed
            player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);

            // Use tolerance to check if xInput is approximately 0
            if (Mathf.Abs(xInput) < FLOAT_TOLERANCE || player.IsWallDetected())
                stateMachine.ChangeState(player.idleState);
        }
    }
}
