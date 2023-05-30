using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;

    [Header("Floats")]
    [SerializeField] private float jumpForce;

    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float coyoteTimeCounter;

    [SerializeField] private float bufferTime = 0.2f;
    [SerializeField] private float bufferTimeCounter;

    [Header("Integer")]
    [SerializeField] private int jumpCount = 1;

    [Header("Boolean")]
    [SerializeField] private bool grounded;
    #endregion

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            coyoteTimeCounter = coyoteTime;
            jumpCount = 1;
        }
        else
        {
            coyoteTimeCounter -= Time.fixedDeltaTime;           
            if(coyoteTimeCounter < 0)
            {
                coyoteTimeCounter = 0;
            }

            bufferTimeCounter -= Time.fixedDeltaTime;
            if (bufferTimeCounter < 0)
            {
                bufferTimeCounter = 0;
            }
        }
    }

    public void UpdateJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && grounded)
        {
            bufferTimeCounter = bufferTime;
            jumpCount = 0;
        }

        if((coyoteTimeCounter > 0f || bufferTimeCounter > 0) && jumpCount > 0)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
