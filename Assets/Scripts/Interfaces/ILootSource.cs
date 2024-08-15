using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILootSource 
{
     void SpawnLoot();
    Transform GetLootSpawnPoint();
}
