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
        
        
    }

    public void BuyShopItem()
    {
        
    }

    
} 
