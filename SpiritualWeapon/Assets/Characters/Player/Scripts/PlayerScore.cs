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

        scoreAll = PlayerPrefs.GetInt("ScoreAllTemp", 0);
        scoreJoyful = PlayerPrefs.GetInt("ScoreJoyfulTemp", 0);
        scoreLuminous = PlayerPrefs.GetInt("ScoreLuminousTemp", 0);
        scoreSorrowful = PlayerPrefs.GetInt("ScoreSorrowfulTemp", 0);
        scoreGlorius = PlayerPrefs.GetInt("ScoreGloriusTemp", 0);
    }

    public void IncrementScore() {
        IncrementScoreHelper();
    }
    private void IncrementScoreHelper() {
        if(multiplier < 7) {
            multiplier++;
            PlayerPrefs.SetInt("ScoreMultiplier", multiplier);
        }

        switch(scoreDecade) {
            case 0:
                scoreAll += 70 * multiplier;

                if(scoreAll > PlayerPrefs.GetInt("HighScoreAll", 0)) {
                    PlayerPrefs.SetInt("HighScoreAll", scoreAll);
                }
                PlayerPrefs.SetInt("ScoreAllTemp", scoreAll);

                break;
            case 1:
                scoreJoyful += 70 * multiplier;

                if(scoreJoyful > PlayerPrefs.GetInt("HighScoreJoyful", 0)) {
                    PlayerPrefs.SetInt("HighScoreJoyful", scoreJoyful);
                }
                PlayerPrefs.SetInt("ScoreJoyfulTemp", scoreJoyful);

                break;
            case 2:
                scoreLuminous += 70 * multiplier;

                if(scoreLuminous > PlayerPrefs.GetInt("HighScoreLuminous", 0)) {
                    PlayerPrefs.SetInt("HighScoreLuminous", scoreLuminous);
                }
                PlayerPrefs.SetInt("ScoreLuminousTemp", scoreLuminous);

                break;
            case 3:
                scoreSorrowful += 70 * multiplier;

                if(scoreSorrowful > PlayerPrefs.GetInt("HighScoreSorrowful", 0)) {
                    PlayerPrefs.SetInt("HighScoreSorrowful", scoreSorrowful);
                }
                PlayerPrefs.SetInt("ScoreSorrowfulTemp", scoreSorrowful);

                break;
            case 4:
                scoreGlorius += 70 * multiplier;

                if(scoreGlorius > PlayerPrefs.GetInt("HighScoreGlorius", 0)) {
                    PlayerPrefs.SetInt("HighScoreGlorius", scoreGlorius);
                }
                PlayerPrefs.SetInt("ScoreGloriusTemp", scoreGlorius);

                break;
            default:
                Debug.Log("Error");
                break;
        }

        PlayerPrefs.Save();
    }

    public void ResetMultiplier() {
        ResetMultiplierHelper();
    }
    private void ResetMultiplierHelper() {
        multiplier = 1;
        PlayerPrefs.SetInt("ScoreMultiplier", multiplier);

        PlayerPrefs.Save();
    }
}
