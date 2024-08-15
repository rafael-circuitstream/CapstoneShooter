using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehavior : MonoBehaviour
{
    public void OpenShopMenu()
    {
        if(ShopManager.singleton.isShopOpen == false)
        {
            ShopManager.singleton.OpenShop();
        }
        
    }

    public void CloseShopMenu()
    {
        if(ShopManager.singleton.isShopOpen == true)
        {
            ShopManager.singleton.CloseShop();
        }
        
    }

    public void BuyShopItem()
    {
        
    }

    
} 
