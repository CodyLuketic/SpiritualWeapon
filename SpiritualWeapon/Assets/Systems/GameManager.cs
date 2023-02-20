using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject rosaryCanvas = null;
    [SerializeField] private GameObject startTransitionObj = null;
    [SerializeField] private GameObject endTransitionObj = null;

    private Image transition, startTransition;

    [Header("Basic Values")]
    [SerializeField] private float increment = 0.1f;
    [SerializeField] private float sceneTick = 0.1f;

    private int function = 0;

    private void Start() {
        transition = endTransitionObj.GetComponent<Image>();
        startTransition = startTransitionObj.GetComponent<Image>();

        if(startTransitionObj.activeSelf) {
            StartTransition();
        }
    }

    public void NextScene() {
        function = 0;
        EndTransition();
    }
    private void NextSceneHelper() {
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(index + 1);
        } else {
            SceneManager.LoadScene(0);
        }
    }

    public void PreviousScene() {
        function = 1;
        EndTransition();
    }
    private void PreviousSceneHelper() {
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index > 0) {
            SceneManager.LoadScene(index - 1);
        }
    }

    public void ToSettings() {
        function = 2;
        EndTransition();
    }
    private void ToSettingsHelper() {
        SceneManager.LoadScene(0);
    }

    public void ToMainMenu() {
        function = 3;
        EndTransition();
    }
    private void ToMainMenuHelper() {
        SceneManager.LoadScene(1);
    }

    public void ToStartAndEndingPrayer() {
        function = 4;
        EndTransition();
    }
    private void ToStartAndEndingPrayerHelper() {
        SceneManager.LoadScene(2);
    }

    public void ToJoyfulMysteries() {
        function = 5;
        EndTransition();
    }
    private void ToJoyfulMysteriesHelper() {
        SceneManager.LoadScene(3);
    }

    public void ToLuminousMysteries() {
        function = 6;
        EndTransition();
    }
    private void ToLuminousMysteriesHelper() {
        SceneManager.LoadScene(8);
    }

    public void ToSorrowfulMysteries() {
        function = 7;
        EndTransition();
    }
    private void ToSorrowfulMysteriesHelper() {
        SceneManager.LoadScene(13);
    }

    public void ToGloriusMysteries() {
        function = 8;
        EndTransition();
    }
    private void ToGloriusMysteriesHelper() {
        SceneManager.LoadScene(18);
    }

    public void Quit() {
        function = 9;
        EndTransition();
    }
    private void QuitHelper() {
        Application.Quit();
    }

    public void ToTestScene() {
        function = 10;
        EndTransition();
    }
    private void ToTestSceneHelper() {
        SceneManager.LoadScene(23);
    }
    
    public void EndTransition() {
        StartCoroutine(EndTransitionHelper());
    }
    private IEnumerator EndTransitionHelper() {
        if(rosaryCanvas != null && rosaryCanvas.activeSelf) {
            rosaryCanvas.SetActive(false);
        }
        endTransitionObj.SetActive(true);

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
                ToSettingsHelper();
                break;
            case 3:
                ToMainMenuHelper();
                break;
            case 4:
                ToStartAndEndingPrayerHelper();
                break;
            case 5:
                ToJoyfulMysteriesHelper();
                break;
            case 6:
                ToLuminousMysteriesHelper();
                break;
            case 7:
                ToSorrowfulMysteriesHelper();
                break;
            case 8:
                ToGloriusMysteriesHelper();
                break;
            case 9:
                QuitHelper();
                break;
            case 10:
                ToTestSceneHelper();
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
