using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookBehavior : MonoBehaviour
{
    private Vector2 lookDirection;
    [SerializeField] private float lookSensitivity;
    [SerializeField] private Camera myCamera;
    public void RotatePlayer()
    {
        lookDirection.x += Input.GetAxisRaw("Mouse X") * Time.deltaTime * lookSensitivity;
        lookDirection.y += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * lookSensitivity;


        lookDirection.y = Mathf.Clamp(lookDirection.y, -85f, 85f);

        myCamera.transform.localRotation = Quaternion.Euler(-lookDirection.y, 0, 0);
        transform.rotation = Quaternion.Euler(0, lookDirection.x, 0);
    }
}
 