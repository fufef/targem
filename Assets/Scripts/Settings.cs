using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject settingsPanel;
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Toggle fullScreenCheckbox;
    float currentVolume;

    void Start()
    {
        LoadSettings();
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }

    public void ApplySettings()
    {
        PlayerPrefs.SetInt("FullscreenPreference",
                   System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference",
                   currentVolume);
        settingsPanel.SetActive(false);    
    }

    public void ExitSettings()
    {
        // возвращаем как было
        float oldVolume = PlayerPrefs.GetFloat("VolumePreference");
        volumeSlider.value = oldVolume;
        audioMixer.SetFloat("Volume", oldVolume);
        bool isFullscreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        Screen.fullScreen = isFullscreen;
        fullScreenCheckbox.isOn = isFullscreen;

        settingsPanel.SetActive(false);    
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen =
            System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;

        if (PlayerPrefs.HasKey("VolumePreference"))
            volumeSlider.value =
                        PlayerPrefs.GetFloat("VolumePreference");
        else
            volumeSlider.value =
                        PlayerPrefs.GetFloat("VolumePreference");
    
    }
}
