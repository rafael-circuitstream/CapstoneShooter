using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : MonoBehaviour
{

    private const float gravity = -9.81f;
    [SerializeField] CharacterController controller;
    [SerializeField] private LayerMask layerFilter;
    [SerializeField] private float jumpForce;
    private Vector3 velocity;
    bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, controller.radius, layerFilter);
    }

    public void GravityCalculation()
    {

        if (!IsGrounded())
        {

            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y <= 0)
        {
            velocity.y = -1f;
        }


        controller.Move(velocity * Time.deltaTime);
    }

    public void JumpPlayer()
    {
        if (IsGrounded())
        {
            velocity.y = jumpForce;
        }
    }
}
