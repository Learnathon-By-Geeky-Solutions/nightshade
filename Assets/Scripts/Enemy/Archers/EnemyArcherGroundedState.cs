using MyGameNamespace.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Enemies
{
    public class ArcherGroundedState : EnemyState
    {
        protected Transform player;
        protected EnemyArcher enemy;

        public ArcherGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyArcher _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = _enemy;
        }

        public override void Enter()
        {
            base.Enter();

            player = PlayerManager.instance.player.transform;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();


            if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < enemy.agroDistance)
            {
                stateMachine.ChangeState(enemy.battleState);
            }
        }
    }
}