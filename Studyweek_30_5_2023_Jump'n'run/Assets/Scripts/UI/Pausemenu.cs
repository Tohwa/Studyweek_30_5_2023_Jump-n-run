using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _pauseMenu;

    [Header("Scripts")]
    [SerializeField] private GameManager _manager;
    #endregion

    private void Update()
    {        
        if(_manager.gamePaused)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        _manager.gamePaused = false;
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }    

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToOptionsMenu()
    {

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
