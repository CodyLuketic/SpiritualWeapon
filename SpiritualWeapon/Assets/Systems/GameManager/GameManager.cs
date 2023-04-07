using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject rosaryCanvas = null;
    [SerializeField] private GameObject startTransitionObj = null;
    [SerializeField] private GameObject mysteryTitleObj = null;
    [SerializeField] private GameObject endTransitionObj = null;

    [Header("Basic Values")]
    [SerializeField] private float increment = 0.1f;
    [SerializeField] private float sceneTick = 0.1f;

    private Image endTransition = null, startTransition = null;

    private string function = null;

    private void Start() {
        startTransition = startTransitionObj.GetComponent<Image>();
        endTransition = endTransitionObj.GetComponent<Image>();

        CheckStartTransition();
    }

    public void NextScene() {
        function = "Next";

        EndTransition();
    }
    private void NextSceneHelper() {
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(index + 1);
        } else {
            SceneManager.LoadScene(1);
        }
    }

    public void PreviousScene() {
        function = "Previous";

        EndTransition();
    }
    private void PreviousSceneHelper() {
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index > 0) {
            SceneManager.LoadScene(index - 1);
        }
    }

    public void ToMainMenu() {
        function = "Main";

        EndTransition();
    }
    private void ToMainMenuHelper() {
        SceneManager.LoadScene(1);
    }

    public void ToSettings() {
        function = "Settings";

        EndTransition();
    }
    private void ToSettingsHelper() {
        SceneManager.LoadScene(2);
    }

    public void ToDecadeSelection() {
        function = "Decade";

        EndTransition();
    }
    private void ToDecadeSelectionHelper() {
        SceneManager.LoadScene(3);
    }

    public void ToStartRosary(int decade = 0) {
        PlayerPrefs.SetInt("Decades", decade);

        function = "Start";

        EndTransition();
    }
    private void ToStartRosaryHelper() {
        SceneManager.LoadScene(4);
    }

    public void ToJoyfulMysteries() {
        function = "Joyful";

        EndTransition();
    }
    private void ToJoyfulMysteriesHelper() {
        SceneManager.LoadScene(5);
    }

    public void ToLuminousMysteries() {
        function = "Luminous";

        EndTransition();
    }
    private void ToLuminousMysteriesHelper() {
        SceneManager.LoadScene(10);
    }

    public void ToSorrowfulMysteries() {
        function = "Sorrowful";

        EndTransition();
    }
    private void ToSorrowfulMysteriesHelper() {
        SceneManager.LoadScene(15);
    }

    public void ToGloriusMysteries() {
        function = "Glorius";

        EndTransition();
    }
    private void ToGloriusMysteriesHelper() {
        SceneManager.LoadScene(20);
    }

    public void ToEndRosary() {
        function = "End";

        EndTransition();
    }
    private void ToEndRosaryHelper() {
        SceneManager.LoadScene(25);
    }
    
    public void ToTestScene() {
        function = "Test";

        EndTransition();
    }
    private void ToTestSceneHelper() {
        SceneManager.LoadScene(26);
    }

    public void Quit() {
        function = "Quit";

        EndTransition();
    }
    private void QuitHelper() {
        Application.Quit();
    }

    private void FunctionRunner() {
        switch(function) {
            case "Next":
                NextSceneHelper();
                break;
            case "Previous":
                PreviousSceneHelper();
                break;
            case "Main":
                ToMainMenuHelper();
                break;
            case "Decade":
                ToDecadeSelectionHelper();
                break;
            case "Settings":
                ToSettingsHelper();
                break;
            case "Start":
                ToStartRosaryHelper();
                break;
            case "Joyful":
                ToJoyfulMysteriesHelper();
                break;
            case "Luminous":
                ToLuminousMysteriesHelper();
                break;
            case "Sorrowful":
                ToSorrowfulMysteriesHelper();
                break;
            case "Glorius":
                ToGloriusMysteriesHelper();
                break;
            case "End":
                ToEndRosaryHelper();
                break;
            case "Quit":
                QuitHelper();
                break;
            case "Test":
                ToTestSceneHelper();
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
    
    private void CheckStartTransition() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        switch(scene) {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 25:
                StartTransition();
                break;
            default:
                break;
        }
    }
    public void StartTransition() {
        StartCoroutine(StartTransitionHelper());
    }
    private IEnumerator StartTransitionHelper() {
        startTransition = startTransitionObj.GetComponent<Image>();

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
        if(mysteryTitleObj != null) {
            mysteryTitleObj.SetActive(false);
        }
    }

    public void EndTransition() {
        StartCoroutine(EndTransitionHelper());
    }
    private IEnumerator EndTransitionHelper() {
        endTransitionObj.SetActive(true);

        endTransition = endTransitionObj.GetComponent<Image>();
        float r = endTransition.color.r;
        float g = endTransition.color.g;
        float b = endTransition.color.b;
        float alpha = endTransition.color.a;

        while(alpha < 0.999) {
            alpha += increment;
            endTransition.color = new Color(r, g, b, alpha);
            yield return new WaitForSeconds(sceneTick);
        }

        FunctionRunner();
    }
}
