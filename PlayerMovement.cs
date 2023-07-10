using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    SpriteRenderer spriteRenderer;
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider;

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;

    void Start()
    {
        // accessing components
        myRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();

    }

    void Update()
    {
        FlipSprite();
        Run();
        ClimbLadder();
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value) {
        if(!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

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

    void FlipSprite() {
        if (playerHasHorizontalSpeed()) {
            if (moveInput.x < 0) {
                transform.localScale = new Vector2(-1, 1);
            } else if (moveInput.x > 0) {
                transform.localScale = new Vector2(1, 1);
            }
        }
    }

    void ClimbLadder() {
        if(!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladders"))) return;

        bool playerHasVerticleSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;

        if (playerHasVerticleSpeed) {
           myAnimator.SetBool("isClimbing", true);
        } else {
           myAnimator.SetBool("isClimbing", false);
        }

        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;
    }

    bool playerHasHorizontalSpeed() {
        return Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    }


}
