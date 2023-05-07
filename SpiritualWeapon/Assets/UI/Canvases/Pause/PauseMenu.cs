using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerController playerController = null;

    [Header("UI")]
    [SerializeField] private GameObject menuContainer = null;
    [SerializeField] private GameObject settingsCanvas = null;
    [SerializeField] private GameObject endTransitionObj = null;

    private SpeechManager speechManager = null;

    private bool paused = false;

    private void Update() {
        PauseGameCheck();
    }

    private void PauseGameCheck() {
        if(!endTransitionObj.activeSelf && Input.GetKeyDown(KeyCode.Tab)) {
            if(!paused) {
                Freeze();
            } else {
                Resume();
            }
        } else if(endTransitionObj.activeSelf) {
            Resume();
        }
    }

    public void Resume() {
        ResumeHelper();
    }

    private void ResumeHelper() {
        speechManager = GameObject.FindGameObjectWithTag("SpeechManager").GetComponent<SpeechManager>();
        speechManager.PlayVocals();
        if(playerController != null) {
            playerController.SetCanRotate(true);
        }

        Move();
    }

    public void Back() {
        BackHelper();
    }

    private void BackHelper() {
        settingsCanvas.SetActive(false);
        menuContainer.SetActive(true);
    }

    public void ToSettings() {
        ToSettingsHelper();
    }

    private void ToSettingsHelper() {
        menuContainer.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    private void Freeze() {
        paused = true;
        menuContainer.SetActive(true);
        Time.timeScale = 0;

        speechManager = GameObject.FindGameObjectWithTag("SpeechManager").GetComponent<SpeechManager>();
        speechManager.PauseVocals();

        if(playerController != null) {
            playerController.SetCanRotate(false);
        }
    }

    private void Move() {
        Time.timeScale = 1;
        menuContainer.SetActive(false);
        settingsCanvas.SetActive(false);
        paused = false;
    }
}
