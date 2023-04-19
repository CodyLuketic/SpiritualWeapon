using UnityEngine;
using TMPro;

public class ScoreCanvas : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text scoreText = null;
    [SerializeField] private TMP_Text multiplierText = null;

    private int scoreDecade = 0;

    private void Start() {
        scoreDecade = PlayerPrefs.GetInt("Decades");
    }

    private void Update() {
        UpdateText();
    }

    private void UpdateText() {
        switch(scoreDecade) {
            case 0:
                scoreText.text = "Score: " + PlayerPrefs.GetInt("ScoreAllTemp", 0);
                break;
            case 1:
                scoreText.text = "Score: " + PlayerPrefs.GetInt("ScoreJoyfulTemp", 0);
                break;
            case 2:
                scoreText.text = "Score: " + PlayerPrefs.GetInt("ScoreLuminousTemp", 0);
                break;
            case 3:
                scoreText.text = "Score: " + PlayerPrefs.GetInt("ScoreSorrowfulTemp", 0);
                break;
            case 4:
                scoreText.text = "Score: " + PlayerPrefs.GetInt("ScoreGloriousTemp", 0);
                break;
            default:
                Debug.Log("Error");
                break;
        }
        
        multiplierText.text = "Bonus: x" + PlayerPrefs.GetInt("ScoreMultiplier", 1);
    }
}
