using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int scoreDecade = 0;
    private int scoreAll = 0;
    private int scoreJoyful = 0;
    private int scoreLuminous = 0;
    private int scoreSorrowful = 0;
    private int scoreGlorius = 0;
    private int multiplier = 1;

    private void Start() {
        scoreDecade = PlayerPrefs.GetInt("Decades");

        scoreAll = PlayerPrefs.GetInt("ScoreAllTemp");
        scoreJoyful = PlayerPrefs.GetInt("ScoreJoyfulTemp");
        scoreLuminous = PlayerPrefs.GetInt("ScoreLuminousTemp");
        scoreSorrowful = PlayerPrefs.GetInt("ScoreSorrowfulTemp");
        scoreGlorius = PlayerPrefs.GetInt("ScoreGloriusTemp");
    }

    public void IncrementScore() {
        IncrementScoreHelper();
    }
    private void IncrementScoreHelper() {
        if(multiplier < 8) {
            multiplier++;
            PlayerPrefs.SetInt("ScoreMultiplier", multiplier);
        }

        switch(scoreDecade) {
            case 0:
                scoreAll += 1 * multiplier;

                if(scoreAll > PlayerPrefs.GetInt("HighScoreAll")) {
                    PlayerPrefs.SetInt("HighScoreAll", scoreAll);
                }
                PlayerPrefs.SetInt("ScoreAllTemp", scoreAll);

                break;
            case 1:
                scoreJoyful += 1 * multiplier;

                if(scoreJoyful > PlayerPrefs.GetInt("HighScoreJoyful")) {
                    PlayerPrefs.SetInt("HighScoreJoyful", scoreJoyful);
                }
                PlayerPrefs.SetInt("ScoreJoyfulTemp", scoreJoyful);

                break;
            case 2:
                scoreLuminous += 1 * multiplier;

                if(scoreLuminous > PlayerPrefs.GetInt("HighScoreLuminous")) {
                    PlayerPrefs.SetInt("HighScoreLuminous", scoreLuminous);
                }
                PlayerPrefs.SetInt("ScoreLuminousTemp", scoreLuminous);

                break;
            case 3:
                scoreSorrowful += 1 * multiplier;

                if(scoreSorrowful > PlayerPrefs.GetInt("HighScoreSorrowful")) {
                    PlayerPrefs.SetInt("HighScoreSorrowful", scoreSorrowful);
                }
                PlayerPrefs.SetInt("ScoreSorrowfulTemp", scoreSorrowful);

                break;
            case 4:
                scoreGlorius += 1 * multiplier;

                if(scoreGlorius > PlayerPrefs.GetInt("HighScoreGlorius")) {
                    PlayerPrefs.SetInt("HighScoreGlorius", scoreGlorius);
                }
                PlayerPrefs.SetInt("ScoreGloriusTemp", scoreGlorius);

                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    public void ResetMultiplier() {
        ResetMultiplierHelper();
    }
    private void ResetMultiplierHelper() {
        multiplier = 1;
        PlayerPrefs.SetInt("ScoreMultiplier", multiplier);
    }
}
