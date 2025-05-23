using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Players
{
    public class PlayerDeadState : PlayerState
    {
        public PlayerDeadState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
        {
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
        }

       

        public override void Update()
        {
            base.Update();

            player.SetZeroVelocity();
        }
    }
}