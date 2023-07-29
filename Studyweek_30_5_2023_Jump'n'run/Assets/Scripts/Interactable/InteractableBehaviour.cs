using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class InteractableBehaviour : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _flask;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _boulder;
    [SerializeField] private GameObject _boulderRemover;
    [SerializeField] private GameObject _flaskNotification;
    [SerializeField] private GameObject _keyNotification;

    [Header("Components")]
    [SerializeField] private SpriteRenderer _chestRenderer;
    [SerializeField] private Rigidbody2D _boulderRB;

    [Header("Sprites")]
    [SerializeField] private Sprite _closedChest;
    [SerializeField] private Sprite _openChest;

    [Header("Scripts")]
    [SerializeField] private GameManager _manager;

    private RigidbodyConstraints2D _rbLock;
    private RigidbodyConstraints2D _rbPrevCon;
    #endregion

    void Start()
    {
        _flaskNotification.SetActive(false);
        _keyNotification.SetActive(false);

        _rbPrevCon = _boulderRB.constraints;
        _rbLock = _boulderRB.constraints;
    }

    void Update()
    {
        if (_manager.flaskAcquired)
        {
            _flask.SetActive(false);
            _flaskNotification.SetActive(true);
            Time.timeScale = 0f;
        }

        if (_manager.keyAcquired)
        {
            _key.SetActive(false);
            _keyNotification.SetActive(true);
            Time.timeScale = 0f;
        }

        if (_manager.goalReached)
        {
            _chestRenderer.sprite = _openChest;
        }
        else
        {
            _chestRenderer.sprite = _closedChest;
        }

        if (_manager.boulderCanRoll)
        {
            StartRolling();
        }
        else
        {
            FreezeBoulder();

        }
    }

    private void StartRolling()
    {
        _boulderRB.constraints = _rbPrevCon;
        _boulderRB.freezeRotation = false;
        _boulderRB.gravityScale = 1;
    }

    private void FreezeBoulder()
    {
        _boulderRB.gravityScale = 0;
        _boulderRB.freezeRotation = true;
        _rbLock |= RigidbodyConstraints2D.FreezePositionX;
        _rbLock |= RigidbodyConstraints2D.FreezePositionY;
        _boulderRB.constraints = _rbLock;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _boulderRemover)
        {
            _boulder.SetActive(false);
        }
    }
}
