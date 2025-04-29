using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ice and Fire effect", menuName = "Data/Item effect/Ice and Fire")]
public class IceAndFireEffect : ItemEffect
{
    [SerializeField] private GameObject iceAndFirePrefab;
    [SerializeField] private float xVelocity;

    public override void ExecuteEffect(Transform _enemyPosition)  // Renamed _respawnPosition to _enemyPosition
    {
        Player player = PlayerManager.instance.player;

        bool thirdAttack = player.primaryAttack.comboCounter == 2;

        if (thirdAttack)
        {
            GameObject newIceAndFire = Instantiate(iceAndFirePrefab, _enemyPosition.position, player.transform.rotation);  // Updated to _enemyPosition
            newIceAndFire.GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity * player.facingDir, 0);

            Destroy(newIceAndFire, 10);
        }
    }
}
