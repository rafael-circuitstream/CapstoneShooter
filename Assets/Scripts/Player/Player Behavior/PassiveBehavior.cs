using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveBehavior : MonoBehaviour
{
    public PassiveData attachedPassive;

    private void Start()
    {
        SetPassive();
    }

    public void SetPassive()
    {
        //ANYGAME OBJECT SETUP, REFRENCE EQUIPMENT 
        
    }

    public void SwapPassive(PassiveData newPassive)
    {
        Vector3 dropPosition = transform.position + transform.forward * 2f;
        Quaternion dropRotation = transform.rotation;

        GameObject droppedPassive = Instantiate(attachedPassive.GetWorldPassive(), dropPosition, dropRotation);

        attachedPassive = newPassive; 
        

    }


    
}
