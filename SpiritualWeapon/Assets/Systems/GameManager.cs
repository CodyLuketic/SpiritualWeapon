using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject transitionObj, startTransitionObj;

    private Image transition, startTransition;

    [SerializeField]
    private float increment = 0.1f, sceneTick = 0.1f;

    private int function = 0;

    private void Start() {
        transition = transitionObj.GetComponent<Image>();
        startTransition = startTransitionObj.GetComponent<Image>();

        if(startTransitionObj.activeSelf) {
            StartTransition();
        }
    }

    public void NextScene() {
        function = 0;
        SceneTransition();
    }
    private void NextSceneHelper() {
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index < SceneManager.sceneCount) {
            SceneManager.LoadScene(index + 1);
        } else {
            SceneManager.LoadScene(0);
        }
    }

    public void PreviousScene() {
        function = 1;
        SceneTransition();
    }
    private void PreviousSceneHelper() {
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index > 0) {
            SceneManager.LoadScene(index - 1);
        }
    }

    public void ToMainMenu() {
        function = 2;
        SceneTransition();
    }
    private void ToMainMenuHelper() {
        SceneManager.LoadScene(0);
    }

    public void ToSettings() {
        function = 3;
        SceneTransition();
    }
    private void ToSettingsHelper() {
        SceneManager.LoadScene(1);
    }

    public void ToJoyfulMystery() {
        function = 4;
        SceneTransition();
    }
    private void ToJoyfulMysteryHelper() {
        SceneManager.LoadScene(2);
    }

    public void ToLuminousMystery() {
        function = 5;
        SceneTransition();
    }
    private void ToLuminousMysteryHelper() {
        SceneManager.LoadScene(3);
    }

    public void ToSorrowfulMystery() {
        function = 6;
        SceneTransition();
    }
    private void ToSorrowfulMysteryHelper() {
        SceneManager.LoadScene(4);
    }

    public void ToGloriusMystery() {
        function = 7;
        SceneTransition();
    }
    private void ToGloriusMysteryHelper() {
        SceneManager.LoadScene(5);
    }

    public void ToEndingPrayer() {
        function = 8;
        SceneTransition();
    }
    private void ToEndingPrayerHelper() {
        SceneManager.LoadScene(6);
    }

    public void Quit() {
        function = 9;
        SceneTransition();
    }
    private void QuitHelper() {
        Application.Quit();
    }
    
    public void SceneTransition() {
        transitionObj.SetActive(true);
        StartCoroutine(SceneTransitionHelper());
    }
    private IEnumerator SceneTransitionHelper() {
        float r = transition.color.r;
        float g = transition.color.g;
        float b = transition.color.b;
        float alpha = transition.color.a;

        while(alpha < 0.999) {
            alpha += increment;
            transition.color = new Color(r, g, b, alpha);
            yield return new WaitForSeconds(sceneTick);
        }

        FunctionRunner();
    }

    private void FunctionRunner() {
        switch (function) {
            case 0:
                NextSceneHelper();
                break;
            case 1:
                PreviousSceneHelper();
                break;
            case 2:
                ToMainMenuHelper();
                break;
            case 3:
                ToSettingsHelper();
                break;
            case 4:
                ToJoyfulMysteryHelper();
                break;
            case 5:
                ToLuminousMysteryHelper();
                break;
            case 6:
                ToSorrowfulMysteryHelper();
                break;
            case 7:
                ToGloriusMysteryHelper();
                break;
            case 8:
                ToEndingPrayerHelper();
                break;
            case 9:
                QuitHelper();
                break;
            default:
                Debug.Log("This should never run");
                break;
        }
    }
    
    public void StartTransition() {
        StartCoroutine(StartTransitionHelper());
    }
    private IEnumerator StartTransitionHelper() {
        float r = startTransition.color.r;
        float g = startTransition.color.g;
        float b = startTransition.color.b;
        float alpha = startTransition.color.a;

        while(alpha > 0.001) {
            alpha -= increment;
            startTransition.color = new Color(r, g, b, alpha);
            yield return new WaitForSeconds(sceneTick);
        }

        startTransitionObj.SetActive(false);
    }
}
