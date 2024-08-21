using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EquipmentBehavior : MonoBehaviour
{
    
    public GameObject currentEquipmentModel1;
    private EquipmentHolder currentEquipmentHolder1;
    private EquipmentData currentEquipmentData1;

    public GameObject currentEquipmentModel2;
    private EquipmentHolder currentEquipmentHolder2;
    private EquipmentData currentEquipmentData2;

    [SerializeField] private Transform equipmentPosition;



    private void Start()
    {
        SetUpEquipment();
    }
    public void SetUpEquipment()
    {

        currentEquipmentModel1 = Instantiate(currentEquipmentModel1, equipmentPosition.position, equipmentPosition.rotation, equipmentPosition.transform);
        currentEquipmentModel2 = Instantiate(currentEquipmentModel2, equipmentPosition.position, equipmentPosition.rotation, equipmentPosition.transform);

        currentEquipmentHolder1 = currentEquipmentModel1.GetComponent<EquipmentHolder>();
        currentEquipmentHolder2 = currentEquipmentModel2.GetComponent<EquipmentHolder>();

        currentEquipmentData1 = currentEquipmentHolder1.myequipmentData;
        currentEquipmentData2 = currentEquipmentHolder2.myequipmentData;
    }

    public void ReplaceEquipment(int equipmentNumber, GameObject newEquipment)
    {

        Vector3 dropPosition = transform.position + transform.forward * 2f;
        Quaternion dropRotation = transform.rotation;

        if (equipmentNumber == 0)
        {
            
            GameObject droppedEquipment1 = Instantiate(currentEquipmentModel1, dropPosition, dropRotation);
            

            Destroy(currentEquipmentModel1);
            currentEquipmentModel1 = newEquipment;
            currentEquipmentHolder1 = currentEquipmentModel1.GetComponent<EquipmentHolder>();
            currentEquipmentData1 = currentEquipmentHolder1.myequipmentData;
        }
        else if (equipmentNumber == 1)
        {
            GameObject droppedEquipment2 = Instantiate(currentEquipmentModel2, dropPosition, dropRotation);

            Destroy(currentEquipmentModel2);
            currentEquipmentModel2 = newEquipment;
            currentEquipmentHolder2 = currentEquipmentModel2.GetComponent<EquipmentHolder>();
            currentEquipmentData2 = currentEquipmentHolder2.myequipmentData;
        }
    }
    
    


    
}
