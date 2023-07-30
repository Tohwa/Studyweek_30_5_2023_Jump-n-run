using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settingsMenu;

    [Header("Components")]
    [SerializeField] private AudioMixer _mixer;

    [Header("Scripts")]
    [SerializeField] private GameManager _manager;
    #endregion

    private void Awake()
    {
        _pauseMenu.SetActive(false);
        _settingsMenu.SetActive(false);
    }

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
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToOptionsMenu()
    {
        _pauseMenu.SetActive(false);

        _settingsMenu.SetActive(true);
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

    public void SetVolumeMaster(float _volume)
    {
        _mixer.SetFloat("MasterVol", _volume);
    }

    public void SetVolumeBGM(float _volume)
    {
        _mixer.SetFloat("BGMVol", _volume);
    }

    public void SetVolumeSFX(float _volume)
    {
        _mixer.SetFloat("SFXVol", _volume);
    }

    public void ReturnToPauseMenu()
    {
        _pauseMenu.SetActive(true);
        _settingsMenu.SetActive(false);
    }
}
