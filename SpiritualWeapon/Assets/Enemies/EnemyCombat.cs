using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField]
    private float shrinkSpeed = 0.1f, deincrement = 0.01f;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("Collided with Player");
            StartCoroutine("Shrinker");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("Collided with Player");
            StartCoroutine("Shrinker");
        }
    }

    private IEnumerator Shrinker() {
        while(gameObject.transform.localScale.x > deincrement) {
            gameObject.transform.localScale += new Vector3(-deincrement, -deincrement, -deincrement);
            yield return new WaitForSeconds(shrinkSpeed);
        }
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        gameObject.SetActive(false);
    }
}
