using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace.Enemies
{
    public class ShadowIdleState : ShadowGroundedState
    {
        public ShadowIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyShadow enemy) : base(_enemyBase, _stateMachine, _animBoolName, enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();
            stateTimer = enemy.idleTime;
        }

        public override void Update()
        {
            base.Update();

            if (stateTimer < 0)
                stateMachine.ChangeState(enemy.moveState);
        }
    }
}
