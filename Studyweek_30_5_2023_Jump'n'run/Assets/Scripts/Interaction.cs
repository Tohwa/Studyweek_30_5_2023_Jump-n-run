using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    #region Fields
    [Header("Booleans")]
    public bool shroomEaten;
    public bool keyTaken;
    #endregion

    private void Start()
    {
        shroomEaten = false;
        keyTaken = false;
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
    }
}
