using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    #region Fields
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    #endregion

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalVelocity = _rb.velocity.x;

        if (horizontalVelocity < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalVelocity > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
