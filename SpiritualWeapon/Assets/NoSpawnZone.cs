using UnityEngine;

public class NoSpawnZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy")) {
            gameObject.SetActive(false);
        }
    }
}
