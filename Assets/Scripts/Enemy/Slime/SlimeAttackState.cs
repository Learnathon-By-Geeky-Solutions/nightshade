using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Enemies
{
    public class SlimeAttackState : EnemyState
    {
        protected EnemySlime enemy;

        public SlimeAttackState(EnemySlime _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySlime __enemy)
            : base(_enemy, _stateMachine, _animBoolName)
        {
            this.enemy = __enemy;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
            enemy.lastTimeAttacked = Time.time;
        }

        public override void Update()
        {
            base.Update();

            enemy.SetZeroVelocity();

            if (triggerCalled)
                stateMachine.ChangeState(enemy.battleState);
        }
    }
}