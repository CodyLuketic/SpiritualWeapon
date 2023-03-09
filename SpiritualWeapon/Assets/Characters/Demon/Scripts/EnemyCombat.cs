using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    [Header("Shrink Values")]
    [SerializeField] private float shrinkSpeed = 0.1f;
    [SerializeField] private float deincrement = 0.01f;
    [SerializeField] private float shrinkDelay = 1f;

    private EnemyValues valuesScript = null;

    private bool canAttack = true;

    private void Start() {
        valuesScript = GetComponent<EnemyValues>();
    }

    private void OnTriggerEnter(Collider other) {
        if(canAttack && other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerHitCount>().IncrementHitCount();

            StartCoroutine("Attack");

            canAttack = false;
        }
    }

    private IEnumerator Attack() {
        valuesScript.HitSetup("Attack", 1);

        yield return new WaitForSeconds(shrinkDelay);

        while(gameObject.transform.localScale.x > deincrement) {
            gameObject.transform.localScale += new Vector3(-deincrement, -deincrement, -deincrement);
            yield return new WaitForSeconds(shrinkSpeed);
        }

        //gameObject.transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false; 
        //gameObject.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = false;

        //gameObject.transform.localScale = new Vector3(1, 1, 1);

        //gameObject.transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = true;
        //gameObject.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = true;

        canAttack = true;
        valuesScript.HitReset();
    }
}
