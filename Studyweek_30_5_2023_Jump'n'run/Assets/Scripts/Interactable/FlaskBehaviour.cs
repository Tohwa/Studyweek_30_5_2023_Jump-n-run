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
    [SerializeField] private GameObject _flaskNotification;

    [Header("Scripts")]
    [SerializeField] private GameManager _manager;
    #endregion

    void Start()
    {
        _flaskNotification.SetActive(false);
    }

    void Update()
    {
        if (_manager.flaskAcquired)
        {
            _flask.SetActive(false);
            _flaskNotification.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
