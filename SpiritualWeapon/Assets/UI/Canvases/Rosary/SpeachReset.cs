using UnityEngine;

public class SpeachReset : MonoBehaviour
{
    private SpeechManager speechManager = null;

    private void Start() {
        speechManager = GameObject.FindGameObjectWithTag("SpeechManager").GetComponent<SpeechManager>();

        speechManager.ResetAll();
    }
}
