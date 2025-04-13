using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
    public class ShadowAttackState : EnemyState
    {
        private EnemyShadow enemy;

        public ShadowAttackState(Enemys _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyShadow enemy)
            : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = enemy;
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