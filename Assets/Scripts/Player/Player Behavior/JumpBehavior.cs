using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : MonoBehaviour
{
    [SerializeField]
    private GravitationalBehaviour gravitation;
    [SerializeField] CharacterController controller;
    [SerializeField] private LayerMask layerFilter;
    [SerializeField] private float jumpForce;
    [SerializeField] private float coyoteTime_Max;
    private float coyoteTime;
    private float airMovement;
    bool IsGrounded()
    {
        return controller.isGrounded;
    }
	private void Update()
	{
        if (IsGrounded())
            coyoteTime = coyoteTime_Max;
        else
            coyoteTime -= Time.deltaTime;
	}
	public void GravityCalculation()
    {

        airMovement += gravitation.currentGravity * Time.deltaTime;
        if (IsGrounded())
        {
            airMovement = gravitation.currentGravity*0.2f;
        }


        controller.Move(airMovement * Mathf.Abs(airMovement) * Vector3.up * Time.deltaTime);
    }

    public void JumpPlayer()
    {
        if (coyoteTime > 0f)
        {
            coyoteTime = 0f;
            airMovement = jumpForce;
        }
    }
}
