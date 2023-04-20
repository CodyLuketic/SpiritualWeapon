using UnityEngine;

public class EndSpeechActivator : MonoBehaviour
{
    private SpeechManager speechManager = null;

    private void Start() {
        speechManager = GameObject.FindGameObjectWithTag("SpeechManager").GetComponent<SpeechManager>();

        speechManager.EndRosary();
    }
}
