using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{ 
    public int currencyValue = 10;
    public void OnTriggerEnter(Collider other)
    {
        CurrencyManager.singleton.AddCurrency(currencyValue);
        Destroy(gameObject);
    }

    
}
