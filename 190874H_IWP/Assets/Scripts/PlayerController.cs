using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private Vector2 movementInput;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
