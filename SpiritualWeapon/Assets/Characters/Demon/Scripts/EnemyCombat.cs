using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyCombat : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private float resetDelay = 1f;
    private EnemyValues valuesScript = null;
    private bool canAttack = true;

    [Header("Sound")]
    [SerializeField] private AudioClip[] attackClips = null;
    [SerializeField] private AudioMixer mixer = null;
    private float volume = 0, diffOutputRange = 0, diffInputRange = 0, convFactor = 0;
    private bool volumeReceived = false;
    private int random = 0;

    private void Start() {
        valuesScript = GetComponent<EnemyValues>();
    }

    private void OnTriggerEnter(Collider other) {
        if(canAttack && other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerScore>().ResetMultiplier();
            other.gameObject.GetComponent<PlayerCombat>().PlayerHit();

            StartCoroutine("Attack");

            canAttack = false;
        }
    }

    private IEnumerator Attack() {
        random = Random.Range(0, attackClips.Length - 1);
        AudioSource.PlayClipAtPoint(attackClips[random], transform.position, GetMixerLevel());

        valuesScript.HitSetup("Attack", 1);

        yield return new WaitForSeconds(resetDelay);

        canAttack = true;
        valuesScript.HitReset();
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
