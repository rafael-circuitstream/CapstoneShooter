using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class ShootBehavior : MonoBehaviour
{
    //  [SerializeField] ObjectPool bulletPool;
    [SerializeField] private List<GameObject> weaponPrefabs = new List<GameObject>();
    private Dictionary<int, GameObject> weaponInstances = new Dictionary<int, GameObject>();
    private int currentWeaponIndex = 0;
    [SerializeField] private Weapon currentWeapon;
    



    [SerializeField] private Transform weaponTip;
    [SerializeField] private Transform weaponPosition;
    public bool isAimingDownSight = false;
    
    
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera adsCamera;
   
    void Start()
    {
        ChangeWeapon(0);
    }

    public void ChangeWeapon(int index)
    {
        index = Mathf.Clamp(index, 0, weaponPrefabs.Count - 1);

        // If the weapon instance already exists, just activate it
        if (weaponInstances.TryGetValue(index, out GameObject instance))
        {
            instance.SetActive(true);
            currentWeapon = instance.GetComponent<Weapon>();
        }


        else
        {
            // Instantiate a new weapon instance if it doesn't exist
            GameObject newInstance = Instantiate(weaponPrefabs[index], weaponPosition.position, weaponPosition.rotation, weaponPosition.transform);
            weaponInstances.Add(index, newInstance);
            currentWeapon = newInstance.GetComponent<Weapon>();
        }

        // Deactivate any other weapon instances
        foreach (var kvp in weaponInstances)
        {
            if (kvp.Key != index)
            {
                kvp.Value.SetActive(false);
            }
        }





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
        {
            currentWeapon.Reload();
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
