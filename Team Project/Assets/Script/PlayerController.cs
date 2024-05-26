using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float turnSpeed = 250f; 

    private CharacterController controller; 

    void Start()
    {
        
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        
        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;

        
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection = -transform.forward * moveSpeed;
        }
        else
        {
            
            if (moveDirection != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, turnSpeed * Time.deltaTime);
            }
        }

        
        controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }
}
