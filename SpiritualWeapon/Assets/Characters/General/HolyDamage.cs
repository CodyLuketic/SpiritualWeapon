using System.Collections;
using UnityEngine;

public class HolyDamage : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject sphere = null;
    private SphereCollider field = null;

    [Header("Basic Values")]
    [SerializeField] private float fieldRadius = 5f;

    private void Start() {
        field = gameObject.GetComponent<SphereCollider>();
        field.radius = fieldRadius;
        sphere.transform.localScale = new Vector3(fieldRadius * 2, fieldRadius * 2, fieldRadius * 2);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) {
            other.GetComponent<EnemyValues>().HolyDamage();
        }
    }
}
