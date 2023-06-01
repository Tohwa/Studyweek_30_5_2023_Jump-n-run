using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    #region Fields
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
            SceneManager.LoadScene("Game Over");
        }
        else if (collision.gameObject.CompareTag(""))
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shroom"))
        {
            doorReached = true;
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
