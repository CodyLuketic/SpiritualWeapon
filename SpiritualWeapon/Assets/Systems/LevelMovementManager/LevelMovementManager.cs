using System.Collections;
using UnityEngine;

public class LevelMovementManager : MonoBehaviour
{
    [Header("Pooler/Objects")]
    [SerializeField] private Pooler pooler = null;

    [Header("Spawn Points")]
    [SerializeField] private Transform buildingSpawnPoint = null;
    private GameObject buildingInstance = null;
    [SerializeField] private Transform npcSpawnPoint = null;
    private GameObject npcInstance = null;
    private GameObject[] buildings = null, npcs = null;

    [Header("Spawning Values")]
    [SerializeField] private float randomX = 5f;
    private float ranX = 0;
    [SerializeField] private float randomZ = 5f;
    private float ranZ = 0;
    [SerializeField] private float buildingSpawnTime = 1f;
    [SerializeField] private float buildingSpawnTimeMult = 1f;
    [SerializeField] private float npcSpawnTime = 1f;
    [SerializeField] private float npcSpawnTimeMult = 1f;
    [SerializeField] private float lifeTime = 1f;
    private Vector3 spawnPos;
    private Coroutine buildingSpawnCoroutine = null, npcSpawnCoroutine = null;

    [Header("Movement")]
    [SerializeField] private MovingFloor movingFloor = null;
    [SerializeField] private float speedMult = 1f;
    [SerializeField] private float resetDelay = 1f;
    [SerializeField] private float objectSpeed = 1f;
    [SerializeField] private float floorSpeed = 1f;
    private bool canPause = true, canPlay = true;

    private void Start() {
        StartCoroutine(Setup());
    }

    private void Update() {
        if(canPause && Input.GetKeyDown(KeyCode.O)) {
            PauseMovement();
        }

        if(canPlay && Input.GetKeyDown(KeyCode.K)) {
            PlayMovement();
        }
    }

    private IEnumerator Setup() {
        buildingSpawnTime /= buildingSpawnTimeMult;
        npcSpawnTime /= npcSpawnTimeMult;

        buildingSpawnCoroutine = StartCoroutine(ContinuouslySpawnBuildings());
        npcSpawnCoroutine = StartCoroutine(ContinuouslySpawnNPCs());

        buildings = GameObject.FindGameObjectsWithTag("Building");
        npcs = GameObject.FindGameObjectsWithTag("NPC");

        movingFloor.GetComponent<MovingFloor>().SetSpeed(floorSpeed * speedMult);

        foreach(GameObject building in buildings) {
            building.GetComponent<AutomaticMovement>().SetSpeed(objectSpeed * speedMult);
        }

        foreach(GameObject npc in npcs) {
            npc.GetComponent<AutomaticMovement>().SetSpeed(objectSpeed * speedMult);
        }

        yield return new WaitForSeconds(resetDelay);

        buildingSpawnTime *= buildingSpawnTimeMult;
        npcSpawnTime *= npcSpawnTimeMult;

        movingFloor.GetComponent<MovingFloor>().SetSpeed(floorSpeed);

        foreach(GameObject building in buildings) {
            building.GetComponent<AutomaticMovement>().SetSpeed(objectSpeed);
        }

        foreach(GameObject npc in npcs) {
            npc.GetComponent<AutomaticMovement>().SetSpeed(objectSpeed);
        }
    }

    private IEnumerator ContinuouslySpawnBuildings() {
        while(true) {
            yield return new WaitForSeconds(buildingSpawnTime);

            SpawnBuilding();
        }
    }

    private IEnumerator ContinuouslySpawnNPCs() {
        while(true) {
            yield return new WaitForSeconds(npcSpawnTime);

            SpawnNPC();
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

    public void PauseMovement() {
        PauseMovementHelper();
    }
    private void PauseMovementHelper() {
        StopAllCoroutines();
        canPause = false;
        canPlay = true;

        movingFloor.SetSpeed(0);

        foreach (GameObject building in buildings) {
            building.GetComponent<AutomaticMovement>().SetSpeed(0);
        }

        foreach (GameObject npc in npcs) {
            npc.GetComponent<AutomaticMovement>().SetSpeed(0);
        }
    }

    public void PlayMovement() {
        PlayMovementHelper();
    }
    private void PlayMovementHelper() {
        StopAllCoroutines();
        canPause = true;
        canPlay = false;

        buildingSpawnCoroutine = StartCoroutine(ContinuouslySpawnBuildings());
        npcSpawnCoroutine = StartCoroutine(ContinuouslySpawnNPCs());

        buildings = GameObject.FindGameObjectsWithTag("Building");
        npcs = GameObject.FindGameObjectsWithTag("NPC");

        movingFloor.SetSpeed(floorSpeed);

        foreach (GameObject building in buildings) {
            building.GetComponent<AutomaticMovement>().SetSpeed(objectSpeed);
        }

        foreach (GameObject npc in npcs) {
            npc.GetComponent<AutomaticMovement>().SetSpeed(objectSpeed);
        }
    }
}
