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

    [Header("Shrink Values")]
    [SerializeField] private float shrinkSpeed = 0.1f;
    [SerializeField] private float deincrement = 0.01f;
    [SerializeField] private float shrinkDelay = 1f;

    [Header("Enemy Values")]
    [SerializeField] private float health = 1f;
    private float tempHealth = 0;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float playerDamage = 1f;
    [SerializeField] private float holyDamage = 1f;
    [SerializeField] private float particleHeight = 1f;

    private Pooler pooler = null;
    private EnemySpawner enemySpawner = null;
    private GameObject particleInstance = null;

    private bool canBeDamaged = true;
    private bool canDie = true;

    private void Start() {
        pooler = GameObject.FindGameObjectWithTag("Pooler").GetComponent<Pooler>();
        enemySpawner = GameObject.FindGameObjectWithTag("Pooler").GetComponent<EnemySpawner>();

        tempHealth = health;

        agent.speed = speed;
    }

    private void OnParticleCollision(GameObject other) {
        if(canBeDamaged && other.CompareTag("PlayerParticleObject")) {
            DamageCheck(playerDamage);

            canBeDamaged = false;
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

        yield return new WaitForSeconds(shrinkDelay);

        while(transform.localScale.x > deincrement) {
            transform.localScale += new Vector3(-deincrement, -deincrement, -deincrement);
            yield return new WaitForSeconds(shrinkSpeed);
        }

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
        enemySpawner.RandomPosition(gameObject);
        agent.enabled = true;

        faceRenderer.materials[0] = faces[0];

        health = tempHealth;

        boxCollider1.enabled = true;
        boxCollider2.enabled = true;

        canDie = true;
        
        gameObject.SetActive(false);
    }
}
