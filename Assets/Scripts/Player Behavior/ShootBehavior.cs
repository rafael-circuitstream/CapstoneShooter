using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    
    
    [SerializeField] Weapon currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AimDownSight()
    {
        currentWeapon.AimDownSight();   
    }

    public void Shoot()
    {  
        currentWeapon.Shoot();
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

    
}
