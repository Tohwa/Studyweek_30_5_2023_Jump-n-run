using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _notification;

    [Header("Script")]
    [SerializeField] private GameManager _manager;
    [SerializeField] private movement _controller;

    [Header("Vector")]
    public Vector2 moveInput;
    #endregion

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (Time.timeScale != 0f)
        {
            moveInput = ctx.ReadValue<Vector2>();
        }
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (!_manager.gamePaused)
        {
            if (ctx.started && (_manager.grounded || (_manager.canDoubleJump && !_manager.jumping)) && _controller.JumpCount > 0f)
            {
                _controller.Jump();
            }
            else if (ctx.canceled && _manager.jumping)
            {
                _manager.jumping = false;
            }

            else if (ctx.performed && !_manager.grounded)
            {
                _controller.bufferTimerCounter = _controller.bufferTime;
            }
        }
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (ctx.started && !_manager.gamePaused)
        {
            _manager.gamePaused = true;            
        }        
    }

    public void OnResponse(InputAction.CallbackContext ctx)
    {
        if (ctx.started && _manager.goalReached)
        {
            _manager.victory = true;
        }
        else if (ctx.performed && _manager.keyAcquired)
        {
            _notification.SetActive(false);
            Time.timeScale = 1f;
            _manager.keyAcquired = false;
            _manager.boulderCanRoll = true;
        }
        else if (ctx.performed && _manager.flaskAcquired)
        {
            _notification.SetActive(false);
            Time.timeScale = 1f;
            _manager.flaskAcquired = false;
        }
    }
}
