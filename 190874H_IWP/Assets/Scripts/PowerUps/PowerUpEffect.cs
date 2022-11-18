using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpEffect : ScriptableObject
{
    public float currentCooldown = 0f;
    public float maxCooldown;

    public void PutOnCooldown()
    {
        CooldownManager.cooldownmanagerInstance.StartCooldown(this);
    }

    public virtual void ResetBuff(PlayerController playerController)
    {

    }

    public bool IsAbilityReady()
    {
        if (currentCooldown <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public abstract void ApplyBuff(GameObject target);
}
