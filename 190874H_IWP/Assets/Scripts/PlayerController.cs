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

    public GameObject playerBullet;
    public float spawntimeBullet = 2f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(AutoFire());
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
        Instantiate(playerBullet, transform.position, Quaternion.identity);
    }

    IEnumerator AutoFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawntimeBullet);
            SpawnBullet();
        }
    }
}
