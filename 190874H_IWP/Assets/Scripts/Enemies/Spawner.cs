using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] typesofEnemy;
    public float respawnTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameObjectSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GameObjectSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
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
