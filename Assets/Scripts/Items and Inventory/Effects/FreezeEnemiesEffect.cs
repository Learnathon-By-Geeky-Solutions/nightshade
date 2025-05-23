using MyGameNamespace.Enemies;
using MyGameNamespace.Items;
using MyGameNamespace.Stats;
using MyGameNamespace.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Effects
{
    [CreateAssetMenu(fileName = "Freeze enemeis effect", menuName = "Data/Item effect/Freeze enemies")]
    public class FreezeEnemiesEffect : ItemEffect
    {
        [SerializeField] private float duration;

        public override void ExecuteEffect(Transform _enemyPosition)  // Renamed _transform to _enemyPosition
        {
            PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

            if (playerStats.currentHealth > playerStats.GetMaxHealthValue() * .1f)
                return;

            if (!Inventory.instance.CanUseArmor())
                return;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(_enemyPosition.position, 2);  // Updated to _enemyPosition

            foreach (var hit in colliders)
            {
                hit.GetComponent<Enemy>()?.FreezeTimeFor(duration);
            }
        }
    }
}