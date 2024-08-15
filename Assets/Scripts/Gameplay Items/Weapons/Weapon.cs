using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;


public class Weapon : MonoBehaviour, IInteractable

{

    public string weaponName;
    public enum AmmoType { Shrapnel, Energy, Melee } 
    public enum WeaponType { Projectile, Hitscan, Melee }

    public WeaponType weaponType;
    public AmmoType ammoType;

    [SerializeField] protected int damage;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;
    public float reloadTime;
    private bool isReloading = false;

    [SerializeField] private GameObject projectilePrefab;

    //VISUALS, change out later for specific variable we need 
    [SerializeField] protected GameObject reticle;
    [SerializeField] protected GameObject weaponVisual;


    public virtual void Shoot(Vector3 position, Quaternion rotation)
    {
         
         

        if (weaponType == WeaponType.Projectile) //PROJECTILE WEAPON
        {
            Vector3 bulletSpawnPosition = position;
            Quaternion bulletSpawnRotation = rotation;
            GameObject bullet = Instantiate(projectilePrefab, bulletSpawnPosition, bulletSpawnRotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = rotation * Vector3.forward * bulletSpeed;
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.damage = GetDamage();
        }
        else if (weaponType == WeaponType.Hitscan)  //HITSCAN WEAPON 
        {
            Debug.Log("Shooting hitscan...");
            RaycastHit hit;
           
            if (Physics.Raycast(position, rotation * Vector3.forward, out hit, range))
            {
                Debug.Log("Hitscan hit something...");
                HealthSystem healthSystem = hit.transform.GetComponent<HealthSystem>();
                if( healthSystem != null)
                {
                    healthSystem.Damage(damage);
                }     
            }
            else
            {
                Debug.Log("Hitscan did not hit anything.");
            }
        }
        else if (weaponType == WeaponType.Melee)  //MELEE WEAPON
        {
            Debug.Log("Shooting melee...");
            Collider[] hits = Physics.OverlapSphere(position, range);
            foreach (Collider hit in hits)
            {
                {
                    Debug.Log("Melee hit something...");
                    HealthSystem healthSystem = hit.transform.GetComponent<HealthSystem>();
                    if (healthSystem != null)
                    {
                        healthSystem.Damage(damage);
                    }
                }
            }
        }
        
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        //ANY VISUAL  ELEMENT FOR WEAPON WOULD BE HERE 
        isReloading = false;
    }


    protected virtual int GetDamage()
    {
        // Calculate and return damage, for example:
        return damage;
    }

    public void Interact(PlayerController player)
    {
        //PICK UP WEAPON 
        //ADD A FUMCTIOM IN THE SHOOTBEHAVIOR 
    }

    public void OnHoverEnter()
    {
        Debug.Log("Weapon pickup available");
    }

    public void OnHoverExit()
    {
       
    }
}
