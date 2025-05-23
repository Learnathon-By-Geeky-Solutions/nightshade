using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Enemies
{
    public class EnemySlime : Enemy
    {
        [Header("Attack Cooldowns")]
        public float minAttackCooldown = 1f;   // Minimum seconds between attacks
        public float maxAttackCooldown = 3f;   // Maximum seconds between attacks

        #region States
        public SlimeIdleState idleState { get; private set; }
        public SlimeMoveState moveState { get; private set; }
        public SlimeBattleState battleState { get; private set; }
        public SlimeAttackState attackState { get; private set; }
        public SlimeStunnedState stunnedState { get; private set; }
        public SlimeDeadState deadState { get; private set; }
        #endregion

        protected override void Awake()
        {
            base.Awake();

            SetupDefaultFacingDir(-1);

            idleState = new SlimeIdleState(this, stateMachine, "Idle", this);
            moveState = new SlimeMoveState(this, stateMachine, "Move", this);
            battleState = new SlimeBattleState(this, stateMachine, "Move", this);
            attackState = new SlimeAttackState(this, stateMachine, "Attack", this);
            stunnedState = new SlimeStunnedState(this, stateMachine, "Stunned", this);
            deadState = new SlimeDeadState(this, stateMachine, "Dead", this);
        }

        protected override void Start()
        {
            base.Start();
            stateMachine.Initialize(idleState);
        }

        public override bool CanBeStunned()
        {
            if (base.CanBeStunned())
            {
                stateMachine.ChangeState(stunnedState);
                return true;
            }

            return false;
        }

        public override void Die()
        {
            base.Die();
            stateMachine.ChangeState(deadState);
        }

    }
}