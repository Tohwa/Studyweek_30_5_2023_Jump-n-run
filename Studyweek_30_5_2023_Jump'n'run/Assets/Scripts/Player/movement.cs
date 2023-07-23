using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class movement : MonoBehaviour
{
    #region Fields
    [Header("Float Values")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int JumpCount = 2;
    
    private float coyoteTime = 0.2f;
    private float CoyoteTimeCounter;
    private float bufferTime = 0.2f;
    private float bufferTimerCounter;
    

    [Header("Booleans")]
    [SerializeField] private bool canDoubleJump;
    private bool isJumping;

    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;
    public Animator _animator;

    [Header("Scripts")]
    [SerializeField] private GameManager _manager;

    [Header("Movement Vector")]
    public Vector2 moveInput;
    #endregion

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        canDoubleJump = false;
    }

    private void Update()
    {

        if (_manager.grounded && !_manager.flaskAcquired)
        {
            canDoubleJump = false;
            JumpCount = 1;
        }
        else if(_manager.grounded && _manager.flaskAcquired)
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
        if(Time.timeScale != 0f)
        {
            moveInput = context.ReadValue<Vector2>();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!Pausemenu.isPaused)
        {
            if (context.started && (_manager.grounded || (canDoubleJump && !isJumping)) && JumpCount > 0f)
            {
                Jump();
            }
            else if (context.canceled && isJumping)
            {
                isJumping = false;
            }
            
            else if (context.performed && !_manager.grounded)
            {
                bufferTimerCounter = bufferTime;
            }
        }        
    }

    private void Move()
    {
        float moveX = moveInput.x * moveSpeed * Time.fixedDeltaTime;

        if (!_manager.climbing)
        {
            _rb.velocity = new Vector2(moveX, _rb.velocity.y);
            _animator.SetFloat("speed", Mathf.Abs(moveX));
        }
        else
        {
            float moveY = moveInput.y * moveSpeed * Time.fixedDeltaTime;
            _rb.velocity = new Vector2(moveX, moveY);
            _animator.SetFloat("speed", Mathf.Abs(moveX));
        }
        
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        CoyoteTimeCounter = coyoteTime;
        isJumping = true;
        JumpCount--;
    }    
}
