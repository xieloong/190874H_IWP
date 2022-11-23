using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{  
    public PowerUpEffect powerupEffect;

    public Transform rotationCenter;
    [SerializeField] float rotationRadius = 2f;
    [SerializeField] float angularSpeed = 2f;
    float posX, posY, angle = 0f; 
    public float TravelXSpeed = 2f;
    float newTravelXSpeed;

    public float TravelYSpeed = 2f;
    float newTravelYSpeed;

    void Start()
    {
        InvokeRepeating("RandomSpeed", 0, 0.5f);
    }

    void RandomSpeed()
    {
        TravelXSpeed = newTravelXSpeed;
        TravelYSpeed = newTravelYSpeed;
        newTravelXSpeed = Random.Range(-5f, 3);
        newTravelYSpeed = Random.Range(-3f, 5);
    }

    void Update()
    {
        UpdateRandomMovementPowerUp();
    }

    void UpdateRandomMovementPowerUp()
    {
        transform.Translate(Vector2.right * TravelXSpeed * Time.deltaTime);
        transform.Translate(Vector2.down * TravelYSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            powerupEffect.ApplyBuff(collision.gameObject);
        }
        
    }
}
