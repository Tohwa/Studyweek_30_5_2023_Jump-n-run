using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class InteractionManager : MonoBehaviour
{
    #region Fields

    [Header("GameObjects")]
    [SerializeField] private GameObject _flask;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _chest;
    [SerializeField] private GameObject _ladder;

    [Header("Scripts")]
    [SerializeField] private GameManager _manager;
    [SerializeField] private SpriteBehaviour _spriteBehave;
    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _flask)
        {
            _manager.flaskAcquired = true;
            _manager.canDoubleJump = true;
        }
        else if (other.gameObject == _key)
        {
            _manager.keyAcquired = true;
        }
        else if (other.gameObject == _chest)
        {
            _manager.goalReached = true;
        }
        else if (other.gameObject == _ladder)
        {
            _manager.climbing = true;
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            _manager.grounded = true;
            _manager.jumping = false;

            _spriteBehave.lastYPos = transform.position.y;

            if ((_manager.descending && (_spriteBehave.origYPos - _spriteBehave.lastYPos) > _spriteBehave.fallDamageThreshold) && !_manager.climbing)
            {
                _manager.gameOver = true;
            }
        }
        else if (other.gameObject.CompareTag("Water"))
        {
            _manager.gameOver = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == _chest)
        {
            _manager.goalReached = false;
        }
        else if (other.gameObject == _ladder)
        {
            _manager.climbing = false;
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            _manager.grounded = false;
            _manager.jumping = true;
            _spriteBehave.origYPos = transform.position.y;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _manager.grounded = true;
            _manager.jumping = false;

            _spriteBehave.lastYPos = transform.position.y;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            _manager.gameOver = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _manager.grounded = false;
            _manager.jumping = true;

            _spriteBehave.origYPos = transform.position.y;
        }
    }
}

    /*
    #region Fields
    public SpriteRenderer _sprite;
    public Sprite _nextSprite;
    [SerializeField] private FlaskBehaviour _deactivation;
    [SerializeField] private BoulderBehaviour _boulderBehaviour;

    [Header("Booleans")]
    public bool shroomEaten;
    public bool keyTaken;
    public bool doorReached;
    #endregion

    private void Start()
    {
        shroomEaten = false;
        keyTaken = false;
        doorReached = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.CompareTag("Key"))
        {
            keyTaken = true;
        }

        if (collision.gameObject.CompareTag("Shroom"))
        {
            _deactivation.Waiting();
            shroomEaten = true;
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            SceneManager.LoadScene("GameOver");
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            doorReached = true;
            _sprite.sprite = _nextSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            doorReached = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void EnterHome(InputAction.CallbackContext ctx)
    {
        if(ctx.started && doorReached)
        {
            SceneManager.LoadScene("Victory");
        }
    }
    */
