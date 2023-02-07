using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer = null; 
    
    [SerializeField]
    private TMP_Text musicAmount = null;

    public void SetMusicVolume(float volume) {
        SetMusicVolumeHelper(volume);
    }
    private void SetMusicVolumeHelper(float volume) {
        Debug.Log(volume);
        musicMixer.SetFloat("volume", volume);
        int volumeInt = (int) volume;
        musicAmount.SetText((((volumeInt + 80) * 5) / 4) + "%");
    }
}
