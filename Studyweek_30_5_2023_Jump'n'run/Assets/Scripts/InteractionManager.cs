using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class InteractionManager : MonoBehaviour
{
    /*
    #region Fields
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemyNPC;
    [SerializeField] private GameObject _mosquitoNPC;
    [SerializeField] private GameObject _water;
    [SerializeField] private GameObject _flask;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _boulder;
    [SerializeField] private GameObject _chest;

    [SerializeField] private deactivateShroom _flaskBehaviour;
    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _player)
        {
            if (other.gameObject == _enemyNPC)
            {
                // Handle interaction with enemy NPC
                // result = ...
            }
            else if (other.gameObject == _mosquitoNPC)
            {
                // Handle interaction with mosquito NPC
                // result = ...
            }
            else if (other.gameObject == _water)
            {
                // Handle interaction with water
                // result = ...
            }
            else if (other.gameObject == _flask)
            {
                _flaskBehaviour.Waiting();
            }
            else if (other.gameObject == _key)
            {
                // Handle interaction with water
                // result = ...
            }
            else if (other.gameObject == _boulder)
            {
                // Handle interaction with boulder
                // result = ...
            }
            else if (other.gameObject == _chest)
            {
                // Handle interaction with chest
                // result = ...
            }
        }
    }*/

    #region Fields
    public SpriteRenderer _sprite;
    public Sprite _nextSprite;
    [SerializeField] private deactivateShroom _deactivation;

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
}
