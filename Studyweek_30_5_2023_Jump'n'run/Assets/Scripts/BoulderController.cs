using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderController : MonoBehaviour
{
    #region
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _boulder;

    [SerializeField] private bool canMove;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        canMove = _player.GetComponent<Interaction>().keyTaken;
        if (canMove)
        {
            MoveBoulder();
        }
        else
        {
            _rb.gravityScale = 0;
        }
    }

    private void MoveBoulder()
    {
        _rb.gravityScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoulderCheck"))
        {
            _boulder.SetActive(false);
        }
    }
}
