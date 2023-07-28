using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehaviour : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    [SerializeField] private SpriteRenderer _playerRenderer;
    [SerializeField] private Animator _animator;

    [Header("Scripts")]
    [SerializeField] private GameManager _manager;
    [SerializeField] private InputManager _input;
    #endregion

    private void Update()
    {
        if (_input.moveInput.x < 0)
        {
            _playerRenderer.flipX = true;
        }
        else if (_input.moveInput.x > 0)
        {
            _playerRenderer.flipX = false;
        }

        if (_manager.ascending && !_manager.grounded)
        {
            _animator.SetBool("ascending", true);
        }
        else
        {
            _animator.SetBool("ascending", false);
        }

        if (_manager.descending && !_manager.grounded)
        {
            _animator.SetBool("descending", true);
        }
        else
        {
            _animator.SetBool("descending", false);
        }
    }
}
