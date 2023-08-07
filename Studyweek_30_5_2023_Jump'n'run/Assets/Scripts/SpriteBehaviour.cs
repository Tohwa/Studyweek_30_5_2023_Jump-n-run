using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehaviour : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    [SerializeField] private Rigidbody2D _playerRB;
    [SerializeField] private SpriteRenderer _playerRenderer;
    [SerializeField] private Animator _animator;

    [Header("Floats")]
    public float fallDamageThreshold = 10f;
    public float origYPos;
    public float lastYPos;

    [Header("Scripts")]
    [SerializeField] private GameManager _manager;
    [SerializeField] private InputManager _input;
    #endregion

    private void Update()
    {
        _manager.descending = _playerRB.velocity.y < 0;
        _manager.ascending = _playerRB.velocity.y > 0;

        if (_input.moveInput.x < 0)
        {
            _playerRenderer.flipX = true;
        }
        else if (_input.moveInput.x > 0)
        {
            _playerRenderer.flipX = false;
        }

        if (_manager.ascending && !_manager.grounded && !_manager.climbing)
        {
            _animator.SetBool("ascending", true);
        }
        else
        {
            _animator.SetBool("ascending", false);
        }

        if (_manager.descending && !_manager.grounded && !_manager.climbing)
        {
            _animator.SetBool("descending", true);
        }
        else
        {
            _animator.SetBool("descending", false);
        }
    }
}
