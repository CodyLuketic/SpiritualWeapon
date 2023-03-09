using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    private Pooler pooler = null;

    [Header("Spawning Values")]
    [SerializeField] private float minRadius = 5f;
    [SerializeField] private float maxRadius = 10f;
    [SerializeField] private float spawnTime = 1f;

    private Coroutine spawnCoroutine = null;

    private void Start() {
        pooler = GetComponent<Pooler>();
        spawnCoroutine = StartCoroutine(ContinuouslySpawnEnemies());
    }

    private IEnumerator ContinuouslySpawnEnemies() {
        while(true) {
            SpawnEnemy();

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemy() {
        GameObject enemyInstance = pooler.SelectFromPool(0);

        RandomPositionHelper(enemyInstance);
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
        float ranX = Random.Range(-maxRadius, maxRadius);
        float ranZ = Random.Range(-maxRadius, maxRadius);
        if(ranX < minRadius && ranX > -minRadius && ranZ < minRadius && ranZ > -minRadius) {
            int temp = Random.Range(0, 1);

            if(temp == 1) {
                if(Mathf.Sign(ranX) == 1) {
                    ranX += minRadius;
                } else {
                    ranX -= minRadius;
                }
            } else{
                if(Mathf.Sign(ranZ) == 1) {
                    ranZ += minRadius;
                } else {
                    ranZ -= minRadius;
                }
            }
        }

        Vector3 spawnPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        spawnPos += new Vector3(ranX, 0,ranZ);

        NavMeshHit closestHit;
        if(NavMesh.SamplePosition(spawnPos, out closestHit, 500, 1 )) {
            instance.transform.position = closestHit.position;
        }
        instance.GetComponent<NavMeshAgent>().enabled = true;
    }
}
