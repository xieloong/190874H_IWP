using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/InvulnerableUp")]
public class InvulnerableUp : PowerUpEffect
{
    public override void ApplyBuff(GameObject target)
    {
        if (IsAbilityReady())
        {
            target.GetComponent<PlayerController>().GetComponent<Collider2D>().enabled = false;
            PutOnCooldown();
        }
        else
        {
            return;
        }
    }

    public override void ResetBuff(PlayerController playerController)
    {
        playerController.GetComponent<Collider2D>().enabled = true;
    }
}
