using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Pooler pooler = null;
    [SerializeField] private Animator animator = null;

    [Header("Charge Values")]
    [SerializeField] private GameObject chargeParticles = null;
    [SerializeField] private float shotCharge = 0;
    [SerializeField] private float chargeParticleAmount = 0;
    [SerializeField] private float maxAmount = 10000f;
    private float amountTemp = 0;
    [SerializeField] private float chargeParticleSize = 0;
    [SerializeField] private float maxSize = 10f;
    private float sizeTemp = 0;

    [Header("Main Attack Values")]
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private float shotDist = 1f;

    [Header("Speed Values")]
    [SerializeField] private float speedDivider = 1f;
    [SerializeField] private float shotspeed = 5f;
    [SerializeField] private float maxSpeed = 10f;
    private float speed = 0;

    [Header("Angle Values")]
    [SerializeField] private float angleDivider = 1f;
    [SerializeField] private float shotAngle = 0;
    [SerializeField] private float minAngle = 1f;
    private float angle = 0;

    private GameObject particleInstance = null;
    private ParticleSystem.MainModule mainParticles;
    private ParticleSystem.ShapeModule shapeParticles;

    private bool canAttack = true;

    private void Start() {
        amountTemp = chargeParticleAmount;
    }

    private void Update() {
        Charge();
    }

    private void Charge() {
        if(canAttack && Input.GetMouseButton(0)) {
            animator.SetBool("charging", true);

            chargeParticles.SetActive(true);

            mainParticles = chargeParticles.GetComponent<ParticleSystem>().main;
            mainParticles.maxParticles = (int) chargeParticleAmount;
            mainParticles.startSize = chargeParticleSize;

            if(chargeParticleAmount < maxAmount) {
                chargeParticleAmount += 0.1f;
            }
            if(chargeParticleSize < maxSize) {
                chargeParticleSize += 0.001f;
            }
            shotCharge++;
        } else if (canAttack & shotCharge > 0) {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack() {
        canAttack = false;
        animator.SetBool("charging", false);

        animator.SetTrigger("shoot");

        chargeParticles.SetActive(false);
        chargeParticleAmount = amountTemp;
        chargeParticleSize = sizeTemp;

        particleInstance = pooler.SelectFromPool(1, false);

        speed = shotspeed + shotCharge / speedDivider;
        if(speed > maxSpeed) {
            speed = maxSpeed;
        }

        angle = shotAngle - shotCharge / angleDivider;
        if(angle < minAngle) {
            angle = minAngle;
        }

        mainParticles = particleInstance.GetComponent<ParticleSystem>().main;
        mainParticles.startSpeed = speed;
        shapeParticles = particleInstance.GetComponent<ParticleSystem>().shape;
        shapeParticles.angle = angle;

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

    public void PlayerHit() {
        PlayerHitHelper();
    }
    private void PlayerHitHelper() {
        animator.SetTrigger("playerHit");
    }
}
