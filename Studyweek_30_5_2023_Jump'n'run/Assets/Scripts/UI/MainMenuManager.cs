using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _settingsMenu;
    #endregion

    private void Awake()
    {
        _settingsMenu.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void SettingsMenu()
    {
        _settingsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
