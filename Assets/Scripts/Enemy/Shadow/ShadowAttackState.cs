using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Enemies
{
    public class ShadowAttackState : EnemyState
    {
        private EnemyShadow enemy;

        public ShadowAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyShadow _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = _enemy;
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