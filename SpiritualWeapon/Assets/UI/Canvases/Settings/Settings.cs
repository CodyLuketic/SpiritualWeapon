using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private AudioMixer musicMixer = null;
    [SerializeField] private AudioMixer vocalsMixer = null;
    [SerializeField] private AudioMixer soundEffectsMixer = null; 
    
    [SerializeField] private TMP_Text musicAmount = null;
    [SerializeField] private TMP_Text vocalsAmount = null;
    [SerializeField] private TMP_Text soundEffectsAmount = null;

    [SerializeField] private TMP_Dropdown resolutionDropdown = null;

    private Resolution[] resolutions;

    private void Start() {
        SetResolutions();
    }

    private void SetResolutions() {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetReolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMusicVolume(float volume) {
        SetMusicVolumeHelper(volume);
    }
    private void SetMusicVolumeHelper(float volume) {
        Debug.Log(volume);
        musicMixer.SetFloat("volume", volume);
        int volumeInt = (int) volume;
        musicAmount.SetText((((volumeInt + 80) * 5) / 4) + "%");
    }

    public void SetVocalsVolume(float volume) {
        SetVocalsVolumeHelper(volume);
    }
    private void SetVocalsVolumeHelper(float volume) {
        Debug.Log(volume);
        vocalsMixer.SetFloat("volume", volume);
        int volumeInt = (int) volume;
        vocalsAmount.SetText((((volumeInt + 80) * 5) / 4) + "%");
    }

    public void SetSoundEffectsVolume(float volume) {
        SetSoundEffectsVolumeHelper(volume);
    }
    private void SetSoundEffectsVolumeHelper(float volume) {
        Debug.Log(volume);
        soundEffectsMixer.SetFloat("volume", volume);
        int volumeInt = (int) volume;
        soundEffectsAmount.SetText((((volumeInt + 80) * 5) / 4) + "%");
    }

    public void SetQuality(int qualityIndex) {
        SetQualityHelper(qualityIndex);
    }
    private void SetQualityHelper(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen) {
        SetFullscreenHelper(isFullscreen);
    }
    private void SetFullscreenHelper(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }


}
