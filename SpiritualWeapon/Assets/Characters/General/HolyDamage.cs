using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyDamage : MonoBehaviour
{
    private SphereCollider field = null;

    [Header("Basic Values")]
    [SerializeField] private float fieldRadius = 5f;
    [SerializeField] private float damageDelay = 1f;

    private bool delayed = true;

    private void Start() {
        field = gameObject.GetComponent<SphereCollider>();
        field.radius = fieldRadius;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy") && delayed) {
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
