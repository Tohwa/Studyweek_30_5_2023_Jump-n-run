using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float moveSpeed = 3f;

    public Transform leftBoundary;
    public Transform rightBoundary;
    public bool movingRight;
    #endregion

    private void Start()
    {
        movingRight = false;
    }

    private void Update()
    {
        if (movingRight)
        {
            spriteRenderer.flipX = false;
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            if(transform.position.x >= rightBoundary.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            spriteRenderer.flipX = true;
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            if (transform.position.x <= leftBoundary.position.x)
            {
                movingRight = true;
            }
        }
    }


}
