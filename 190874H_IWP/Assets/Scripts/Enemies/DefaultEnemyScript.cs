using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyScript : MonoBehaviour
{
    public float enemybulletspawnTime = 0.5f;

    public Transform enemybulletSpawnPoint;
    public GameObject enemyBullet;

    public GameObject enemyExplosion;

    public EnemyHealthbar enemyHealthbar;
    public float maxenemyHealth = 10f;
    public float currentenemyHealth;

    //Healthbar UI
    float enemybarSize = 1f;
    public float enemyDamaged = 0f;

    public GameObject damageEffect;
    [SerializeField] BlinkingEffect blinkingEffect;
    public BulletScript bulletScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyNormalShooting());
        currentenemyHealth = maxenemyHealth;
        enemyDamaged = enemybarSize / currentenemyHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            AdjustEnemyHealthBar();
            Destroy(collision.gameObject);

            blinkingEffect.Flash();

            GameObject DamageVFX = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(DamageVFX, 0.1f);

            if (currentenemyHealth <= 0)
            {
                Destroy(gameObject);
                GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity); //enemy explosion animation
                Destroy(explosion, 0.5f);
            }
        }
    }

    void AdjustEnemyHealthBar() //if gets damaged by player (Healthbar UI for enemy)
    {
        if (currentenemyHealth > 0)
        {
            currentenemyHealth -= bulletScript.bulletDamage;
            float percentageenemyHP = currentenemyHealth / maxenemyHealth;
            enemyHealthbar.SizeAdjustEnemyHealth(percentageenemyHP);
        }
    }

    void EnemyNormalFire()
    {
        Instantiate(enemyBullet, enemybulletSpawnPoint.position, Quaternion.identity);
    }

    IEnumerator EnemyNormalShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemybulletspawnTime);
            EnemyNormalFire();
        }
    }
}