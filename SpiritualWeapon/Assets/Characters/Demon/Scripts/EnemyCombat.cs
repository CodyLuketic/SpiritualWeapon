using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private float resetDelay = 1f;

    private EnemyValues valuesScript = null;

    private bool canAttack = true;

    private void Start() {
        valuesScript = GetComponent<EnemyValues>();
    }

    private void OnTriggerEnter(Collider other) {
        if(canAttack && other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerScore>().ResetMultiplier();
            other.gameObject.GetComponent<PlayerCombat>().PlayerHit();

            StartCoroutine("Attack");

            canAttack = false;
        }
    }

    private IEnumerator Attack() {
        valuesScript.HitSetup("Attack", 1);

        yield return new WaitForSeconds(resetDelay);

        canAttack = true;
        valuesScript.HitReset();
    }
}
