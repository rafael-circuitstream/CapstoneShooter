using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{
    public void Interact(PlayerController player, WeaponHolder weaponHolder);

    public void Interact(PlayerController player, EquipmentHolder equipmentHolder);

    public void OnHoverEnter();

    public void OnHoverExit();
}
