using MyGameNamespace.Enemies;
using MyGameNamespace.Stats;
using MyGameNamespace.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Controllers
{
    public class ThunderStrikeController : MonoBehaviour
    {
        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Enemy>() != null)
            {
                PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
                EnemyStats enemyTarget = collision.GetComponent<EnemyStats>();
                playerStats.DoMagicalDamage(enemyTarget);
            }
        }
    }
}