using UnityEngine;
namespace MyGameNamespace.Enemies
{
    public class ArcherJumpState : EnemyState
    {
        private EnemyArcher enemy;

        public ArcherJumpState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyArcher _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = _enemy;
        }

        public override void Enter()
        {
            base.Enter();

            enemy.rb.velocity = new Vector2(enemy.jumpVelocity.x * -enemy.facingDir, enemy.jumpVelocity.y);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            enemy.anim.SetFloat("yVelocity", enemy.rb.velocity.y);

            if (rb.velocity.y < 0 && enemy.IsGroundDetected())
                stateMachine.ChangeState(enemy.battleState);
        }
    }
}