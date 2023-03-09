using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool {
        public string name;
        public GameObject prefab;
        public int size;
    }

    [Header("Systems")]
    [SerializeField] private List<Pool> pools;

    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start() {
        SetDictionary();
    }

    private void SetDictionary() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        int index = 0;

        foreach(Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.parent = gameObject.transform;
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(index.ToString(), objectPool);
            index++;
        }
    }

    public GameObject SelectFromPool(int intIndex) {
        return SelectFromPoolHelper(intIndex);
    }

    private GameObject SelectFromPoolHelper(int intIndex) {
        string index = intIndex.ToString();
        
        if(!poolDictionary.ContainsKey(index)) {
            Debug.LogWarning("Pool in index " + index + " doesn't exist");
            return null;
        }
        
        GameObject instance = poolDictionary[index].Dequeue();
        instance.SetActive(true);
        
        poolDictionary[index].Enqueue(instance);

        return instance;
    }
}
