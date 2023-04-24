using System.Collections;
using UnityEngine;

public class EnemySideSpawner : MonoBehaviour
{
    private Pooler pooler = null;
    private GameObject enemyInstance = null;

    [Header("Spawning Values")]
    [SerializeField] private Transform spawnPointLeft = null;
    [SerializeField] private Transform spawnPointRight = null;
    [SerializeField] private float spawnTime = 1f;
    private int random = 0;

    private Vector3 spawnPos;
    private UnityEngine.AI.NavMeshHit closestHit;

    private Coroutine spawnCoroutine = null;

    private void Start() {
        pooler = GetComponent<Pooler>();
        spawnCoroutine = StartCoroutine(ContinuouslySpawnEnemies());

        for(int i = 0; i < 25; i++) {
            enemyInstance = pooler.SelectFromPool(0, false);
        }
    }

    private IEnumerator ContinuouslySpawnEnemies() {
        while(true) {
            SpawnEnemy();

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemy() {
        enemyInstance = pooler.SelectFromPool(0, false);

        RandomPositionHelper(enemyInstance);

        enemyInstance.GetComponent<EnemyValues>().Reset();
    }

    public void EndSpawnCoroutine() {
        EndSpawnCoroutineHelper();
    }
    private void EndSpawnCoroutineHelper() {
        StopCoroutine(spawnCoroutine);
    }

    public void RandomPosition(GameObject instance) {
        RandomPositionHelper(instance);
    }
    private void RandomPositionHelper(GameObject instance) {
        random = Random.Range(0, 2);

        if(random == 0) {
            spawnPos = spawnPointLeft.position;
        } else {
            spawnPos = spawnPointRight.position;
        }

        instance.transform.position = spawnPos;

        /*
        if(UnityEngine.AI.NavMesh.SamplePosition(spawnPos, out closestHit, 10, 1 )) {   
            instance.transform.position = closestHit.position;
        }
        */
        instance.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
    }
}
