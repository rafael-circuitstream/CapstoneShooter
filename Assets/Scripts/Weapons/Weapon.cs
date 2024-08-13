using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet; //MAKE A BULLET OBJECT 
    [SerializeField] protected int damage;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;

    public IAmmoType AmmoType { get; set; }

    public virtual void Shoot()
    {
        Debug.Log($"Shooting with {AmmoType.AmmoTypeName} ammo"); //NEED TO FIGURE OUT AMMO, I SET UP AS AN INTERFACE? Maybe you have a different idea

        //GENERAL SHOOT CONTRUCTOR
    }

    public virtual void AimDownSight()
    {
        //WEAPON ZOOM 
        //INCREASED PRECISION IF APPLICABLE 
        // Invoke any UI Element for scope 
    }

    public virtual void Reload()
    {
        //RELOAD CONTRUCTOR HERE 
    }
}
