using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamageCheck : MonoBehaviour
{
    #region Fields
    [Header("Floats")]
    [SerializeField] private float fallDamageThreshold = 10f;
    public float origYPos;
    [SerializeField] private float lastYPos;

    [Header("Scripts")]
    [SerializeField] private GameManager _manager;
    #endregion

    private void Update()
    {
        _manager.descending = transform.position.y < lastYPos;
        _manager.ascending = transform.position.y > lastYPos;

        lastYPos = transform.position.y;

        if (_manager.grounded)
        {
            origYPos = transform.position.y;
        }

        if (_manager.descending && (origYPos - lastYPos) > fallDamageThreshold)
        {
            _manager.gameOver = true;
        }
    }
}
