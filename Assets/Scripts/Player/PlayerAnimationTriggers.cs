using Enemy;
using Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class PlayerAnimationTriggers : MonoBehaviour
    {
        private Player player => GetComponentInParent<Player>();

        private void AnimationTrigger()
        {
            player.AnimationTrigger();
        }

        private void AttackTrigger()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

            foreach (var hit in colliders)
            {
                if (hit.GetComponent<Enemy.Enemy>() != null)
                    hit.GetComponent<Enemy.Enemy>().Damage();

                //hit.GetComponent<Enemy>()?.Damage();
            }
        }

        private void ThrowSword()
        {
            SkillManager.instance.sword.CreateSword();
        }
    }
}