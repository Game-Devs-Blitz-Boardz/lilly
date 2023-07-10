using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    SpriteRenderer spriteRenderer;
    Animator myAnimator;

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;

    void Start()
    {
        // accessing components
        myRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();

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

    void OnJump(InputValue value) {
        if (value.isPressed) {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        if (playerHasHorizontalSpeed()) {
           myAnimator.SetBool("isRunning", true);
        } else {
           myAnimator.SetBool("isRunning", false);
        }
    }

    bool playerHasHorizontalSpeed() {
        return Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    }

    void FlipSprite() {
        if (playerHasHorizontalSpeed()) {
            if (moveInput.x < 0) {
                transform.localScale = new Vector2(-1, 1);
            } else if (moveInput.x > 0) {
                transform.localScale = new Vector2(1, 1);
            }
        }
    }


}
