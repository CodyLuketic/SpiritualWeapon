using System.Collections;
using UnityEngine;
using TMPro;

public class CreditText : MonoBehaviour
{
    [Header("StartText")]
    [SerializeField] private TMP_Text highScoreText = null;

    [Header("TextMovement")]
    [SerializeField] private float creditIncrement = 0.1f;
    [SerializeField] private float creditMinimum = 0.001f;
    [SerializeField] private float slow = 0.001f;
    [SerializeField] private float maxCount = 1000;
    [SerializeField] private float slowStart = 500;
    [SerializeField] private float runCount = 0;

    [Header("TextFade")]
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private TMP_Text titleText = null;
    [SerializeField] private TMP_Text mainText = null;
    [SerializeField] private TMP_Text thankYouText = null;
    [SerializeField] private float deincrement = 0.001f;
    [SerializeField] private float fadeTime = 0.1f;
    private bool endRan = false;

    private void Start() {
        switch(PlayerPrefs.GetInt("Decades")) {
            case 0:
                highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScoreAllTemp", 0);
                break;
            case 1:
                highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScoreJoyfulTemp", 0);
                break;
            case 2:
                highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScoreLuminousTemp", 0);
                break;
            case 3:
                highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScoreSorrowfulTemp", 0);
                break;
            case 4:
                highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScoreGloriousTemp", 0);
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    private void Update() {
        if(runCount < maxCount) {
            ScrollText();
        } else if(!endRan) {
            StartCoroutine(End());
        }
    }

    private void ScrollText() {
        if(runCount > slowStart && creditIncrement > 0) {
            creditIncrement -= slow;
        } else if(creditIncrement <= 0 ) {
            creditIncrement = creditMinimum;
        }

        float x = transform.position.x;
        float y = transform.position.y;
        y += creditIncrement;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);

        runCount++;
    }

    private IEnumerator End() {
        endRan = true;

        while(titleText.alpha > 0) {
            titleText.alpha -= deincrement;
            highScoreText.alpha -= deincrement;
            mainText.alpha -= deincrement;
            thankYouText.alpha -= deincrement;
            yield return new WaitForSeconds(fadeTime);
        }

        gameManager.ToMainMenu();
    }
}