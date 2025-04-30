using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace.Enemies
{
    public class ShadowMoveState : ShadowGroundedState
    {
        public ShadowMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyShadow enemy)
            : base(_enemyBase, _stateMachine, _animBoolName, enemy)
        {
        }

        public override void Update()
        {
            base.Update();

            enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.velocity.y);

            if (enemy.IsWallDetected() || !enemy.IsGroundDetected())
            {
                enemy.Flip();
                stateMachine.ChangeState(enemy.idleState);
            }
        }
    }
}
