using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject particleObject = null;
    private ParticleSystem attackParticles = null;

    [SerializeField] private float cooldown = 1f, spawnDistance = 2f;
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
        Debug.Log("Player Attacked");

        Vector3 spawnPos = gameObject.transform.position
            + (gameObject.transform.forward * spawnDistance);
        Quaternion rotation = gameObject.transform.rotation;

        particleObject.transform.position = spawnPos;
        particleObject.transform.rotation = rotation;

        attackParticles.Play();

        yield return new WaitForSeconds(cooldown);
        
        canAttack = true;
    }
}
