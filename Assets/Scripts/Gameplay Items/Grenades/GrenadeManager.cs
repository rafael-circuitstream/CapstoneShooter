using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GrenadeManager : MonoBehaviour
{
    public GrenadeData[] grenadeDataArray;
    public int[] grenadeCounts;

    [SerializeField] private GrenadeBehavior grenadeBehavior;

    public GrenadeData currentGrenade;
    public int currentIndex = 0;

    private void Start()
    {
        grenadeCounts = new int[grenadeDataArray.Length];
        foreach (GrenadeData grenadeName in grenadeDataArray)
        {
            grenadeCounts[Array.IndexOf(grenadeDataArray, grenadeName)] = 0;
        }
        currentGrenade = grenadeDataArray[1];
    }

    public void AddGrenade(GrenadeData grenadeName, int count = 1)
    {
        int index = Array.IndexOf(grenadeDataArray, grenadeName);
        {
            if (index != -1)
            {
                grenadeCounts[index] += count;
            }
        }
        

    }


    public void RemoveGrenade(GrenadeData grenadeName, int count = 1)
    {
        int index = Array.IndexOf(grenadeDataArray, grenadeName);
        if(index != -1)
        {
            grenadeCounts[index] -= count;
            if (grenadeCounts[index] <= 0)
            {
                grenadeCounts[index] = 0;
            }
        }
        
    }


    public void CurrentGrenadeSelect() //HAVE HERE BC INPUT BASED 
    {
        if (currentIndex >= 0 && currentIndex < grenadeDataArray.Length)
        {
            currentGrenade = grenadeDataArray[currentIndex];
            Debug.Log("Current grenade: " + currentGrenade.GrenadeName);
        }
        //SWAPPING IN BETWEEN THE LIST 
    }

    public void ThrowGrenade()
    {
        int index = Array.IndexOf(grenadeDataArray, currentGrenade);
        if(index != -1  && grenadeCounts[index] > 0)
        {
            grenadeBehavior.ThrowGrenade(currentGrenade);  
            RemoveGrenade(currentGrenade);
            //ADD IF GREATER OR EQUAL TO !, CAN THROW 
            Debug.Log("Threw Grenade" + currentGrenade.GrenadeName);
        }
        else
        {
            Debug.Log("Not enough " + currentGrenade.GrenadeName + "s in inventory");
        } 
    }
}
