using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ResolutionController : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolutions_Dropdown;
    private List<Resolution> filtreResolutions;
    private int currentRefreshRate;
    private int currentRefreshRateAct;
    private int resolutionActually;

    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        ReviewResolutions();
    }

    public void FullScreen(bool screen)
    {
        Screen.fullScreen = screen;
    }

    public void ReviewResolutions()
    {
        resolutions = Screen.resolutions;
        filtreResolutions = new List<Resolution>();
        resolutions_Dropdown.ClearOptions();
        currentRefreshRateAct = Convert.ToInt32(Screen.currentResolution.refreshRateRatio.value);
        for (int i = 0; i < resolutions.Length; i++)
        {
            currentRefreshRate = Convert.ToInt32(resolutions[i].refreshRateRatio.value);
            
            if (currentRefreshRate == currentRefreshRateAct)
            {
                filtreResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();

        for (int i = 0; i < filtreResolutions.Count; i++)
        {
            string option = filtreResolutions[i].width + " x " + filtreResolutions[i].height;

            options.Add(option);

            // Verifica si esta es la resolución actualmente usada (comparando también los Hz)
            if (filtreResolutions[i].width == Screen.width &&
                filtreResolutions[i].height == Screen.height)
            {
                resolutionActually = i; // Actualiza el índice con el valor correcto
            }
        }

        resolutions_Dropdown.AddOptions(options);
        resolutions_Dropdown.value = resolutionActually;
        resolutions_Dropdown.RefreshShownValue();

        resolutions_Dropdown.value = PlayerPrefs.GetInt("NumberResolution", 0);
    }

    public void ChangeResolution(int indexResolution)
    {
        PlayerPrefs.SetInt("NumberResolution", resolutions_Dropdown.value);
        Resolution resolution = filtreResolutions[indexResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
