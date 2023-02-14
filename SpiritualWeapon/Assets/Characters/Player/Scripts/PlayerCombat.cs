using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Objects/Components")]
    [SerializeField] private GameObject particleObject = null;
    private ParticleSystem attackParticles = null;

    [Header("Basic Values")]
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private float shotDist = 1f;

    private bool canAttack = true;

    private void Start() {
        attackParticles = particleObject.GetComponent<ParticleSystem>();
    }

    private void Update() {
        if(Input.GetAxis("Fire1") > 0 && canAttack) {
            StartCoroutine(Attack());
            canAttack = false;
        }
    }

    private IEnumerator Attack() {
        particleObject.transform.position = gameObject.transform.position + gameObject.transform.forward * shotDist;
        particleObject.transform.rotation = gameObject.transform.rotation;

        attackParticles.Play();

        yield return new WaitForSeconds(cooldown);
        
        canAttack = true;
    }
}
