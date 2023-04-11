using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float inWaitTime = 1f;
    [SerializeField] private float outWaitTime = 1f;
    [SerializeField] private float increment = 0.1f;
    [SerializeField] private float deIncrement = 0.1f;

    private AudioSource audioSource = null;
    private float initVolume = 0;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        initVolume = audioSource.volume;
        audioSource.volume = 0;

        StartCoroutine(AudioFadeIn());
    }

    private IEnumerator AudioFadeIn() {
        while(audioSource.volume < initVolume) {
            audioSource.volume += increment;

            yield return new WaitForSeconds(inWaitTime);
        }
    }

    public void AudioFadeOut() {
        StartCoroutine(AudioFadeOutHelper());
    }
    private IEnumerator AudioFadeOutHelper() {
        while(audioSource.volume > 0) {
            audioSource.volume -= deIncrement;

            yield return new WaitForSeconds(outWaitTime);
        }
    }
}
