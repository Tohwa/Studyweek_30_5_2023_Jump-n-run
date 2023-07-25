using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChestBehaviour : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    [SerializeField] private SpriteRenderer _chestRenderer;

    [Header("Sprites")]
    [SerializeField] private Sprite _closedChest;
    [SerializeField] private Sprite _openChest;
    
    [Header("Scripts")]
    [SerializeField] private GameManager _manager;
    #endregion

    private void Update()
    {
        if (_manager.goalReached)
        {
            _chestRenderer.sprite = _openChest;
        }
        else
        {
            _chestRenderer.sprite = _closedChest;
        }
    }
}
