using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResolutionManager  : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private TMP_Dropdown _resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;
    #endregion

    void Start()
    {
        Screen.SetResolution(GameManager.resolutionWidth, GameManager.resolutionHeight, Screen.fullScreen);

        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        _resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for( int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();

        for(int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionDropdown = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
            options.Add(resolutionDropdown);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int _resolutionIndex)
    {
        Resolution resolution = filteredResolutions[_resolutionIndex];
        GameManager.resolutionHeight = resolution.height;
        GameManager.resolutionWidth = resolution.width;
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
