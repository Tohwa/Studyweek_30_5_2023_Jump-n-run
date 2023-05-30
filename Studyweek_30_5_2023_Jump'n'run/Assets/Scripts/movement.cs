using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    #region Fields
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float movespeed;

    private Vector2 _moveValue;
    #endregion

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveValue.x * movespeed * Time.deltaTime, _rb.velocity.y);
    }

    public void UpdateMove(InputAction.CallbackContext ctx)
    {
        _moveValue = ctx.ReadValue<Vector2>();
    }
}
