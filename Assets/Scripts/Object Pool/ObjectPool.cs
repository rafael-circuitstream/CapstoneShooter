using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private PooledObject pooledObject;
    [SerializeField] private int poolSize;


    [SerializeField] private List<PooledObject> availableObjects = new List<PooledObject>();
    [SerializeField] private List<PooledObject> unavailableObjects = new List<PooledObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            PooledObject tempObject = Instantiate(pooledObject, transform);
            tempObject.gameObject.SetActive(false);
            tempObject.LinkPooledObject(this);
            availableObjects.Add(tempObject);
        }
    }

    public PooledObject RetrievePoolObject()
    {
        PooledObject tempObject = availableObjects[0];
        availableObjects.RemoveAt(0);
        tempObject.gameObject.SetActive(true);
        unavailableObjects.Add(tempObject);
        return tempObject;

    }


    public void SendBackToPool(PooledObject obj)
    {
        obj.gameObject.SetActive(false);
        unavailableObjects.Remove(obj);
        availableObjects.Add(obj);
    }
}
