using MyGameNamespace.Stats;
using MyGameNamespace.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace.Enemies
{
    public class SlimeBattleState : EnemyState
    {
        private EnemySlime enemy;
        private Transform player;
        private int moveDir;

        public SlimeBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemySlime _enemy)
            : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = _enemy;
        }

        public override void Enter()
        {
            base.Enter();

            player = PlayerManager.instance.player.transform;

            if (player.GetComponent<PlayerStats>().isDead)
                stateMachine.ChangeState(enemy.moveState);
        }

        public override void Update()
        {
            base.Update();

            if (enemy.IsPlayerDetected())
            {
                stateTimer = enemy.battleTime;

                if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
                {
                    if (CanAttack())
                        stateMachine.ChangeState(enemy.attackState);
                }
                else
                {
                    if (stateTimer < 1f || Vector2.Distance(player.transform.position, enemy.transform.position) > 7)
                    {
                        stateMachine.ChangeState(enemy.moveState);
                    }
                }

                if (player.transform.position.x > enemy.transform.position.x)
                    moveDir = 1;
                else
                    moveDir = -1;

                enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
            }
        }

        private bool CanAttack()
        {
            if (Time.time > enemy.lastTimeAttacked + enemy.attackCooldown)
            {
                enemy.attackCooldown = Random.Range(enemy.minAttackCooldown, enemy.maxAttackCooldown);
                enemy.lastTimeAttacked = Time.time;
                return true;
            }
            return false;
        }
    }
}
