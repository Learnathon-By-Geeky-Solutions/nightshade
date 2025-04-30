using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Enemies
{
    public class EnemyShadow : Enemy
    {
        #region States

        public ShadowIdleState idleState { get; private set; }
        public ShadowMoveState moveState { get; private set; }
        public ShadowBattleState battleState { get; private set; }
        public ShadowAttackState attackState { get; private set; }

        public ShadowStunnedState stunnedState { get; private set; }
        public ShadowDeadState deadState { get; private set; }
        #endregion

        protected override void Awake()
        {
            base.Awake();

            idleState = new ShadowIdleState(this, stateMachine, "Idle", this);
            moveState = new ShadowMoveState(this, stateMachine, "Move", this);
            battleState = new ShadowBattleState(this, stateMachine, "Move", this);
            attackState = new ShadowAttackState(this, stateMachine, "Attack", this);
            stunnedState = new ShadowStunnedState(this, stateMachine, "Stunned", this);
            deadState = new ShadowDeadState(this, stateMachine, "Idle", this);
        }

        protected override void Start()
        {
            base.Start();
            stateMachine.Initialize(idleState);
        }

        protected override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.U))
            {
                stateMachine.ChangeState(stunnedState);
            }

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