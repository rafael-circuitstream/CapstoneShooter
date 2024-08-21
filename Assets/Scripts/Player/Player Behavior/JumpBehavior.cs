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
    private float airMovement;
    bool IsGrounded()
    {
        return controller.isGrounded;
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
        if (IsGrounded())
        {
            airMovement = jumpForce;
        }
    }
}
