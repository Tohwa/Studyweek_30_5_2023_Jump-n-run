using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _pauseMenu;
    [Header("Components")]
    [SerializeField] private Rigidbody2D _playerRB;

    [Header("boolean")]
    public bool climbing;
    public bool grounded;
    public bool jumping;
    public bool falling;
    public bool canDoubleJump;

    public bool keyAcquired;
    public bool flaskAcquired;
    public bool boulderCanRoll;

    public bool goalReached;

    public bool gameOver;
    public bool victory;
    public bool gamePaused;
    #endregion

    private void Awake()
    {
        _pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(climbing)
        {
            _playerRB.gravityScale = 0;
        }
        else
        {
            _playerRB.gravityScale = 1;
        }

        if (victory)
        {
            SceneManager.LoadScene("Victory");
        }
        else if (gameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
