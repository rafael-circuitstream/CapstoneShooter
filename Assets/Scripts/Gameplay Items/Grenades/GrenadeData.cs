using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Grenade Data")]
public class GrenadeData : ScriptableObject
{
    [SerializeField] protected string grenadeName;
    [SerializeField] protected GameObject worldGrenadeModel;
    
    public string GrenadeName => grenadeName; //mainly using with debugs 
    public GameObject GetWorldGrenade() => worldGrenadeModel;
}
