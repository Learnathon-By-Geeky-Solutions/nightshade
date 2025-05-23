using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace.Enemies
{
    public class SlimeIdleState : SlimeGroundedState
    {
        public SlimeIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemySlime _enemy)
            : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
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
