using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, ILootSource
{
    public UnityEvent onEnemyDeath;
    public Transform GetLootSpawnPoint()
    {
        throw new System.NotImplementedException();
    }

    public void SpawnLoot()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        onEnemyDeath.Invoke();
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
