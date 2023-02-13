using System.Collections;
using UnityEngine;

public class EnemyDeathParticles : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1f;

    void Start() {
        //StartCoroutine(Countdown());
    }

    private IEnumerator Countdown() {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
