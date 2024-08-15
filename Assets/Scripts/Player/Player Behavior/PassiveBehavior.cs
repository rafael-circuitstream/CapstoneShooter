using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveBehavior : MonoBehaviour
{
    [SerializeField] private GameObject passivePrefab;
    [SerializeField] private Passive passive;

    private void Start()
    {
        SetPassive();
    }

    public void SetPassive()
    {

        passive = passivePrefab.GetComponent<Passive>();
    }


    
}
