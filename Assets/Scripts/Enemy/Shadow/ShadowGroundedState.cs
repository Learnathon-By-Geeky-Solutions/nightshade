using MyGameNamespace.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace.Enemies
{
    public class ShadowGroundedState : EnemyState
    {
        protected EnemyShadow enemy;
        protected Transform player;

        public ShadowGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyShadow _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = _enemy;
        }

        public override void Enter()
        {
            base.Enter();
            player = PlayerManager.instance.player.transform;
        }

        public override void Update()
        {
            base.Update();

            if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.transform.position) < 2)
                stateMachine.ChangeState(enemy.battleState);
        }
    }
}
