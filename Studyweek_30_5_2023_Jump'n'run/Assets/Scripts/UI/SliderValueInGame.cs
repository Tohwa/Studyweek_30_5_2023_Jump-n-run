using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueInGame : MonoBehaviour
{
    #region Fields
    [Header("Slider")]
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private Slider _bgmSlider;

    #endregion
    private void Start()
    {
        _masterSlider.value = GameManager.masterSliderValue;
        _sfxSlider.value = GameManager.SFXSliderValue;
        _bgmSlider.value = GameManager.BGMSliderValue;
    }

    public void OnMasterValueChanged()
    {
        GameManager.masterSliderValue = _masterSlider.value;
    }

    public void OnSFXValueChange()
    {
        GameManager.SFXSliderValue = _sfxSlider.value;
    }

    public void OnBGMValueCHange()
    {
        GameManager.BGMSliderValue = _bgmSlider.value;
    }
}
