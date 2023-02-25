using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyValues : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator = null;
    [SerializeField] private NavMeshAgent agent = null;

    [Header("Objects")]
    [SerializeField] private GameObject deathParticles = null;

    [SerializeField] private Material[] faces;

    private GameObject playerParticleObject = null, face = null;

    [Header("Basic Values")]
    [SerializeField] private float shrinkSpeed = 0.1f;
    [SerializeField] private float deincrement = 0.01f;
    [SerializeField] private float _health = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float playerDamage = 1f;
    [SerializeField] private float holyDamage = 1f;
    [SerializeField] private float damageDelay = 1f;
    [SerializeField] private float shrinkDelay = 1f;
    [SerializeField] private float particleHeight = 1f;

    private float tempHealth = 0;

    private bool delayed = true;

    private void Start() {
        playerParticleObject = GameObject.FindGameObjectWithTag("PlayerParticleObject");
        face = gameObject.transform.GetChild(0).GetChild(1).gameObject;

        tempHealth = _health;

        agent.speed = _speed;
    }

    private void OnParticleCollision(GameObject other) {
        if(other == playerParticleObject && delayed) {
            Debug.Log("Hit");
            delayed = false;
            DamageCheck(playerDamage);
        }
    }

    private void DamageCheck(float damageType) {
        _health -= damageType;

        if(_health <= 0) {
            StartCoroutine(Die());
        } else {
            StartCoroutine(Delayed());
        }
    }
    private IEnumerator Die() {
        animator.SetTrigger("Die");
        agent.enabled = false;
        face.GetComponent<SkinnedMeshRenderer>().material = faces[2];

        Vector3 position = gameObject.transform.position + (Vector3.up * particleHeight);
        Instantiate(deathParticles, gameObject.transform.position + Vector3.up, Quaternion.identity);

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
        _health = tempHealth;

        gameObject.SetActive(false);
    }

    private IEnumerator Delayed() {
        delayed = false;

        yield return new WaitForSeconds(damageDelay);

        delayed = true;
    }

    public void HolyDamage() {
        HolyDamageHelper();
    }
    private void HolyDamageHelper() {
        if(delayed) {
            DamageCheck(holyDamage);

            StartCoroutine(Delayed());
        }
    }
}
