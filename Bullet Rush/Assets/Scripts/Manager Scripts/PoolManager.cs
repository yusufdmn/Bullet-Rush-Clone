using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    private static PoolManager _instance;
    public static PoolManager Instance { get { return _instance; } }


    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    private void Awake()
    {
        if (_instance != null && _instance != this) // ******Definition of SÝngleton********
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }                                        // ******Definition of SÝngleton********



        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject newObject = Instantiate(pool.prefab);
                newObject.SetActive(false);
                queue.Enqueue(newObject);
            }
            poolDictionary.Add(pool.tag, queue);
        }
    }



    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public ScriptableObject scriptable;
        public int size;
    }


    public GameObject SpawnBulletFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(tag) == false)
        {
            return null;
        }

        GameObject bulletNewSpanned = poolDictionary[tag].Dequeue();
        bulletNewSpanned.transform.position = position;
        bulletNewSpanned.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(bulletNewSpanned);

        return bulletNewSpanned;
    }


}
