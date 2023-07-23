using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyBehaviour : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _notification;

    [Header("Scripts")]
    [SerializeField] private GameManager _manager;
    #endregion

    void Start()
    {
        _notification.SetActive(false);
    }

    void Update()
    {
        if (_manager.keyAcquired)
        {
            _key.SetActive(false);
            _notification.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnResponse(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _manager.keyAcquired)
        {
            _notification.SetActive(false);
            Time.timeScale = 1f;
            _manager.flaskAcquired = false;
        }
    }
}
