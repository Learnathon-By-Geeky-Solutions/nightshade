using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGroundedState : EnemyState
{
    protected EnemyShadow enemy;
    protected Transform player;

    public ShadowGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyShadow enemy)
        : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
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

        if(enemy.IsPlayerDetected())
            stateMachine.ChangeState(enemy.battleState);
    }
}
