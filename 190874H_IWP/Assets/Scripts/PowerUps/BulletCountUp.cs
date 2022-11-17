using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/BulletCountUp")]
public class BulletCountUp : PowerUpEffect
{
    public float bulletSpawnTime = 0.1f;
    public override void ApplyBuff(GameObject target)
    {
        target.GetComponent<PlayerController>().spawntimeBullet = bulletSpawnTime;
    }
}
