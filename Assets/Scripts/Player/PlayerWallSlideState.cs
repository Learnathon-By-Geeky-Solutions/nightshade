using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Players
{
    public class PlayerWallSlideState : PlayerState
    {
        private const float epsilon = 0.01f;  // Small range value for floating-point comparison

        public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
        {
        }

       

      

        public override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.ChangeState(player.wallJump);
                return;
            }

            // Use Mathf.Approximately to compare floating-point values with a range tolerance
            if (Mathf.Abs(xInput - player.facingDir) > epsilon)
                stateMachine.ChangeState(player.idleState);

            if (yInput < 0)
                rb.velocity = new Vector2(0, rb.velocity.y);
            else
                rb.velocity = new Vector2(0, rb.velocity.y * 0.7f);

            if (player.IsGroundDetected())
                stateMachine.ChangeState(player.idleState);
        }
    }
}
