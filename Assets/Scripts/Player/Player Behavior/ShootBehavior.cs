using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

 
public class ShootBehavior : MonoBehaviour
{
    //  [SerializeField] ObjectPool bulletPool;
    
    public List <WeaponData> weapons = new List<WeaponData> ();
    public int currentWeaponIndex = 0;
    
    public WeaponData currentWeapon;
    public GameObject currentWeaponModel;



    [SerializeField] private Transform weaponTip;
    [SerializeField] private Transform weaponPosition;
    public bool isAimingDownSight = false;
    
    
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera adsCamera;
   
    void Start()
    {
        currentWeaponIndex = 0;
        ChangeWeapon(currentWeaponIndex);
        
    }

    
    public void ChangeWeapon(int index)
    {
        Debug.Log("Changing to weapon at index: " + index);
        index = Mathf.Clamp(index, 0, weapons.Count - 1);
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }
        currentWeapon = weapons[index];
        currentWeaponModel = Instantiate(currentWeapon.GetWeaponModel(), weaponPosition.position, weaponPosition.rotation, weaponPosition.transform);
        currentWeaponModel.layer = LayerMask.NameToLayer("AttachedToPlayer");
        Debug.Log("my weapon is now" + currentWeapon.WeaponName);

    }

    
    public void DropWeapon(int index)
    {
        if (index >= 0 && index < weapons.Count)
        {
            GameObject weaponToDrop = Instantiate(currentWeapon.GetWeaponModel());
            weaponToDrop.transform.position = transform.position + transform.forward * 2f;
            weaponToDrop.SetActive(true);
            WeaponHolder weaponHolder = weaponToDrop.GetComponent<WeaponHolder>();
            weaponHolder.currentWorldWeapon = weaponToDrop;

            if (currentWeaponModel != null)
            { 
                Destroy(currentWeaponModel);
            }
            currentWeapon = null;
            weapons.RemoveAt(index);

        }
        else
            {
                Debug.LogWarning("Weapon not found or invalid index.");
            }
        
    }
    
    public void PickUpWeapon(WeaponData weaponData)
    {
        // Add the picked up weapon to the weapons list
        weapons.Add(weaponData);

        currentWeaponIndex = weapons.Count - 1;
        currentWeapon = weaponData;
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }
        currentWeaponModel = Instantiate(currentWeapon.GetWeaponModel(), weaponPosition.position, weaponPosition.rotation, weaponPosition.transform);

    }
    
    
    public void NextWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
        ChangeWeapon(currentWeaponIndex);
    }

    public void PreviousWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Count) % weapons.Count;
        ChangeWeapon(currentWeaponIndex);
    }

    public void Shoot()
    {

        currentWeapon.Shoot(weaponTip.position, weaponTip.rotation);
        
    }

    public void PlayerReload()
    {
        currentWeapon.Reload();
    }

    private void EmptyWeaponReload()
    {
         /*currentWeapon ammo goes to zero */
       // {
        //    currentWeapon.Reload();
    //    }
    }


    public void  AimDownSightStart()
    {
        isAimingDownSight = true;
        mainCamera.enabled = false;
        adsCamera.enabled = true;
        //mainUICanvas.enabled = false;
        // adsUICanvas.enabled = true;
        // Play ADS animation

    }

    public  void AimDownSightEnd()
    {
        isAimingDownSight = false;
        mainCamera.enabled = true;
        adsCamera.enabled = false;
        //mainUICanvas.enabled = true;
        //adsUICanvas.enabled = false;
        // Play ADS animation (reverse)
     
    }

    
}
