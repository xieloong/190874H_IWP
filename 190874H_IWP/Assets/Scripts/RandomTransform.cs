using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransform : MonoBehaviour
{
    Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector2(0, 0);
        InvokeRepeating("ChangePosition", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangePosition()
    {
        transform.position = spawnPosition;
        //Compute position for next time
        spawnPosition = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
    }

}
