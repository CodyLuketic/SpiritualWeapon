using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovementManager : MonoBehaviour
{
    [Header("Pooler")]
    [SerializeField] private Pooler pooler = null;

    [Header("Spawn Points")]
    [SerializeField] private Transform buildingSpawnPoint = null;
    private GameObject buildingInstance = null;
    [SerializeField] private Transform npcSpawnPoint = null;
    private GameObject npcInstance = null;

    [Header("Spawning Values")]
    [SerializeField] private float randomX = 5f;
    private float ranX = 0;
    [SerializeField] private float randomZ = 5f;
    private float ranZ = 0;
    [SerializeField] private float buildingSpawnTime = 1f;
    [SerializeField] private float npcSpawnTime = 1f;
    [SerializeField] private float lifeTime = 1f;

    private Vector3 spawnPos;

    private Coroutine buildingSpawnCoroutine = null;
    private Coroutine npcSpawnCoroutine = null;

    private void Start() {
        buildingSpawnCoroutine = StartCoroutine(ContinuouslySpawnBuildings());
        npcSpawnCoroutine = StartCoroutine(ContinuouslySpawnNPCs());
    }

    private IEnumerator ContinuouslySpawnBuildings() {
        while(true) {
            SpawnBuilding();

            yield return new WaitForSeconds(buildingSpawnTime);
        }
    }

    private IEnumerator ContinuouslySpawnNPCs() {
        while(true) {
            SpawnNPC();

            yield return new WaitForSeconds(npcSpawnTime);
        }
    }

    private void SpawnBuilding() {
        buildingInstance = pooler.SelectFromPool(3, false);

        RandomPositionHelper(buildingInstance, buildingSpawnPoint);

        StartCoroutine(Lifetime(buildingInstance));
    }
    private void SpawnNPC() {
        npcInstance = pooler.SelectFromPool(4, false);

        RandomPositionHelper(npcInstance, npcSpawnPoint);

        StartCoroutine(Lifetime(npcInstance));
    }

    public void RandomPosition(GameObject instance, Transform spawnPoint) {
        RandomPositionHelper(instance, spawnPoint);
    }
    private void RandomPositionHelper(GameObject instance, Transform spawnPoint) {
        ranX = Random.Range(-randomX, randomX);
        ranZ = Random.Range(-randomZ, randomZ);

        spawnPos = spawnPoint.position + new Vector3(ranX, instance.transform.position.y,ranZ);
        instance.transform.position = spawnPos;
    }

    private IEnumerator Lifetime(GameObject instance) {
        yield return new WaitForSeconds(lifeTime);

        instance.SetActive(false);
    }
}
