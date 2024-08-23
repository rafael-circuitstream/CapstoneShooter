using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeHolder : MonoBehaviour
{
    public GrenadeData myGrenadeData;


    public void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        player.grenadeManager.AddGrenade(myGrenadeData, 1);
        Destroy(gameObject);
    }
}
