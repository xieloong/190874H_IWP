using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/BulletCountUp")]
public class BulletCountUp : PowerUpEffect
{
    float bulletSpawnTime = 0.1f;
    PlayerController playerController;

    void Awake()
    {

    }

    public override void ApplyBuff(GameObject target)
    {
        if (IsAbilityReady())
        {
            target.GetComponent<PlayerController>().spawntimeBullet = bulletSpawnTime;
            PutOnCooldown();
        }
        else
        {
            return;
        }
    }

    public override void ResetBuff(PlayerController playerController)
    {
        playerController.spawntimeBullet = 0.5f;
    }
}


