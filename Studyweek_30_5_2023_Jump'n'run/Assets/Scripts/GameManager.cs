using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Fields

    [Header("Components")]
    [SerializeField] private Rigidbody2D _playerRB;

    [Header("public static values")]
    public static float masterSliderValue = 0.75f;
    public static float SFXSliderValue = 0.75f;
    public static float BGMSliderValue = 0.75f;

    public static int resolutionWidth;
    public static int resolutionHeight;

    [Header("boolean")]
    public bool climbing;
    public bool grounded;
    public bool jumping;
    public bool ascending;
    public bool descending;
    public bool canDoubleJump;

    public bool keyAcquired;
    public bool flaskAcquired;
    public bool boulderCanRoll;

    public bool goalReached;

    public bool gameOver;
    public bool victory;
    public bool gamePaused;
    #endregion

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
