using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Interaction : MonoBehaviour
{
    #region Fields
    public SpriteRenderer _sprite;
    public Sprite _nextSprite;

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
}
