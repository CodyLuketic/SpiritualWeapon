using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private Scene mainMenu;
    //private Scene settings;
    //private Scene joyfulMystery;
    //private Scene luminousMystery;
    //private Scene sorrowfulMystery;
    //private Scene gloriusMystery;
    //private Scene endingPrayer;

    public void NextScene() {
        NextSceneHelper();
    }
    private void NextSceneHelper() {
        SceneTransition();
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index < SceneManager.sceneCount) {
            SceneManager.LoadScene(index + 1);
        } else {
            SceneManager.LoadScene(0);
        }
    }

    public void PreviousScene() {
        PreviousSceneHelper();
    }
    private void PreviousSceneHelper() {
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index > 0) {
            SceneTransition();
            SceneManager.LoadScene(index - 1);
        }
    }

    public void ToMainMenu() {
        ToMainMenuHelper();
    }
    private void ToMainMenuHelper() {
        SceneManager.LoadScene(0);
    }

    public void ToSettings() {
        ToSettingsHelper();
    }
    private void ToSettingsHelper() {
        SceneManager.LoadScene(1);
    }

    public void ToJoyfulMystery() {
        ToJoyfulMysteryHelper();
    }
    private void ToJoyfulMysteryHelper() {
        SceneManager.LoadScene(2);
    }

    public void ToLuminousMystery() {
        ToLuminousMysteryHelper();
    }
    private void ToLuminousMysteryHelper() {
        SceneManager.LoadScene(3);
    }

    public void ToSorrowfulMystery() {
        ToSorrowfulMysteryHelper();
    }
    private void ToSorrowfulMysteryHelper() {
        SceneManager.LoadScene(4);
    }

    public void ToGloriusMystery() {
        ToGloriusMysteryHelper();
    }
    private void ToGloriusMysteryHelper() {
        SceneManager.LoadScene(5);
    }

    public void ToEndingPrayer() {
        ToEndingPrayerHelper();
    }
    private void ToEndingPrayerHelper() {
        SceneManager.LoadScene(6);
    }

    private void SceneTransition() {

    }
}
