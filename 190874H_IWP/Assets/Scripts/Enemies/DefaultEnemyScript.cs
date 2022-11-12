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
    public float enemyHealth = 10f;

    //Healthbar UI
    float enemybarSize = 1f;
    public float enemyDamage = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyNormalShooting());
        enemyDamage = enemybarSize / enemyHealth;
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

            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
                GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity); //enemy explosion animation
                Destroy(explosion, 0.5f);
            }
        }
    }

    void AdjustEnemyHealthBar() //if gets damaged by player (Healthbar UI for enemy)
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= 1;
            enemybarSize = enemybarSize - enemyDamage;
            enemyHealthbar.SizeAdjustEnemyHealth(enemybarSize);
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
