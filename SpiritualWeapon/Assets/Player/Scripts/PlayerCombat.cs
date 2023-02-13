using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Scripts/Components")]
    [SerializeField] private PlayerValues playerValues = null;

    [Header("Objects")]
    [SerializeField] private GameObject particleObject = null;
    private ParticleSystem attackParticles = null;

    [Header("Basic Values")]
    [SerializeField] private float cooldown = 1f, damage = 1f;
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
        attackParticles.Play();

        yield return new WaitForSeconds(cooldown);
        
        canAttack = true;
    }

    public float GetDamage() {
        return GetDamageHelper();
    }
    private float GetDamageHelper() {
        return damage;
    }
}
