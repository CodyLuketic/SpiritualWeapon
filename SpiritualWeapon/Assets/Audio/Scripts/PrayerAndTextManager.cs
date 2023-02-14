using System.Collections;
using UnityEngine;

public class PrayerAndTextManager : MonoBehaviour
{
    [SerializeField]private AudioSource audioSource = null;
    [SerializeField] private AudioClip[] prayerClips;

    [TextArea(minLines: 1, maxLines: 6)]
    [SerializeField]
    private string[] prayerText;

    private void Start() {
        StartCoroutine(Speech());
    }

    private IEnumerator Speech() {
        for(int i = 0; i < prayerClips.Length; i++) {
            audioSource.clip = prayerClips[i];
            audioSource.Play();
            yield return new WaitForSeconds(prayerClips[i].length);
        }
    }
}
