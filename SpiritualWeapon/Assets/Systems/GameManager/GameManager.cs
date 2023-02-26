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

    private void Start() {
        transition = endTransitionObj.GetComponent<Image>();
        startTransition = startTransitionObj.GetComponent<Image>();

        if(startTransitionObj.activeSelf) {
            StartTransition();
        }
    }

    public void NextScene() {
        EndTransition();

        NextSceneHelper();
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
        EndTransition();

        PreviousSceneHelper();
    }
    private void PreviousSceneHelper() {
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index > 0) {
            SceneManager.LoadScene(index - 1);
        }
    }

    public void ToMainMenu() {
        EndTransition();
    }
    private void ToMainMenuHelper() {
        SceneManager.LoadScene(0);
    }

    public void ToDecadeSelection() {
        EndTransition();

        ToDecadeSelectionHelper();
    }
    private void ToDecadeSelectionHelper() {
        SceneManager.LoadScene(1);
    }

    public void ToSettings() {
        EndTransition();

        ToSettingsHelper();
    }
    private void ToSettingsHelper() {
        SceneManager.LoadScene(2);
    }

    public void ToStartingRosary() {
        EndTransition();

        ToStartingRosaryHelper();
    }
    private void ToStartingRosaryHelper() {
        SceneManager.LoadScene(3);
    }

    public void ToJoyfulMysteries() {
        EndTransition();

        ToJoyfulMysteriesHelper();
    }
    private void ToJoyfulMysteriesHelper() {
        SceneManager.LoadScene(4);
    }

    public void ToLuminousMysteries() {
        EndTransition();

        ToLuminousMysteriesHelper();
    }
    private void ToLuminousMysteriesHelper() {
        SceneManager.LoadScene(9);
    }

    public void ToSorrowfulMysteries() {
        EndTransition();

        ToSorrowfulMysteriesHelper();
    }
    private void ToSorrowfulMysteriesHelper() {
        SceneManager.LoadScene(14);
    }

    public void ToGloriusMysteries() {
        EndTransition();

        ToGloriusMysteriesHelper();
    }
    private void ToGloriusMysteriesHelper() {
        SceneManager.LoadScene(19);
    }

    public void ToEndRosary() {
        EndTransition();

        ToEndRosaryHelper();
    }
    private void ToEndRosaryHelper() {
        SceneManager.LoadScene(24);
    }

    public void Quit() {;
        EndTransition();

        QuitHelper();
    }
    private void QuitHelper() {
        Application.Quit();
    }

    public void ToTestScene() {;
        EndTransition();

        ToTestSceneHelper();
    }
    private void ToTestSceneHelper() {
        SceneManager.LoadScene(25);
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
