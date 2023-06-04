using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class movement : MonoBehaviour
{
    #region Fields
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float bufferTime = 0.2f;
    [SerializeField] private bool canDoubleJump;
    [SerializeField] private bool canMoveVertical;
    [SerializeField] private int JumpCount = 2;

    public Animator animator;

    private Rigidbody2D rb;
    private bool checkShroomEaten = false;
    private bool isJumping;
    public bool isGrounded = false;
    private float CoyoteTimeCounter;
    private float bufferTimerCounter;

    public Vector2 moveInput;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        canDoubleJump = false;
        canMoveVertical = false;
    }

    private void Update()
    {
        checkShroomEaten = this.gameObject.GetComponent<Interaction>().shroomEaten;
        if (isGrounded && !checkShroomEaten)
        {
            canDoubleJump = false;
            JumpCount = 1;
        }
        else if(isGrounded && checkShroomEaten)
        {
            canDoubleJump = true;
            JumpCount = 2;
        }


        if (isJumping && bufferTimerCounter > 0f)
        {
            Jump();
            bufferTimerCounter = 0f;
        }
        else
        {
            bufferTimerCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && (isGrounded || (canDoubleJump && !isJumping)) && JumpCount > 0f)
        {
            Jump();
        }
        else if (context.canceled && isJumping)
        {
            isJumping = false;
        }
        else if (context.performed && !isGrounded)
        {
            bufferTimerCounter = bufferTime;
        }
    }

    private void Move()
    {
        float moveX = moveInput.x * moveSpeed * Time.fixedDeltaTime;

        if (!canMoveVertical)
        {
            rb.velocity = new Vector2(moveX, rb.velocity.y);
            animator.SetFloat("speed", Mathf.Abs(moveX));
        }
        else
        {
            float moveY = moveInput.y * moveSpeed * Time.fixedDeltaTime;
            rb.velocity = new Vector2(moveX, moveY);
            animator.SetFloat("speed", Mathf.Abs(moveX));
        }
        
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        CoyoteTimeCounter = coyoteTime;
        isJumping = true;
        JumpCount--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
            CoyoteTimeCounter = coyoteTime;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            CoyoteTimeCounter = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canMoveVertical = true;
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canMoveVertical = false;
            rb.gravityScale = 1;
        }
    }
}
