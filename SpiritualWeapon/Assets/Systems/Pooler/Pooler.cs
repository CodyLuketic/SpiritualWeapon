using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool {
        public string name;
        public GameObject[] prefab;
        public int size;
    }

    [Header("Systems")]
    [SerializeField] private List<Pool> pools;
    private Queue<GameObject> objectPool = null;

    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private GameObject instance = null;
    
    private int indexInt = 0;
    private string indexStr = "";
    private int random = 0;

    private void Awake() {
        SetDictionary();
    }

    private void SetDictionary() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        indexInt = 0;

        foreach(Pool pool in pools) {
            objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++) {
                foreach(GameObject p in pool.prefab) {
                    GameObject obj = Instantiate(p);
                    obj.transform.parent = gameObject.transform;
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
            }

            poolDictionary.Add(indexInt.ToString(), objectPool);
            indexInt++;
        }
    }

    public GameObject SelectFromPool(int intIndex, bool randomize) {
        return SelectFromPoolHelper(intIndex, randomize);
    }

    private GameObject SelectFromPoolHelper(int intIndex, bool randomize) {
        indexStr = intIndex.ToString();
        
        if(!poolDictionary.ContainsKey(indexStr)) {
            Debug.LogWarning("Pool in index " + indexStr + " doesn't exist");
            return null;
        }

        random = Random.Range(0, 3);

        if(randomize) {
            for(int i = 0; i < random; i++) {
                instance = poolDictionary[indexStr].Dequeue();
                poolDictionary[indexStr].Enqueue(instance);
            }
        }
        
        instance = poolDictionary[indexStr].Dequeue();
        instance.SetActive(true);
        
        poolDictionary[indexStr].Enqueue(instance);

        return instance;
    }
}
