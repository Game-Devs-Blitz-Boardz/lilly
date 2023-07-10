using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    SpriteRenderer spriteRenderer;

    [SerializeField] float runSpeed = 10f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        FlipSprite();
        Run();
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }

    void FlipSprite() {
        float playerVelocity = myRigidbody.velocity.x;
        bool playerHasHorizontalSpeed = Mathf.Abs(playerVelocity) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            if (playerVelocity < 0) {
                 spriteRenderer.flipX = true;
            } else {
                spriteRenderer.flipX = false;
            }
        }
    }


}
