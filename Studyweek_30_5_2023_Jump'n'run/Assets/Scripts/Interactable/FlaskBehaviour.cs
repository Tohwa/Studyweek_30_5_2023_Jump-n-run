using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class FlaskBehaviour : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _flask;
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
        if (_manager.flaskAcquired)
        {
            _flask.SetActive(false);
            _notification.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnResponse(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _manager.flaskAcquired)
        {
            _notification.SetActive(false);
            Time.timeScale = 1f;
            _manager.flaskAcquired = false;
        }
    }
}
