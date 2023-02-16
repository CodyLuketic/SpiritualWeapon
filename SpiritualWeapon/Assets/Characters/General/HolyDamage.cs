using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyDamage : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject sphere = null;
    private SphereCollider field = null;

    [Header("Basic Values")]
    [SerializeField] private float fieldRadius = 5f;
    [SerializeField] private float damageDelay = 1f;

    private bool delayed = true;

    private void Start() {
        field = gameObject.GetComponent<SphereCollider>();
        field.radius = fieldRadius;
        sphere.transform.localScale = new Vector3(fieldRadius * 2, fieldRadius * 2, fieldRadius * 2);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy") && delayed) {
            Debug.Log("Enemy Damaged");
            delayed = false;
            other.GetComponent<EnemyValues>().HolyDamage();

            StartCoroutine(Delayed());
        }
    }

    private IEnumerator Delayed() {
        yield return new WaitForSeconds(damageDelay);

        delayed = true;
    }
}
