using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static ShopManager;

public class ShopManager : MonoBehaviour
{
    public static ShopManager singleton;
    public bool isShopOpen;
    
    // Category names
    public enum Category { ShrapnelWeapons, EnergyWeapons, HeavyWeapons, Throwables, Equipment, Passives }
    
    public Dictionary <Category, List<ShopItemData>> items = new Dictionary <Category, List<ShopItemData>>();

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        foreach (Category category in System.Enum.GetValues(typeof(Category)))
        {
            items[category] = new List<ShopItemData>();
        }

        //ITEM DATA HERE FOR EACH CATEGORY, ADD IN FINAL ITEMS LATER, following this template 
        items[Category.ShrapnelWeapons].Add(new ShopItemData("Weapon", 100, "Weapon", "DESCRIPTION LISTED HERE", "Physical"));
    }
    
    public void BuyItem(Category category, int index)
    {
        ShopItemData itemData = items[category][index];

        if(CurrencyManager.singleton.totalCurrency >= itemData.price)
        {
            CurrencyManager.singleton.SubtractCurrency(itemData.price);
            
            switch (itemData.itemType)
            {
                case "Physical":
                    itemData.PhysicalItemPurchaseSpawn(itemData);
                    break;
                case "Inventory":
                    itemData.InventoryItemPurchaseInitialize(itemData); 
                    break;
                case "Ammo":
                    itemData.PhysicalItemPurchaseSpawn(itemData);
                    break;
            }
        }

         
    }

    public void OpenShop()
    {
        isShopOpen = true;
        //OPEN UI Shop here, ititialize anything
    }

    public void CloseShop()
    {
        isShopOpen = false;
        //Disable shop, disable anything here 
    }


}
