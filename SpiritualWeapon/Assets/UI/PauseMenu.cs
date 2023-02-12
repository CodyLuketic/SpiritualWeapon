using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pause = null, settings = null, transitionObj = null;

    private bool paused = false;

    private void Update() {
        PauseGameCheck();
    }

    private void PauseGameCheck() {
        if(!transitionObj.activeSelf && Input.GetKeyDown(KeyCode.Tab)) {
            if(!paused) {
                Freeze();
            } else {
                Move();
            }
        } else if(transitionObj.activeSelf) {
            Move();
        }
    }

    public void Resume() {
        ResumeHelper();
    }

    private void ResumeHelper() {
        Move();
    }

    public void Back() {
        BackHelper();
    }

    private void BackHelper() {
        settings.SetActive(false);
        pause.SetActive(true);
    }

    public void ToSettings() {
        ToSettingsHelper();
    }

    private void ToSettingsHelper() {
        pause.SetActive(false);
        settings.SetActive(true);
    }

    private void Freeze() {
        paused = true;
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    private void Move() {
        Time.timeScale = 1;
        pause.SetActive(false);
        settings.SetActive(false);
        paused = false;
    }
}
