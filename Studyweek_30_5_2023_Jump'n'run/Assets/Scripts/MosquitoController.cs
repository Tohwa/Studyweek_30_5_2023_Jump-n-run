using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoController : MonoBehaviour
{
    #region
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float moveDownSpeed = 10f;

    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask groundLayers;

    public Transform leftBoundary;
    public Transform rightBoundary;
    public Transform lowerBoundary;

    public bool playerInRange = false;
    public bool movingDown;
    public bool disableMoveRight;
    public bool movingRight;
    #endregion

    private void Start()
    {
        movingRight = false;
        disableMoveRight = false;
        movingDown = false;
    }

    private void Update()
    {
        playerInRange = CheckPlayerHitbox();
        
        if(playerInRange)
        {
            movingDown = true;
            disableMoveRight = true;
        }

        if (!disableMoveRight)
        {
            if (movingRight)
            {
                spriteRenderer.flipX = true;
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

                if (transform.position.x >= rightBoundary.position.x)
                {
                    movingRight = false;
                }
            }
            else if (!movingRight)
            {
                spriteRenderer.flipX = false;
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

                if (transform.position.x <= leftBoundary.position.x)
                {
                    movingRight = true;
                }
            }
        }
        else
        {
            if(movingDown)
            {
                transform.Translate(Vector2.down * moveDownSpeed * Time.deltaTime);

                if (transform.position.y <= leftBoundary.position.y)
                {
                    movingDown = false;
                }
            }
            else
            {
                transform.Translate(Vector2.up * moveDownSpeed * Time.deltaTime);

                if (transform.position.y >= leftBoundary.position.y)
                {
                    disableMoveRight = false;
                }
            }
        }

        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.black);

    }

    private bool CheckPlayerHitbox()
    {
        var hitInfo = Physics2D.Raycast(
                        transform.position,
                        Vector2.down,
                        rayLength,
                        groundLayers);

        return hitInfo.collider;
    }
}
