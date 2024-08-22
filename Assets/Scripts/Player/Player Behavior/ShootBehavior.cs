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
    private float burstFireDelay;
    private float fireRate;


    public List <WeaponData> weapons = new List<WeaponData> ();
    public int currentWeaponIndex = 0;
    
    public WeaponData currentWeapon;
    public GameObject currentWeaponModel;

    private bool weapon_isHoldingDownShoot;
    private bool weapon_hasReleasedFire;


    private int ammo_magazineHeld;
    private int ammo_magazineReserve;
    private float ammo_reloadTime;
    private bool ammo_isReloading;


    private float weapon_FireburstPS;
    private int weapon_Fireburst;
    private float weapon_FireRate;


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
	private void Update()
	{
        
        if (!currentWeapon)
            return;
        if (ammo_magazineHeld <= 0)
        {
            PlayerReload();
            return;
        }

        //Weapon delays
        if (weapon_FireburstPS > 0f)
            weapon_FireburstPS -= Time.deltaTime;
        if (weapon_FireRate > 0f)
            weapon_FireRate -= Time.deltaTime;
        var fire_Rate_IsLoaded = weapon_FireRate <= 0f;
        var fire_Burst_IsLoaded = weapon_FireburstPS <= 0f;
        var fire_Burst_HasRounds = weapon_Fireburst > 0;
        var stats = currentWeapon.weaponStats;





        //Shooting conditions
        var condition_SemiAuto = 
            !stats.fireRate_FullAuto &&
            (
            (fire_Burst_IsLoaded && fire_Burst_HasRounds) ||
            (fire_Rate_IsLoaded && !fire_Burst_HasRounds && weapon_hasReleasedFire && weapon_isHoldingDownShoot)
            );

        var condition_FullAuto =
            stats.fireRate_FullAuto &&
            fire_Rate_IsLoaded &&
            weapon_isHoldingDownShoot;


        var ShootingConditions = condition_FullAuto || condition_SemiAuto;
        if (!ShootingConditions)
            return;

        //Shoot

        weapon_hasReleasedFire = false;

        currentWeapon.Shoot(weaponTip.position, weaponTip.rotation);
        if (weapon_Fireburst <= 0)
            weapon_Fireburst = stats.fireRate_burst;
        --weapon_Fireburst;


        weapon_FireburstPS = stats.fireRate_burstPPS;
        weapon_FireRate = stats.fireRate_PPS;

        --ammo_magazineHeld;

	}

    public void ChangeWeapon(int index)
    {
        if (weapons.Count == 0)
            return;
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
        if (weapons.Count == 0)
            return;
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
        ChangeWeapon(currentWeaponIndex);
    }

    public void PreviousWeapon()
    {
        if (weapons.Count == 0)
            return;
        currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Count) % weapons.Count;
        ChangeWeapon(currentWeaponIndex);
    }

	public void Shoot(bool isShooting)
    {
        weapon_isHoldingDownShoot = isShooting;
        if (!isShooting)
            weapon_hasReleasedFire = true;
    }

    public void PlayerReload()
    {
        var stats = currentWeapon.weaponStats;
        if (ammo_magazineReserve <= 0)
            return;
		if (!ammo_isReloading)
		{
            ammo_isReloading = true;
            ammo_reloadTime = stats.reloadTime;
		}
        else if(ammo_reloadTime > 0f)
		{

            ammo_isReloading = ammo_reloadTime > 0f;


            if(!ammo_isReloading)
			{
                ammo_magazineReserve -= stats.ammo_magazineHeld_Max;
                ammo_magazineHeld = stats.ammo_magazineHeld_Max;

                weapon_FireburstPS = 0;
                weapon_Fireburst = 0;
                weapon_FireRate = 0;

                if(ammo_magazineReserve < 0)
				{
                    ammo_magazineHeld += ammo_magazineReserve;
                    ammo_magazineReserve = 0;
				}
			}
		}
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
