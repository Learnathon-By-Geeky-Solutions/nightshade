using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Shadow
{
    public class EnemyShadowAnimationTriggers : MonoBehaviour
    {
        private EnemyShadow enemy => GetComponentInParent<EnemyShadow>();


        public void AnimationTrigger()
        {
            enemy.AnimationFinishTrigger();
        }


        private void AttackTrigger()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);

            foreach (var hit in colliders)
            {
                if (hit.GetComponent<Player.Player>() != null)
                    hit.GetComponent<Player.Player>().Damage();
            }
        }

        private void OpenCounterWindow() => enemy.OpenCounterAttackWindow();
        private void CloseCounterWindow() => enemy.CloseCounterAttackWindow();
    }
}