using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuContainer = null, settingsCanvas = null, rosaryCanvas = null, endTransitionObj = null;

    private bool paused = false;

    private void Update() {
        PauseGameCheck();
    }

    private void PauseGameCheck() {
        if(!endTransitionObj.activeSelf && Input.GetKeyDown(KeyCode.Tab)) {
            if(!paused) {
                Freeze();
            } else {
                Move();
            }
        } else if(endTransitionObj.activeSelf) {
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
        //rosaryCanvas.SetActive(false);
        menuContainer.SetActive(true);
        Time.timeScale = 0;
    }

    private void Move() {
        Time.timeScale = 1;
        menuContainer.SetActive(false);
        settingsCanvas.SetActive(false);
        //rosaryCanvas.SetActive(true);
        paused = false;
    }
}
