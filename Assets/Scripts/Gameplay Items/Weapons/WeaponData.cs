using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon Data")]
[System.Serializable]
public class WeaponData : ScriptableObject, IInteractable

{

    
    public enum WeaponType { Projectile, Hitscan, Melee }

    private bool isReloading = false;


    public WeaponType weaponType;


    [SerializeField] protected string weaponName;
    [SerializeField] protected GameObject weaponModel;
    [SerializeField] public WeaponStats weaponStats = new();
    [SerializeField] private PoolCaller projectilePool;
    private float fireRate;


    public string WeaponName => weaponName;
    public GameObject GetWeaponModel() => weaponModel;


    





    //VISUALS, change out later for specific variable we need 
    [SerializeField] protected GameObject reticle;
    [SerializeField] protected GameObject weaponVisual;

    public virtual void Shoot(Vector3 position, Quaternion rotation)
    {
        float Spread() => Random.Range(-weaponStats.spread, weaponStats.spread) * 0.5f;

        var rot = Vector3.zero;
        rot.Set(Spread(), Spread(), 0f);

        rotation.eulerAngles += rot;

        if (weaponType == WeaponType.Projectile) //PROJECTILE WEAPON
        {
            var bul = projectilePool.CallItem().GetComponent<Bullet>();
            bul.Set(position, rotation, bul.bulletStats.projectile_Size * Vector3.one, weaponStats);
        }
        else if (weaponType == WeaponType.Hitscan)  //HITSCAN WEAPON 
        {
            Debug.Log("Shooting hitscan...");
            RaycastHit hit;

            if (Physics.Raycast(position, rotation * Vector3.forward, out hit, weaponStats.projectile_Range))
            {
                var healthSystem = hit.transform.GetComponent<Hitbox>();
                if (healthSystem != null)
                {
                    healthSystem.Damage(weaponStats, position);
                }
            }
        }
        else if (weaponType == WeaponType.Melee)  //MELEE WEAPON
        {
            Debug.Log("Shooting melee...");
            var forw = rotation * Vector3.forward;
            Collider[] hits = Physics.OverlapSphere(position + weaponStats.projectile_Range * forw, weaponStats.projectile_Size * 0.5f);
            foreach (Collider hit in hits)
                {
                    Debug.Log("Melee hit something...");
                    Hitbox healthSystem = hit.transform.GetComponent<Hitbox>();
                    if (healthSystem != null)
                        healthSystem.Damage(weaponStats, position);
                }
        }

    }


    public void OnHoverEnter()
    {
        Debug.Log("Weapon pickup available");
    }

    public void OnHoverExit()
    {

    }
    
    public void Interact(PlayerController player, WeaponHolder weaponHolder)
    {

        if (player.shoot.currentWeapon != null)
        {
            // Drop the current weapon
            player.shoot.DropWeapon(player.shoot.currentWeaponIndex);
  
        }

        player.shoot.PickUpWeapon(weaponHolder.myweaponData);

        //PICK UP WEAPON 
        //ADD A FUMCTIOM IN THE SHOOTBEHAVIOR 
    }

    public void Interact(PlayerController player, EquipmentHolder equipmentHolder)
    {
        throw new System.NotImplementedException();
    }

    public void Interact(PlayerController player, EquipmentData equipmentData)
    {
        throw new System.NotImplementedException();
    }
}
 