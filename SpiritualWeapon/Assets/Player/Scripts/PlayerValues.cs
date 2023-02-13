using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerValues : MonoBehaviour
{
    [Header("Scripts/Components")]
    private NavMeshAgent agent = null;

    [Header("Basic Values")]
    [SerializeField]
    private float _health = 1f, _speed = 1f, _rotationSpeed = 1f;

    private void Start() {
        agent = gameObject.GetComponent<NavMeshAgent>();

        agent.speed = _speed;
        //agent.
    }

    public void SetHealth(float health) {
        SetHealthHelper(health);
    }
    private void SetHealthHelper(float health) {
        _health = health;
        
        if(_health <= 0) {
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death() {
        //animator.SetTrigger("Die");
        //gameObject.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(1);
    }

    // Getters
    public float GetHealth() {
        return GetHealthHelper();
    }
    private float GetHealthHelper() {
        return _health;
    }
}
