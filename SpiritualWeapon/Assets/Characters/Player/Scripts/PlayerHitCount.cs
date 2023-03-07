using UnityEngine;

public class PlayerHitCount : MonoBehaviour
{
    private int hitCount = 0;

    private void Start() {
        hitCount = PlayerPrefs.GetInt("HitCount", 0);
    }

    public void IncrementHitCount() {
        IncrementHitCountHelper();
    }
    private void IncrementHitCountHelper() {
        hitCount++;

        PlayerPrefs.SetInt("HitCount", hitCount);
    }
}
