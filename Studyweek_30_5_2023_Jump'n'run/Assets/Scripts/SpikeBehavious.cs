using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavious : MonoBehaviour
{
    #region
    [SerializeField] private GameObject _spike;
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask groundLayers;

    public bool playerInRange = false;
    #endregion

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerInRange = CheckPlayerHitbox();

        if (playerInRange)
        {
            DropSpike();
        }
        else
        {
            _rb.gravityScale = 0;
        }


        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.black);
    }

    private void DropSpike()
    {
        _spike.transform.parent = null;
        _rb.gravityScale = 4;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _spike.SetActive(false);
        }
    }
}
