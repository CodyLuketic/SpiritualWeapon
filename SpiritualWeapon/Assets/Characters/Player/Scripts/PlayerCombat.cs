using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Pool")]
    [SerializeField] private Pooler pooler = null;

    [Header("Attack Values")]
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private float shotDist = 1f;
    [SerializeField] private float shotCharge = 0;
    [SerializeField] private float speedDivider = 1f;
    [SerializeField] private float angleDivider = 1f;
    [SerializeField] private float shotAngle = 0;
    [SerializeField] private float shotspeed = 5f;

    private GameObject particleInstance = null;
    private ParticleSystem.MainModule mainParticles;
    private ParticleSystem.ShapeModule shapeParticles;

    private bool canAttack = true;

    private void Update() {
        if(canAttack && Input.GetMouseButton(0)) {
            shotCharge++;
        } else if (canAttack & shotCharge > 0) {
            StartCoroutine(Attack());
            canAttack = false;
        }
    }

    private IEnumerator Attack() {
        particleInstance = pooler.SelectFromPool(1, false);

        mainParticles = particleInstance.GetComponent<ParticleSystem>().main;
        mainParticles.startSpeed = shotspeed + shotCharge / speedDivider;
        shapeParticles = particleInstance.GetComponent<ParticleSystem>().shape;
        shapeParticles.angle = shotAngle - shotCharge / angleDivider;

        particleInstance.transform.position = transform.position + transform.forward * shotDist;
        particleInstance.transform.rotation = transform.rotation;

        particleInstance.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(cooldown);
        
        shotCharge = 0;
        canAttack = true;
    }

    public void SetCanAttack(bool attack) {
        SetCanAttackHelper(attack);
    }
    private void SetCanAttackHelper(bool attack) {
        canAttack = attack;
    }
}
