using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyValues : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator = null;
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private BoxCollider boxCollider1 = null;
    [SerializeField] private BoxCollider boxCollider2 = null;

    private Pooler pooler = null;
    private EnemySpawner enemySpawner = null;
    private EnemySideSpawner enemySideSpawner = null;
    private GameObject particleInstance = null;

    [Header("Faces")]
    [SerializeField] private Material[] faces;
    [SerializeField] private SkinnedMeshRenderer faceRenderer = null;

    [Header("Enemy Values")]
    [SerializeField] private float health = 1f;
    private float tempHealth = 0;
    private bool canBeDamaged = true;
    private bool canDie = true;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float playerDamage = 1f;
    [SerializeField] private float holyDamage = 1f;
    [SerializeField] private float particleHeight = 1f;
    [SerializeField] private float resetDelay = 1f;

    [Header("Sound")]
    [SerializeField] private AudioClip[] deathClips = null;
    [SerializeField] private AudioMixer mixer = null;
    private float volume = 0, diffOutputRange = 0, diffInputRange = 0, convFactor = 0;
    private bool volumeReceived = false;
    private int random = 0;

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
        random = Random.Range(0, deathClips.Length - 1);
        AudioSource.PlayClipAtPoint(deathClips[random], transform.position, GetMixerLevel());

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

    private float GetMixerLevel(){
        volumeReceived = mixer.GetFloat("volume", out volume);
        
        if(volumeReceived){
            volume = RerangeNumber(-50, 20, 0, 2, volume);
            return volume;
        } else{
            return 0;
        }
    }

    private float RerangeNumber(float inMin, float inMax, float outMin, float outMax, float convertedValue) {
        diffOutputRange = Mathf.Abs((outMax - outMin));
        diffInputRange = Mathf.Abs((inMax - inMin));
        convFactor = (diffOutputRange / diffInputRange);
        return (outMin + (convFactor * (convertedValue - inMin)));
    }
}
