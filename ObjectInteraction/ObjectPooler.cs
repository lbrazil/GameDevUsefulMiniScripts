﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
        public Transform parent;
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> Pools;

    public Dictionary<string, Queue<GameObject>> PoolDictionary;

	void Start () {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i<pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.transform.parent = pool.parent;
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.Tag, objectPool);
        }
	}

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(!PoolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("pool with tag " + tag + " doesnt exist");
            return null;
        }

        GameObject objectToSpawn = PoolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(false);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);
        PoolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
