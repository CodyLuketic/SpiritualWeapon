using UnityEngine;

public class MysterySpeechActivator : MonoBehaviour
{
    private SpeechManager speechManager = null;

    [Header("Basic Values")]
    [SerializeField] private int startingMystery = 1;

    private void Start() {
        speechManager = GameObject.FindGameObjectWithTag("SpeechManager").GetComponent<SpeechManager>();

        speechManager.Mysteries(startingMystery);
    }
}