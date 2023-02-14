using UnityEngine;
using TMPro;

public class PlayerHitCount : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private TMP_Text hitCountText = null;

    private int hitCount = 0;

    public void IncrementHitCount() {
        IncrementHitCountHelper();
    }
    private void IncrementHitCountHelper() {
        hitCount++;

        hitCountText.text = "Hitcount: " + hitCount;
    }
}
