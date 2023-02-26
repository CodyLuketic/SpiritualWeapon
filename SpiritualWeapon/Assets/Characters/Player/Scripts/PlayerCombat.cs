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
    [SerializeField] private float shotCharge = 0;
    [SerializeField] private float speedDivider = 1f;
    [SerializeField] private float angleDivider = 1f;
    [SerializeField] private float shotAngle = 0;
    [SerializeField] private float shotspeed = 5f;

    private bool canAttack = true;

    private void Start() {
        attackParticles = particleObject.GetComponent<ParticleSystem>();
    }

    private void Update() {
        if(canAttack && Input.GetMouseButton(0)) {
            shotCharge++;
        } else if (canAttack & shotCharge > 0) {
            StartCoroutine(Attack());
            canAttack = false;
        }
    }

    private IEnumerator Attack() {
        ParticleSystem.MainModule mainParticles = particleObject.GetComponent<ParticleSystem>().main;
        ParticleSystem.ShapeModule shapeParticles = particleObject.GetComponent<ParticleSystem>().shape;

        particleObject.transform.position = gameObject.transform.position + gameObject.transform.forward * shotDist;
        particleObject.transform.rotation = gameObject.transform.rotation;

        mainParticles.startSpeed = shotspeed + shotCharge/speedDivider;
        shapeParticles.angle = shotAngle - shotCharge/angleDivider;

        attackParticles.Play();

        yield return new WaitForSeconds(cooldown);
        
        shotCharge = 0;
        canAttack = true;
    }
}
