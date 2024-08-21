using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Equipment Data")]
public class EquipmentData : ScriptableObject, IInteractable
{
    [SerializeField] protected string equipmentName;
    [SerializeField] protected GameObject equipmentModel;


    public string EquipmentName => equipmentName;
    public GameObject GetEquipmentModel() => equipmentModel;

    public void Interact(PlayerController player, WeaponHolder weaponHolder)
    {
        
    }

    public void Interact(PlayerController player, EquipmentHolder equipmentHolder)
    {
        player.equipmentSwapPrompt.replaceEquipment1Button.gameObject.SetActive(true);
        player.equipmentSwapPrompt.replaceEquipment2Button.gameObject.SetActive(true);

    }

    public void OnHoverEnter()
    {
        Debug.Log("equipment pickup available");
    }

    public void OnHoverExit()
    {
        
    }

    public virtual void UseEquipment()
    {

    }
}
