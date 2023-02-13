using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private NavMeshAgent agent = null;

    private GameObject playerParticleObject = null;
    
    [SerializeField]
    private GameObject face = null, deathParticles = null, attackParticles;

    [SerializeField]
    private Material[] faces;

    [SerializeField]
    private float shrinkSpeed = 0.1f, deincrement = 0.01f, deathDelay = 1f, shrinkDelay = 1f, particleHeight;

    private bool dying = false;

    private void Start() {
        playerParticleObject = GameObject.FindGameObjectWithTag("PlayerParticleObject");
        face = gameObject.transform.GetChild(0).GetChild(1).gameObject;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            StartCoroutine("Attack");
        }
    }

    private void OnParticleCollision(GameObject other) {
        if(other == playerParticleObject && !dying) {
            dying = true;
            StartCoroutine("Die");
        }
    }

    private IEnumerator Die() {
        agent.enabled = false;
        animator.SetTrigger("Die");
        face.GetComponent<SkinnedMeshRenderer>().material = faces[2];

        Vector3 position = gameObject.transform.position + (Vector3.up * particleHeight);
        Instantiate(deathParticles, gameObject.transform.position + Vector3.up, Quaternion.identity);

        yield return new WaitForSeconds(deathDelay);

        agent.enabled = true;
        dying = false;

        gameObject.SetActive(false);
    }

    private IEnumerator Attack() {
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(shrinkDelay);

        agent.enabled = false;
        face.GetComponent<SkinnedMeshRenderer>().material = faces[1];

        Vector3 position = gameObject.transform.position + (Vector3.up * particleHeight);
        Instantiate(attackParticles, gameObject.transform.position + Vector3.up, Quaternion.identity);

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
        gameObject.SetActive(false);
    }
}
