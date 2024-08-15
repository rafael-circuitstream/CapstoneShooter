using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour, ILootSource
{

    public LootTable lootTable;
    public Transform lootSpawnPoint;

    public Transform GetLootSpawnPoint()
    {
        return lootSpawnPoint;
    }

    public void SpawnLoot()
    {
        
        {
            foreach (LootItem item in lootTable.items)
            {
                if (Random.value < item.dropRate)
                {
                    // Spawn the loot item at the designated point
                    GameObject lootObject = Instantiate(item.lootPrefab, lootSpawnPoint.position, lootSpawnPoint.rotation);
                    
                }
            }
        }

    }

   
}
