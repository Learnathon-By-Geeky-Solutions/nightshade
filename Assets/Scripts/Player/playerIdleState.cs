using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace.Players
{
    public class PlayerIdleState : PlayerGroundedState
    {
        private const float FLOAT_TOLERANCE = 0.0001f;  // Small tolerance for floating-point comparison

        public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.SetZeroVelocity();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            // Using tolerance to check if xInput is approximately equal to player.facingDir
            if (Mathf.Abs(xInput - player.facingDir) < FLOAT_TOLERANCE && player.IsWallDetected())
                return;

            // Using tolerance to check if xInput is not approximately 0
            if (Mathf.Abs(xInput) > FLOAT_TOLERANCE && !player.isBusy)
                stateMachine.ChangeState(player.moveState);
        }
    }
}
