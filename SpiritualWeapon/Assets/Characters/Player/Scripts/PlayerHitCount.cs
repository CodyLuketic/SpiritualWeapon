using UnityEngine;

public class PlayerHitCount : MonoBehaviour
{
    private int hitDecade = 0;
    private int hitCountAll = 0;
    private int hitCountJoyful = 0;
    private int hitCountLuminous = 0;
    private int hitCountSorrowful = 0;
    private int hitCountGlorius = 0;

    private void Start() {
        hitDecade = PlayerPrefs.GetInt("Decades");

        hitCountAll = PlayerPrefs.GetInt("HitCountAll");
        hitCountJoyful = PlayerPrefs.GetInt("HitCountJoyful");
        hitCountLuminous = PlayerPrefs.GetInt("HitCountLuminous");
        hitCountSorrowful = PlayerPrefs.GetInt("HitCountSorrowful");
        hitCountGlorius = PlayerPrefs.GetInt("HitCountGlorius");
    }

    public void IncrementHitCount() {
        IncrementHitCountHelper();
    }
    private void IncrementHitCountHelper() {
        switch(hitDecade) {
            case 0:
                hitCountAll++;
                PlayerPrefs.SetInt("HitCount", hitCountAll);

                break;
            case 1:
                hitCountJoyful++;
                PlayerPrefs.SetInt("HitCount", hitCountJoyful);

                break;
            case 2:
                hitCountLuminous++;
                PlayerPrefs.SetInt("HitCount", hitCountLuminous);

                break;
            case 3:
                hitCountSorrowful++;
                PlayerPrefs.SetInt("HitCount", hitCountSorrowful);

                break;
            case 4:
                hitCountGlorius++;
                PlayerPrefs.SetInt("HitCount", hitCountGlorius);

                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}
