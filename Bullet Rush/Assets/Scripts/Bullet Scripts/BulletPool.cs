using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

    private static BulletPool _instance;       // ******Definition of SÝngleton********
    public static BulletPool Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> bulletPoolDictionary;


    void Start()
    {
        bulletPoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> bulletPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject bullet = Instantiate(pool.prefab);
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
            }
            bulletPoolDictionary.Add(pool.tag, bulletPool);
        }
    }



    public GameObject SpawnBulletFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (bulletPoolDictionary.ContainsKey(tag) == false)
        {
            return null;
        }

        GameObject bulletNewSpanned = bulletPoolDictionary[tag].Dequeue();
        bulletNewSpanned.transform.position = position;
        bulletNewSpanned.transform.rotation = rotation;

        bulletPoolDictionary[tag].Enqueue(bulletNewSpanned);
        Debug.Log(bulletNewSpanned);

        return bulletNewSpanned;
    }


}
