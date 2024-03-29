using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Starting Values")]
    [SerializeField] private GameObject startTransitionObj = null;
    private Image startTransition = null;
    [SerializeField] private float visualIncrement = 0.1f;
    [SerializeField] private float sceneTick = 0.1f;

    [Header("Ending Values")]
    [SerializeField] private GameObject endTransitionObj = null;
    private Image endTransition = null;
    
    [Header("Audio")]
    [SerializeField] private float musicIncrement = 0.1f;
    [SerializeField] private float transitionIncrement = 0.1f;
    private AudioSource audioSource = null;
    [SerializeField] private float fadeTick = 0.1f;

    [Header("Other Values")]
    [SerializeField] private GameObject mysteryTitleObj = null;
    [SerializeField] private AudioSource musicManager = null;
    private string function = null;

    private void Start() {
        startTransition = startTransitionObj.GetComponent<Image>();
        endTransition = endTransitionObj.GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();

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

    public void ToIntroduction(int decade = 0) {
        SetPlayerPrefs(decade);

        function = "Introduction";

        EndTransition();
    }
    private void ToIntroductionHelper() {
        SceneManager.LoadScene(4);
    }

    public void ToStartRosary() {
        function = "Start";

        EndTransition();
    }
    private void ToStartRosaryHelper() {
        SceneManager.LoadScene(5);
    }

    public void ToJoyfulMysteries() {
        function = "Joyful";

        EndTransition();
    }
    private void ToJoyfulMysteriesHelper() {
        SceneManager.LoadScene(6);
    }

    public void ToLuminousMysteries() {
        function = "Luminous";

        EndTransition();
    }
    private void ToLuminousMysteriesHelper() {
        SceneManager.LoadScene(11);
    }

    public void ToSorrowfulMysteries() {
        function = "Sorrowful";

        EndTransition();
    }
    private void ToSorrowfulMysteriesHelper() {
        SceneManager.LoadScene(16);
    }

    public void ToGloriusMysteries() {
        function = "Glorius";

        EndTransition();
    }
    private void ToGloriusMysteriesHelper() {
        SceneManager.LoadScene(21);
    }

    public void ToEndRosary() {
        function = "End";

        EndTransition();
    }
    private void ToEndRosaryHelper() {
        SceneManager.LoadScene(26);
    }

    public void ToCredits() {
        function = "Credits";

        EndTransition();
    }
    private void ToCreditsHelper() {
        SceneManager.LoadScene(27);
    }
    
    public void ToTestScene() {
        function = "Test";

        EndTransition();
    }
    private void ToTestSceneHelper() {
        SceneManager.LoadScene(28);
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
            case "Introduction":
                ToIntroductionHelper();
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
            case "Credits":
                ToCreditsHelper();
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
            case 5:
            case 26:
            case 27:
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
            alpha -= visualIncrement;
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

        if(musicManager != null) {
            StartCoroutine(FadeVolume());
        }
    }
    private IEnumerator EndTransitionHelper() {
        audioSource.Play();

        endTransitionObj.SetActive(true);

        endTransition = endTransitionObj.GetComponent<Image>();
        float r = endTransition.color.r;
        float g = endTransition.color.g;
        float b = endTransition.color.b;
        float alpha = endTransition.color.a;

        while(alpha < 0.999) {
            alpha += visualIncrement;
            endTransition.color = new Color(r, g, b, alpha);
            yield return new WaitForSeconds(sceneTick);
        }

        FunctionRunner();
    }

    private IEnumerator FadeVolume() {
        while(musicManager.volume > 0 || audioSource.volume > 0) {
            musicManager.volume -= musicIncrement;
            audioSource.volume -= transitionIncrement;
            yield return new WaitForSeconds(fadeTick);
        }
    }

    private void SetPlayerPrefs(int decade) {
        PlayerPrefs.SetInt("Decades", decade);

        PlayerPrefs.SetInt("ScoreAllTemp", 0);
        PlayerPrefs.SetInt("ScoreJoyfulTemp", 0);
        PlayerPrefs.SetInt("ScoreLuminousTemp", 0);
        PlayerPrefs.SetInt("ScoreSorrowfulTemp", 0);
        PlayerPrefs.SetInt("ScoreGloriusTemp", 0);
        PlayerPrefs.SetInt("ScoreMultiplier", 1);
    }
}
