using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehavior : MonoBehaviour
{


    private void Start()
    {

       

    }


    public void ThrowGrenade(GrenadeData currentGrenade)
    {

        GameObject worldGrenade = currentGrenade.GetWorldGrenade();
        if (worldGrenade == null)
        {
            Debug.LogError("worldGrenade is null");
            return;
        }

        Instantiate(worldGrenade);
        //SPECIFICALLY FOR PHYSICS,INPUT, STUFF TIED TO GRENADE AND PLAYER, THE GRENADE INVENTORY TIED TO GRENADEMANGER
    }
}
