using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PowerUps/HealthUp")]
public class HealthUp : PowerUpEffect
{
    public float addHealth = 10f;
    public override void ApplyBuff(GameObject target)
    {
        if (IsAbilityReady())
        {
            if (target.GetComponent<PlayerController>().currentplayerHealth < target.GetComponent<PlayerController>().maxplayerHealth)
            {
                target.GetComponent<PlayerController>().currentplayerHealth += addHealth;
                if (target.GetComponent<PlayerController>().currentplayerHealth >= target.GetComponent<PlayerController>().maxplayerHealth)
                {
                    target.GetComponent<PlayerController>().currentplayerHealth = target.GetComponent<PlayerController>().maxplayerHealth;
                }
            }
        }
        else
        {
            return;
        }
    }

    public override void ResetBuff(PlayerController playerController)
    {
        
    }
}
