using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Behavior")]
    [SerializeField] private LookBehavior look;
    [SerializeField] private JumpBehavior jump;
    [SerializeField] private MovementBehavior move;
    [SerializeField] private ShootBehavior shoot;
    [SerializeField] private GrenadeBehavior grenade;
    [SerializeField] private EquipmentBehavior equipment;
    [SerializeField] private InteractBehavior interact;
    [SerializeField] private PassiveBehavior passive;


    [SerializeField] private ShopBehavior shop;
    private bool isShopOpen = false;

    public int totalPlayerCurrency; //TESTING

    // [SerializeField] WeaponInventory weaponInventory;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMoveInput();
        CheckShootInput();
        CheckSprintInput();
        CheckGrenadeInput();
        CheckEquipmentInput(0);
        CheckEquipmentInput(1);
        CheckGravity();
        CheckJumpInput();
        CheckLookInput();
        CheckAimDownSightInput();
        CheckReloadInput();
        CheckGravity();
        ChangeWeaponInput();
        CheckInteractInput();
        CheckShopInput();



        totalPlayerCurrency = CurrencyManager.singleton.totalCurrency;
    }

    private void CheckShopInput()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            shop.OpenShopMenu();
            isShopOpen = true;
            //Debug.Log("shop opened");
        }
        else 
        {
            shop.CloseShopMenu();
            isShopOpen = false;
            //Debug.Log("shop closed");
        }


    }

    private void ChangeWeaponInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shoot.ChangeWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            shoot.ChangeWeapon(1);
        }
        else if ( Input.GetKeyDown(KeyCode.Alpha3))
        {
            shoot.ChangeWeapon(2);
        }
    }


    private void CheckInteractInput()
    {
        if (Input.GetKeyDown(KeyCode.F));
        {
            interact.Interact(this); 
        }
    }

    private void CheckMoveInput()
    {
        move.MovePlayer();
    }

    private void CheckSprintInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            move.SetSprinting(true);
        }
        else
        {
            move.SetSprinting(false);
        }
    }

    private void CheckJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player jumped");
            jump.JumpPlayer();
        }
    }

    private void CheckGravity()
    {
        jump.GravityCalculation();
        
    }

    private void CheckLookInput()
    {
        look.RotatePlayer();
    }

    private void CheckShootInput()
    {
        if(Input.GetMouseButtonDown(0)) //CLICKING TO SHOOT 
        {
            shoot.Shoot();

        }

        //MAY NEED ADDITIONAL INPUT FOR HOLDING DOWN TO SHOOT burst, or melee
    }    

    private void CheckAimDownSightInput()
    {
        if (Input.GetMouseButton(1) && shoot.isAimingDownSight == false)
        {
            shoot.AimDownSightStart();
        }
        if (Input.GetMouseButtonUp(1) && shoot.isAimingDownSight )
        {
            shoot.AimDownSightEnd();
        }
        

    }

    private void CheckGrenadeInput()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            grenade.ThrowGrenade();
        }
    }

    private void CheckReloadInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            shoot.PlayerReload();
        }
    }

    private void CheckEquipmentInput(int slotnumber)
    {
        if(slotnumber == 0 && Input.GetKeyDown(KeyCode.E))
        {
            equipment.UseEquipment(0);
            Debug.Log("using equipment 1");
        }
        else if (slotnumber == 1 && Input.GetKeyDown(KeyCode.Q))
        {
            
            equipment.UseEquipment(1);
            Debug.Log("using equipment 2");
        }
    }
}
