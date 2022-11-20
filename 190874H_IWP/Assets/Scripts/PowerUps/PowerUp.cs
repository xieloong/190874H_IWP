using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect powerupEffect;

    void Update()
    {
        //transform.Translate(Vector2.down * 3 * Time.deltaTime);
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
