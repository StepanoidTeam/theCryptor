using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler instance;
    public GameObject pooledObject;
    public int poolSize = 20;
    public bool resizable = true;

    List<GameObject> pooledObjects;

    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        pooledObjects = new List<GameObject>(poolSize);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }


    public GameObject GetPooledObject()
    {

        foreach (var obj in pooledObjects)
        {

            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        if (resizable)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);

            return obj;
        }

        return null;
    }

}
