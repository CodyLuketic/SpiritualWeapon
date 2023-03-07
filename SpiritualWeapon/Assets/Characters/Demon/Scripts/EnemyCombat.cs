using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCombat : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private EnemyValues valuesScript = null;

    [Header("Components")]
    [SerializeField] private Animator animator = null;
    [SerializeField] private NavMeshAgent agent = null;

    [Header("Objects")]
    [SerializeField] private GameObject attackParticles = null;
    private GameObject currentAttackParticles = null;

    [SerializeField] private Material[] faces;

    private GameObject playerParticleObject = null, face = null;

    [Header("Basic Values")]
    [SerializeField] private float shrinkSpeed = 0.1f;
    [SerializeField] private float deincrement = 0.01f;
    [SerializeField] private float shrinkDelay = 1f;
    [SerializeField] private float particleHeight = 1f;

    private void Start() {
        playerParticleObject = GameObject.FindGameObjectWithTag("PlayerParticleObject");
        face = gameObject.transform.GetChild(0).GetChild(1).gameObject;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player") && currentAttackParticles == null) {
            other.gameObject.GetComponent<PlayerHitCount>().IncrementHitCount();
            StartCoroutine("Attack");
        }
    }

    private IEnumerator Attack() {
        animator.SetTrigger("Attack");
        agent.enabled = false;
        face.GetComponent<SkinnedMeshRenderer>().material = faces[1];

        Vector3 position = gameObject.transform.position + (Vector3.up * particleHeight);
        currentAttackParticles = Instantiate(attackParticles, gameObject.transform.position + Vector3.up, Quaternion.identity);

        yield return new WaitForSeconds(shrinkDelay);

        while(gameObject.transform.localScale.x > deincrement) {
            gameObject.transform.localScale += new Vector3(-deincrement, -deincrement, -deincrement);
            yield return new WaitForSeconds(shrinkSpeed);
        }
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false; 
        gameObject.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = false;

        gameObject.transform.localScale = new Vector3(1, 1, 1);

        gameObject.transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = true;
        gameObject.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = true;

        agent.enabled = true;
        face.GetComponent<SkinnedMeshRenderer>().material = faces[0];
        valuesScript.ResetHealth();

        gameObject.SetActive(false);
    }
}
