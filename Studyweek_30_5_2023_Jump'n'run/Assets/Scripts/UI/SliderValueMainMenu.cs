using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueMainMenu : MonoBehaviour
{
    #region Fields
    [Header("Slider")]
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private Slider _bgmSlider;

    #endregion
    /*
    private void Awake()
    {
        _masterSlider.value = 0.75f;
        _sfxSlider.value = 0.75f;
        _bgmSlider.value = 0.75f;
    }
    */

    private void Start()
    {
        _masterSlider.value = SliderValueManager.masterSliderValue;
        _sfxSlider.value = SliderValueManager.SFXSliderValue;
        _bgmSlider.value = SliderValueManager.BGMSliderValue;
    }

    public void OnMasterValueChanged()
    {
        SliderValueManager.masterSliderValue = _masterSlider.value;   
    }

    public void OnSFXValueChange()
    {
        SliderValueManager.SFXSliderValue = _sfxSlider.value;
    }

    public void OnBGMValueCHange()
    {
        SliderValueManager.BGMSliderValue = _bgmSlider.value;
    }
}
