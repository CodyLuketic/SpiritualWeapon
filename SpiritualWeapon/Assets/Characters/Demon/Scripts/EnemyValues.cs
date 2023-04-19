using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyValues : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator = null;
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private BoxCollider boxCollider1 = null;
    [SerializeField] private BoxCollider boxCollider2 = null;

    [Header("Faces")]
    [SerializeField] private Material[] faces;
    [SerializeField] private SkinnedMeshRenderer faceRenderer = null;

    [Header("Enemy Values")]
    [SerializeField] private float health = 1f;
    private float tempHealth = 0;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float playerDamage = 1f;
    [SerializeField] private float holyDamage = 1f;
    [SerializeField] private float particleHeight = 1f;
    [SerializeField] private float resetDelay = 1f;

    private Pooler pooler = null;
    private EnemySpawner enemySpawner = null;
    private EnemySideSpawner enemySideSpawner = null;
    private GameObject particleInstance = null;

    private bool canBeDamaged = true;
    private bool canDie = true;

    private void Start() {
        pooler = GameObject.FindGameObjectWithTag("Pooler").GetComponent<Pooler>();
        enemySpawner = GameObject.FindGameObjectWithTag("Pooler").GetComponent<EnemySpawner>();
        enemySideSpawner = GameObject.FindGameObjectWithTag("Pooler").GetComponent<EnemySideSpawner>();

        tempHealth = health;

        agent.speed = speed;
    }

    private void OnParticleCollision(GameObject other) {
        if(canBeDamaged && other.CompareTag("PlayerParticleObject")) {
            canBeDamaged = false;

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>().IncrementScore();

            DamageCheck(playerDamage);
        }
    }

    private void DamageCheck(float damageType) {
        health -= damageType;

        if(canDie && health <= 0) {
            StartCoroutine(Die());

            canDie = false;
        }
        
        canBeDamaged = true;
    }
    private IEnumerator Die() {
        HitSetup("Die", 2);

        yield return new WaitForSeconds(resetDelay);

        HitReset();
    }

    public void HolyDamage() {
        HolyDamageHelper();
    }
    private void HolyDamageHelper() {
        DamageCheck(holyDamage);
    }

    public void HitSetup(string anim, int face) {
        HitSetupHelper(anim, face);
    }
    private void HitSetupHelper(string anim, int face) {
        agent.enabled = false;

        animator.SetTrigger(anim);
        faceRenderer.materials[0] = faces[face];

        boxCollider1.enabled = false;
        boxCollider2.enabled = false;

        particleInstance = pooler.SelectFromPool(2, false);

        particleInstance.transform.position = transform.position + (Vector3.up * particleHeight);
    }

    public void HitReset() {
        HitResetHelper();
    }
    private void HitResetHelper() {
        agent.enabled = true;

        faceRenderer.materials[0] = faces[0];

        health = tempHealth;

        boxCollider1.enabled = true;
        boxCollider2.enabled = true;

        canBeDamaged = true;
        canDie = true;

        if(enemySpawner != null) {
            enemySpawner.RandomPosition(gameObject);
        } else if(enemySideSpawner != null){
            enemySideSpawner.RandomPosition(gameObject);
        }
        
        gameObject.SetActive(false);
    }

    public void Reset() {
        ResetHelper();
    }
    private void ResetHelper() {
        faceRenderer.materials[0] = faces[0];

        health = tempHealth;

        boxCollider1.enabled = true;
        boxCollider2.enabled = true;

        canBeDamaged = true;
        canDie = true;

        gameObject.SetActive(true);
    }
}
