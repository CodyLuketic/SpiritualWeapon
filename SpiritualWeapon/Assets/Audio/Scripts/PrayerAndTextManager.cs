using UnityEngine;

public class PrayerAndTextManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] prayerClips;

    [TextArea(minLines: 1, maxLines: 6)]
    [SerializeField]
    private string[] prayerText;

    private void Start() {
        
    }

    private void Update() {
        
    }
}
