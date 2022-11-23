using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] typesofPowerUps;
    public float respawnTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PowerUptSpawner());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator PowerUptSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnPowerUp();
        }
    }

    void RandomSpawnTime()
    {

    }
   
    void SpawnPowerUp()
    {
        int randomNumber = Random.Range(0, typesofPowerUps.Length);
        int randomXpos = Random.Range(-6, 6);
        Instantiate(typesofPowerUps[randomNumber], new Vector2(randomXpos, transform.position.y), Quaternion.identity);
    }
}
