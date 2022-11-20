using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : MonoBehaviour
{
    public static CooldownManager cooldownmanagerInstance;

    public List<PowerUpEffect> AbilitiesOnCooldown = new List<PowerUpEffect>();

    void Awake()
    {
        if (cooldownmanagerInstance == null)
        {
            cooldownmanagerInstance = this;
        }
        else if (cooldownmanagerInstance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    void Update()
    {
        for (int i = 0; i < AbilitiesOnCooldown.Count; i++)
        {
            AbilitiesOnCooldown[i].currentCooldown -= Time.deltaTime;
            if (AbilitiesOnCooldown[i].currentCooldown <= 0)
            {
                AbilitiesOnCooldown[i].currentCooldown = 0;
                AbilitiesOnCooldown[i].ResetBuff(GetComponent<PlayerController>());
                AbilitiesOnCooldown.Remove(AbilitiesOnCooldown[i]);
            }
        }
    }

    public void StartCooldown(PowerUpEffect powerupEffect)
    {
        if (!AbilitiesOnCooldown.Contains(powerupEffect))
        {
            powerupEffect.currentCooldown = powerupEffect.maxCooldown;
            AbilitiesOnCooldown.Add(powerupEffect);
        }
    }

    public void ResetCooldown()
    {
        for (int i = 0; i < AbilitiesOnCooldown.Count; i++)
        {
            AbilitiesOnCooldown[i].currentCooldown -= Time.deltaTime;
            AbilitiesOnCooldown[i].currentCooldown = 0;
            AbilitiesOnCooldown[i].ResetBuff(GetComponent<PlayerController>());
            AbilitiesOnCooldown.Remove(AbilitiesOnCooldown[i]);          
        }
    }
}
