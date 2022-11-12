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

    public Transform spawnPoint;
    public Transform spawnPoint2;

    public GameObject playerBullet;
    public float spawntimeBullet = 2f;

    public GameObject muzzleFlash;

    public GameObject playerExplosion;

    public PlayerHealthbar playerHealthbar;
    public float playerHealth = 20f;

    //Healthbar UI
    float playerbarSize = 1f;
    public float playerDamaged = 0f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        muzzleFlash.SetActive(false);
        StartCoroutine(AutoFire());
        playerDamaged = playerbarSize / playerHealth;
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
        Instantiate(playerBullet, spawnPoint.position, Quaternion.identity);
        Instantiate(playerBullet, spawnPoint2.position, Quaternion.identity);
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
            AdjustPlayerHealthBar();
            Destroy(collision.gameObject);

            if (playerHealth <= 0)
            {
                Destroy(gameObject);
                GameObject playerExplode = Instantiate(playerExplosion, transform.position, Quaternion.identity);
                Destroy(playerExplode, 0.5f);
            }
        }
    }

    void AdjustPlayerHealthBar() //if gets damaged by player (Healthbar UI for enemy)
    {
        if (playerHealth > 0)
        {
            playerHealth -= 1;
            playerbarSize = playerbarSize - playerDamaged;
            playerHealthbar.SizeAdjustPlayerHealth(playerbarSize);
        }
    }
}
