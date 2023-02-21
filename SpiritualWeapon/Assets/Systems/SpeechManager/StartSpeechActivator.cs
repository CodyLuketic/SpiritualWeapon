using UnityEngine;

public class StartSpeechActivator : MonoBehaviour
{
    private SpeechManager speechManager = null;

    private void Start() {
        speechManager = GameObject.FindGameObjectWithTag("SpeechManager").GetComponent<SpeechManager>();

        speechManager.StartingPrayers();
    }
}
