using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript2 : MonoBehaviour
{
    public GameObject shot;
    public Transform bulletSpawn;
    //public float bulletSpeed = 10f;
    //public float bulletDamageTaken = 1f;
    public float fireRate;
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}
