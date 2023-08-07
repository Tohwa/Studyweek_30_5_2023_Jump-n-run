using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Movement : MonoBehaviour
{
    #region Fields
    [Header("Float Values")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    public int JumpCount = 2;
    
    public float coyoteTime = 0.2f;
    public float CoyoteTimeCounter;
    public float bufferTime = 0.2f;
    public float bufferTimerCounter;  

    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;

    [Header("Scripts")]
    [SerializeField] private GameManager _manager;
    [SerializeField] private InputManager _input;
    #endregion

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (_manager.grounded && !_manager.canDoubleJump)
        {
            JumpCount = 1;
        }
        else if(_manager.grounded && _manager.canDoubleJump)
        {
            JumpCount = 2;
        }


        if (_manager.jumping && bufferTimerCounter > 0f)
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

    private void Move()
    {
        float moveX = _input.moveInput.x * moveSpeed * Time.fixedDeltaTime;

        if (!_manager.climbing)
        {
            _rb.velocity = new Vector2(moveX, _rb.velocity.y);
            _animator.SetFloat("speed", Mathf.Abs(moveX));
            _animator.SetBool("climb", false);
        }
        else
        {
            float moveY = _input.moveInput.y * moveSpeed * Time.fixedDeltaTime;
            _rb.velocity = new Vector2(moveX, moveY);
            _animator.SetFloat("speed", Mathf.Abs(moveX));
            _animator.SetBool("climb", true);

        }

    }

    public void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        CoyoteTimeCounter = coyoteTime;
        _manager.jumping = true;
        JumpCount--;
    }    
}
