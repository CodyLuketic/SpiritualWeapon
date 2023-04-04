using UnityEngine;

public class CityManager : MonoBehaviour
{
    [Header("City")]
    [SerializeField] private GameObject city = null;

    [Header("Movement")]
    [SerializeField] private float speed = 1f;

    [Header("Building Reposition")]
    [SerializeField] private int buildingTrans;

    [Header("NPC Reposition")]
    [SerializeField] private int npcTrans;
    [SerializeField] private float initZ = 0;
    [SerializeField] private float minRan = 0;
    [SerializeField] private float maxRan = 0;
    private float random = 0;

    private void Update() {
        Move();
    }

    private void Move() {
        city.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Building")) {
            other.transform.Translate(new Vector3(buildingTrans, 0, 0));
        }

        if(other.CompareTag("NPC")) {
            random = Random.Range(minRan, maxRan);

            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, initZ);

            other.transform.Translate(new Vector3(npcTrans, 0, random));
        }
    }
}
