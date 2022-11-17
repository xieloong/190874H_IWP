using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private Vector2 movementInput = Vector2.zero;
    private Controls controls;

    Rigidbody2D rb2D;

    public Transform []spawnPoint;

    public GameObject playerBullet;
    public float spawntimeBullet = 2f;

    public GameObject muzzleFlash;

    public GameObject playerExplosion;

    public PlayerHealthbar playerHealthbar;
    public float maxplayerHealth = 20f;
    float currentplayerHealth;

    //Healthbar UI
    float playerbarSize = 1f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        muzzleFlash.SetActive(false);
        StartCoroutine(AutoFire());
        currentplayerHealth = maxplayerHealth;
    }

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * speed * Time.deltaTime);
        
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {

        movementInput = ctx.ReadValue<Vector2>();
    }

    public void SpawnBullet()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(playerBullet, spawnPoint[i].position, Quaternion.identity);
        }
    }

    IEnumerator AutoFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawntimeBullet);
            SpawnBullet();
            muzzleFlash.SetActive(true);
            yield return new WaitForSeconds(0.08f);
            muzzleFlash.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "EnemyBullet")
        {
            AdjustPlayerHealthBar(collision.gameObject);
            Destroy(collision.gameObject);

            if (currentplayerHealth <= 0)
            {
                Destroy(gameObject);
                GameObject playerExplode = Instantiate(playerExplosion, transform.position, Quaternion.identity);
                Destroy(playerExplode, 0.5f);
            }
        }
    }

    void AdjustPlayerHealthBar(GameObject collision) //if gets damaged by player (Healthbar UI for enemy)
    {
        if (currentplayerHealth > 0)
        {
            currentplayerHealth -= collision.GetComponent<BulletScript>().bulletDamageTaken;
            float percentageplayerHP = currentplayerHealth / maxplayerHealth;
            playerHealthbar.SizeAdjustPlayerHealth(percentageplayerHP);
        }
    }
}
