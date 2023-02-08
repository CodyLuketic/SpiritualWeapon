using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image transition;

    [SerializeField]
    private float increment = 0.1f, sceneTick = 0.1f;

    public void NextScene() {
        NextSceneHelper();
    }
    private void NextSceneHelper() {
        //SceneTransition();
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
            //SceneTransition();
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

    public void Quit() {
        QuitHelper();
    }
    private void QuitHelper() {
        Application.Quit();
    }

    /*
    public void SceneTransition() {
        StartCoroutine(SceneTransitionHelper());
    }
    private IEnumerator SceneTransitionHelper() {
        float r = transition.color.r;
        float g = transition.color.g;
        float b = transition.color.b;
        float alpha = transition.color.a;
        while(alpha < 0.99) {
            alpha += increment;
            yield return new WaitForSeconds(sceneTick);
        }
        transition.color = new Color(r, g, b, alpha);
    }
    */
}
