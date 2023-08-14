using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settingsMenu;

    [Header("Components")]
    [SerializeField] private AudioMixer _mixer;
    #endregion

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

    public void OnBack()
    {
        _pauseMenu.SetActive(true);
        _settingsMenu.SetActive(false);
    }
}
