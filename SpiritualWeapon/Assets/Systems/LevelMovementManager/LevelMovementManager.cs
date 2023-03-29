using System.Collections;
using UnityEngine;

public class LevelMovementManager : MonoBehaviour
{
    [Header("Pooler/Objects")]
    [SerializeField] private Pooler pooler = null;
    [SerializeField] private GameObject[] romans = null;

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
    private Vector3 spawnPos;
    private Coroutine buildingSpawnCoroutine = null, npcSpawnCoroutine = null;

    [Header("Initial Movement")]
    [SerializeField] private MovingFloor movingFloor = null;
    [SerializeField] private float speedMult = 1f;
    [SerializeField] private float resetDelay = 1f;
    [SerializeField] private float objectSpeed = 1f;
    [SerializeField] private float floorSpeed = 1f;
    private AutomaticMovement automaticMovement = null;

    [Header("Pausing and Playing")]
    [SerializeField] private float objectIncrement = 0.01f;
    [SerializeField] private float objectWaitTime = 0.01f;
    [SerializeField] private float floorIncrement = 0.00001f;
    [SerializeField] private float floorWaitTime = 0.01f;
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

        movingFloor.SetTempSpeed(floorSpeed);
        movingFloor.SetSpeed(floorSpeed * speedMult);

        foreach(GameObject building in buildings) {
            automaticMovement = building.GetComponent<AutomaticMovement>();

            automaticMovement.SetTempSpeed(objectSpeed);
            automaticMovement.SetSpeed(objectSpeed * speedMult);
        }

        foreach(GameObject npc in npcs) {
            automaticMovement = npc.GetComponent<AutomaticMovement>();

            automaticMovement.SetTempSpeed(objectSpeed);
            automaticMovement.SetSpeed(objectSpeed * speedMult);
        }

        yield return new WaitForSeconds(resetDelay);

        buildingSpawnTime *= buildingSpawnTimeMult;
        npcSpawnTime *= npcSpawnTimeMult;

        movingFloor.SetSpeed(floorSpeed);

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
    }
    private void SpawnNPC() {
        npcInstance = pooler.SelectFromPool(4, false);

        RandomPositionHelper(npcInstance, npcSpawnPoint);
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

    public void PauseMovement() {
        PauseMovementHelper();
    }
    private void PauseMovementHelper() {
        StopAllCoroutines();
        canPause = false;
        canPlay = true;

        //movingFloor.SetSpeed(0);
        movingFloor.SlowSpeed(floorIncrement, floorWaitTime);

        foreach (GameObject building in buildings) {
            //building.GetComponent<AutomaticMovement>().SetSpeed(0);
            building.GetComponent<AutomaticMovement>().SlowSpeed(objectIncrement, objectWaitTime);
        }

        foreach (GameObject npc in npcs) {
            //npc.GetComponent<AutomaticMovement>().SetSpeed(0);
            npc.GetComponent<AutomaticMovement>().SlowSpeed(objectIncrement, objectWaitTime);
        }

        foreach(GameObject r in romans) {
            r.GetComponent<Animator>().SetBool("isMarchingSM", false);
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

        //movingFloor.SetSpeed(floorSpeed);
        movingFloor.IncreaseSpeed(floorIncrement, floorWaitTime);

        foreach (GameObject building in buildings) {
            //building.GetComponent<AutomaticMovement>().SetSpeed(objectSpeed);
            building.GetComponent<AutomaticMovement>().IncreaseSpeed(objectIncrement, objectWaitTime);
        }

        foreach (GameObject npc in npcs) {
            //npc.GetComponent<AutomaticMovement>().SetSpeed(objectSpeed);
            npc.GetComponent<AutomaticMovement>().IncreaseSpeed(objectIncrement, objectWaitTime);
        }

        foreach(GameObject r in romans) {
            r.GetComponent<Animator>().SetBool("isMarchingSM", true);
        }
    }
}
