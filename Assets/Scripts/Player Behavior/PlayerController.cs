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


    [SerializeField] WeaponInventory weaponInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckMoveInput();
        CheckShootInput();
        CheckGrenadeInput();
        CheckAbilityInput();
        CheckJumpInput();
        CheckLookInput();
        CheckAimDownSightInput();
        CheckReloadInput();

    }
    private void CheckMoveInput()
    {
        //CALL MOVE BEHAVIOR HERE 
    }

    private void CheckJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump.Jump();
        }
    }

    private void CheckLookInput()
    {
        //ADD LOOK BEHAVIOR SCRIPT INPUT HERE 
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
