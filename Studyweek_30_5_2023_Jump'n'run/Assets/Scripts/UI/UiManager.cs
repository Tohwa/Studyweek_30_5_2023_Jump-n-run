using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private TextMeshProUGUI _masterText;
    [SerializeField] private TextMeshProUGUI _bgmText;
    [SerializeField] private TextMeshProUGUI _sfxText;

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

    private void Start()
    {
        MasterTextValue(_masterSlider.value);
        _masterSlider.onValueChanged.AddListener(MasterTextValue);
        BGMTextValue(_bgmSlider.value);
        _bgmSlider.onValueChanged.AddListener(BGMTextValue);
        SFXTextValue(_sfxSlider.value);
        _sfxSlider.onValueChanged.AddListener(SFXTextValue);
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
        _mixer.SetFloat("MasterVol", Mathf.Log10(_volume) * 20);
    }

    public void SetVolumeBGM(float _volume)
    {
        _mixer.SetFloat("BGMVol", Mathf.Log10(_volume) * 20);
    }

    public void SetVolumeSFX(float _volume)
    {
        _mixer.SetFloat("SFXVol", Mathf.Log10(_volume) * 20);
    }

    public void ReturnToPauseMenu()
    {
        _pauseMenu.SetActive(true);
        _settingsMenu.SetActive(false);
    }

    private void MasterTextValue(float _value)
    {
        _value = Mathf.Round(_value * 100);
        string textValue = _value.ToString();

        _masterText.text = textValue;
    }

    private void BGMTextValue(float _value)
    {
        _value = Mathf.Round(_value * 100);
        string textValue = _value.ToString();

        _bgmText.text = textValue;
    }

    private void SFXTextValue(float _value)
    {
        _value = Mathf.Round(_value * 100);
        string textValue = _value.ToString();

        _sfxText.text = textValue;
    }
}
