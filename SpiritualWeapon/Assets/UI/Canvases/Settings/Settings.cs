using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{
    [Header("Canvases")]
    [SerializeField] private GameObject settings = null;
    [SerializeField] private GameObject scores = null;

    [Header("Audio")]
    [SerializeField] private AudioMixer musicMixer = null;
    [SerializeField] private AudioMixer vocalsMixer = null;
    [SerializeField] private AudioMixer soundEffectsMixer = null; 
    
    [SerializeField] private TMP_Text musicAmount = null;
    [SerializeField] private TMP_Text vocalsAmount = null;
    [SerializeField] private TMP_Text soundEffectsAmount = null;

    [Header("Resolution")]
    [SerializeField] private TMP_Dropdown resolutionDropdown = null;
    private Resolution[] resolutions;

    [Header("Scores")]
    [SerializeField] private TMP_Text scoreAll = null;
    [SerializeField] private TMP_Text scoreJoyful = null;
    [SerializeField] private TMP_Text scoreLuminous = null;
    [SerializeField] private TMP_Text scoreSorrowful = null;
    [SerializeField] private TMP_Text scoreGlorius = null;

    private void Start() {
        SetResolutions();
    }

    private void Update() {
        UpdateScores();
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
        musicMixer.SetFloat("volume", volume);
        int volumeInt = (int) volume;
        int displayNum = Mathf.Clamp((volumeInt + 50) * 3 / 2, 0, 100);
        musicAmount.SetText(displayNum + "%");
    }

    public void SetVocalsVolume(float volume) {
        SetVocalsVolumeHelper(volume);
    }
    private void SetVocalsVolumeHelper(float volume) {
        vocalsMixer.SetFloat("volume", volume);
        int volumeInt = (int) volume;
        int displayNum = Mathf.Clamp((volumeInt + 50) * 3 / 2, 0, 100);
        vocalsAmount.SetText(displayNum + "%");
    }

    public void SetSoundEffectsVolume(float volume) {
        SetSoundEffectsVolumeHelper(volume);
    }
    private void SetSoundEffectsVolumeHelper(float volume) {
        soundEffectsMixer.SetFloat("volume", volume);
        int volumeInt = (int) volume;
        int displayNum = Mathf.Clamp((volumeInt + 50) * 3 / 2, 0, 100);
        soundEffectsAmount.SetText(displayNum + "%");
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

    public void ShowScores() {
        ShowScoresHelper();
    }
    private void ShowScoresHelper() {
        settings.SetActive(false);
        scores.SetActive(true);

        UpdateScores();
    }

    public void HideScores(){
        HideScoresHelper();
    }
    private void HideScoresHelper() {
        scores.SetActive(false);
        settings.SetActive(true);

        UpdateScores();
    }

    private void UpdateScores() {
        scoreAll.text = "All Mysteries Highest Score: " + PlayerPrefs.GetInt("HighScoreAll");
        scoreJoyful.text = "Joyful Mysteries Highest Score: " + PlayerPrefs.GetInt("HighScoreJoyful");
        scoreLuminous.text = "Luminous Mysteries Highest Score: " + PlayerPrefs.GetInt("HighScoreLuminous");
        scoreSorrowful.text = "Sorrowful Mysteries Highest Score: " + PlayerPrefs.GetInt("HighScoreSorrowful");
        scoreGlorius.text = "Glorius Mysteries Highest Score: " + PlayerPrefs.GetInt("HighScoreGlorius");
    }
}
