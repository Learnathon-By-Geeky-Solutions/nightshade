using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace.Players
{
    public class PlayerAirState : PlayerState
    {
        // Small epsilon value for floating point comparisons
        private const float epsilon = 0.0001f;

        public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
        {
        }

        

        public override void Update()
        {
            base.Update();

            // Check if the player is in contact with a wall or the ground
            if (player.IsWallDetected())
                stateMachine.ChangeState(player.wallSlide);

            if (player.IsGroundDetected())
                stateMachine.ChangeState(player.idleState);

            // Check if xInput is not zero using the epsilon value to avoid floating point issues
            if (Mathf.Abs(xInput) > epsilon)
                player.SetVelocity(player.moveSpeed * .8f * xInput, rb.velocity.y);
        }
    }
}
