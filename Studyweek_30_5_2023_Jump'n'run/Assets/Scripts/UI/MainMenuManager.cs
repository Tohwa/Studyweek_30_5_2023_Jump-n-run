using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private TextMeshProUGUI _masterText;
    [SerializeField] private TextMeshProUGUI _bgmText;
    [SerializeField] private TextMeshProUGUI _sfxText;

    [Header("Components")]
    [SerializeField] private AudioMixer _mixer;
    #endregion

    private void Awake()
    {
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

    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void SettingsMenu()
    {
        _settingsMenu.SetActive(true);
    }

    public void SettingsToMainMenu()
    {
        _settingsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

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
