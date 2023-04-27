using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerCombat : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Pooler pooler = null;
    [SerializeField] private Animator animator = null;
    private GameObject particleInstance = null;
    private ParticleSystem.MainModule mainParticles;
    private ParticleSystem.ShapeModule shapeParticles;

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
    private bool canAttack = true;


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

    [Header("Sound")]
    [SerializeField] private AudioClip[] attackClips = null;
    [SerializeField] private AudioMixer mixer = null;
    private float volume = 0, diffOutputRange = 0, diffInputRange = 0, convFactor = 0;
    private bool volumeReceived = false;
    private int random = 0;

    private void Start() {
        amountTemp = chargeParticleAmount;
    }

    private void Update() {
        Charge();
    }

    private void Charge() {
        if(canAttack && Input.GetMouseButton(0)) {
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
        }

        if(shotCharge > 100) {
            animator.SetBool("charging", true);
        }

        if (canAttack & Input.GetMouseButtonUp(0) & shotCharge > 100) {
            StartCoroutine(Attack());
        } else if(canAttack & Input.GetMouseButtonUp(0) & shotCharge < 100) {
            StartCoroutine(QuickAttack());
            shotCharge = 0;
        }
    }

    private IEnumerator Attack() {
        random = Random.Range(0, attackClips.Length - 1);
        AudioSource.PlayClipAtPoint(attackClips[random], transform.position, GetMixerLevel());

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

        particleInstance.SetActive(true);

        particleInstance.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(cooldown);
        
        shotCharge = 0;
        canAttack = true;
    }

    private IEnumerator QuickAttack() {
        random = Random.Range(0, attackClips.Length - 1);
        AudioSource.PlayClipAtPoint(attackClips[random], transform.position, GetMixerLevel());

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

        particleInstance.SetActive(true);

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

    private float GetMixerLevel() {
        volumeReceived = mixer.GetFloat("volume", out volume);
        
        if(volumeReceived){
            volume = RerangeNumber(-50, 0, 0, 2, volume);
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
