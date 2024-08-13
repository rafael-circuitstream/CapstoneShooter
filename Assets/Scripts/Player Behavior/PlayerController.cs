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
    [SerializeField] private AbilityBehavior ability;


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
        CheckAbilityInput();
        CheckGravity();
        CheckJumpInput();
        CheckLookInput();
        CheckAimDownSightInput();
        CheckReloadInput();
        CheckGravity();

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

        //MAY NEED ADDITIONAL INPUT FOR HOLDING DOWN TO SHOOT 
    }    

    private void CheckAimDownSightInput()
    {
        if (Input.GetMouseButton(1))
        {
            shoot.AimDownSight();
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

    private void CheckAbilityInput()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            ability.UseAbility();
        }
    }
}
