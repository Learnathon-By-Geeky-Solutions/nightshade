using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBattleState : EnemyState
{
    private Transform player; // Fixed spelling
    private Enemy_Shadow enemy;
    private int moveDir;

    public ShadowBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Shadow enemy)
        : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.player.transform;
    }

    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDetected())
        {
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                    stateMachine.ChangeState(enemy.attackState);
            }
        }

        if (player.position.x > enemy.transform.position.x) // Fixed spelling
            moveDir = 1;
        else if (player.position.x < enemy.transform.position.x) // Fixed spelling
            moveDir = -1;

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y); // Use enemy's Rigidbody
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool CanAttack()
    {
        if(Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }
}
