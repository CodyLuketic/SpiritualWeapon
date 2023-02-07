using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    
    [SerializeField] private Animator animator = null;

    [SerializeField]
    private float shrinkSpeed = 0.1f, deincrement = 0.01f;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("Collided with Player");
            animator.SetTrigger("Attack");
            StartCoroutine("Shrinker");
        }
    }

    private IEnumerator Shrinker() {
        while(gameObject.transform.localScale.x > deincrement) {
            gameObject.transform.localScale += new Vector3(-deincrement, -deincrement, -deincrement);
            yield return new WaitForSeconds(shrinkSpeed);
        }
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false;
        gameObject.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = false;

        gameObject.transform.localScale = new Vector3(1, 1, 1);

        gameObject.transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = true;
        gameObject.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = true;

        gameObject.SetActive(false);
    }
}
