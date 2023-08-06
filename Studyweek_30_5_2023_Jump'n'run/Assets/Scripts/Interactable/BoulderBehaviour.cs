using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderBehaviour : MonoBehaviour
{
    #region
    [SerializeField] private Rigidbody2D _rb;
    private RigidbodyConstraints2D _rbLock;
    private RigidbodyConstraints2D _rbPrevCon;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _boulder;

    [SerializeField] private GameManager _manager;
    #endregion
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rbPrevCon = _rb.constraints;
        _rbLock = _rb.constraints;
    }

    void FixedUpdate()
    {
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
        _rb.constraints = _rbPrevCon;
        _rb.freezeRotation = false;
        _rb.gravityScale = 1;
    }

    private void FreezeBoulder()
    {
        _rb.gravityScale = 0;
        _rb.freezeRotation = true;
        _rbLock |= RigidbodyConstraints2D.FreezePositionX;
        _rbLock |= RigidbodyConstraints2D.FreezePositionY;
        _rb.constraints = _rbLock;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoulderCheck"))
        {
            _boulder.SetActive(false);
        }
    }
}
