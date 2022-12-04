using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] typesofEnemy;
    public float respawnTime = 2f;

    public int enemyspawnCount = 10;
    public GameController gameController;

    private bool lastEnemySpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameObjectSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (lastEnemySpawned && FindObjectOfType<DefaultEnemyScript>() == null)
        {
            StartCoroutine(gameController.LevelCompleted());
        }
    }

    IEnumerator GameObjectSpawner()
    {
        for (int i = 0; i < enemyspawnCount; i++)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }

        lastEnemySpawned = true;
    }

    void RandomSpawnTime()
    {

    }
   
    void SpawnEnemy()
    {
        int randomNumber = Random.Range(0, typesofEnemy.Length);
        int randomXpos = Random.Range(-6, 6);
        Instantiate(typesofEnemy[randomNumber], new Vector2(randomXpos, transform.position.y), Quaternion.identity);
    }
}
