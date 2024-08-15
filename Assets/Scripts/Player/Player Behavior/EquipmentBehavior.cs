using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBehavior : MonoBehaviour
{
    [SerializeField] private List<GameObject> equipmentPrefabs = new List<GameObject>();
    
    [SerializeField] private Equipment[] equipmentSlots;

    private void Start()
    {
        SetEquipmentSlot(0);
        SetEquipmentSlot(1);
    }
    public void SetEquipmentSlot( int slotIndex)
    {
        if (slotIndex < 0 || slotIndex > 1)
        {
            Debug.LogError("Invalid slot index. Must be 1 or 2.");
            return;
        }

        GameObject equipmentPrefab = equipmentPrefabs[slotIndex];
        Equipment equipment = equipmentPrefab.GetComponent<Equipment>();
        equipmentSlots[slotIndex] = equipment;

        //Initialize equipment into either slot 0 or 1 for equipment 
        
    }

    public void UseEquipment(int slotNumber)
    {
        if (equipmentSlots[slotNumber] != null)
        {
            equipmentSlots[slotNumber].UseEquipment();
        }

    }


    public void ChangeEquipment()
    {
        //
    }
    
}
