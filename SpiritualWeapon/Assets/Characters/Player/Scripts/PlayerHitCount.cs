using UnityEngine;
using TMPro;

public class PlayerHitCount : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private TMP_Text hitCountText = null;

    private int hitCount = 0;

    private void Start() {
        hitCount = PlayerPrefs.GetInt("HitCount", 0);

        hitCountText.text = "Hitcount: " + hitCount;
    }

    public void IncrementHitCount() {
        IncrementHitCountHelper();
    }
    private void IncrementHitCountHelper() {
        hitCount++;

        hitCountText.text = "Hitcount: " + hitCount;

        PlayerPrefs.SetInt("HitCount", hitCount);

        if(hitCount < PlayerPrefs.GetInt("LowestHitCount", 1000)) {
            PlayerPrefs.SetInt("LowestHitCount", hitCount);
        }
    }
}
