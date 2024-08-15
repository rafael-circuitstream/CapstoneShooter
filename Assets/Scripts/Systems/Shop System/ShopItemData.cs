using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItemData : MonoBehaviour
{
    public string name;
    public int price;
    public string prefabName;
    public string description;
    public string itemType; //PHYSICAL(WEAPONS, Equipment,), INVENTORY(PASSIVE,) AMMO(AMMO, Grenades?) )

    public ShopItemData(string name, int price, string prefabName, string description, string itemType)
    {
        this.name = name;
        this.price = price;
        this.prefabName = prefabName;
        this.description = description;
        this.itemType = itemType;
    }

    public void PhysicalItemPurchaseSpawn(ShopItemData itemData)
    {
       
        //INSTANTIATE IN FRONT OF THE PLAYER 
    }

    

    public void InventoryItemPurchaseInitialize(ShopItemData itemData)
    {

       //FOR PASSIVE OR ABILITIES? 
        //ADD IT TO PLAYER INVENTORY -- PASSIVE BEHAVIOR OR EQUIPMENT BEHAVIOR
        //
        //AND FIND WAY TO SWAP WITH WHAT PLAYER HAS 
    }

    public void AmmoItemPurchasedAdd(ShopItemData itemData)
    {
        // Player ammo manager + AddAmmo(amount);
    }
}
