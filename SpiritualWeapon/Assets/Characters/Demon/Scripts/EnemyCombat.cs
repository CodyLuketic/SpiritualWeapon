using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private float resetDelay = 1f;
    private EnemyValues valuesScript = null;
    private bool canAttack = true;

    [Header("Sound")]
    [SerializeField] private AudioClip[] attackClips = null;
    private AudioSource audioSource = null;
    private int random = 0;

    private void Start() {
        valuesScript = GetComponent<EnemyValues>();
        audioSource = GetComponent<AudioSource>();
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
        random = Random.Range(0, attackClips.Length - 1);
        audioSource.clip = attackClips[random];
        audioSource.Play();

        valuesScript.HitSetup("Attack", 1);

        yield return new WaitForSeconds(resetDelay);

        canAttack = true;
        valuesScript.HitReset();
    }
}
