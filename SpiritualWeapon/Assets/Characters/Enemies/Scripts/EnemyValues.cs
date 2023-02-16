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
    [SerializeField] private float _health = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float playerDamage = 1f;
    [SerializeField] private float holyDamage = 1f;
    [SerializeField] private float damageDelay = 1f;
    [SerializeField] private float deathDelay = 1f;
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
        agent.enabled = false;
        animator.SetTrigger("Die");
        face.GetComponent<SkinnedMeshRenderer>().material = faces[2];

        Vector3 position = gameObject.transform.position + (Vector3.up * particleHeight);
        Instantiate(deathParticles, gameObject.transform.position + Vector3.up, Quaternion.identity);

        yield return new WaitForSeconds(deathDelay);

        agent.enabled = true;
        _health = tempHealth;

        gameObject.SetActive(false);
    }

    private IEnumerator Delayed() {
        yield return new WaitForSeconds(damageDelay);

        delayed = true;
    }

    public void HolyDamage() {
        HolyDamageHelper();
    }
    private void HolyDamageHelper() {
        DamageCheck(holyDamage);
    }
}
