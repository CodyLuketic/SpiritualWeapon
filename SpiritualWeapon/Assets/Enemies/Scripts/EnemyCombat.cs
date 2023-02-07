using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private NavMeshAgent agent = null;

    private GameObject playerParticleObject = null;

    private GameObject face = null;
    [SerializeField]
    private Material[] faces;

    [SerializeField]
    private float shrinkSpeed = 0.1f, deincrement = 0.01f, hitDelay = 1f, shrinkDelay = 1f;

    private void Start() {
        playerParticleObject = GameObject.FindGameObjectWithTag("PlayerParticleObject");
        face = gameObject.transform.GetChild(0).GetChild(1).gameObject;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("Collided with Player");

            animator.SetTrigger("Attack");

            face.GetComponent<SkinnedMeshRenderer>().material = faces[1];

            StartCoroutine("Shrinker");
        }
    }

    private void OnParticleCollision(GameObject other) {
        if(other == playerParticleObject) {
            StartCoroutine("HitPlayer");
        }
    }

    private IEnumerator HitPlayer() {
        agent.enabled = false;

        animator.SetTrigger("Hit");

        face.GetComponent<SkinnedMeshRenderer>().material = faces[2];

        yield return new WaitForSeconds(hitDelay);

        agent.enabled = true;
        gameObject.SetActive(false);
    }

    private IEnumerator Shrinker() {
        yield return new WaitForSeconds(shrinkDelay);
        agent.enabled = false;

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
