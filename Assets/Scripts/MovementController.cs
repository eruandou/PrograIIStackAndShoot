using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField] private float speed;

    private CharacterController charController;

    private Vector3 velocity;

    [SerializeField] private Transform groundChecker;

    [SerializeField] private float groundDistance = 0.4f, jumpHeight, gravityMod = 1;

    [SerializeField] private LayerMask groundMask;

    private bool isGrounded;

    private float fallingTimer;









    private void Start()
    {       
        charController = GetComponent<CharacterController>();       
        
    }


    private void Move()
    {
        Vector3 moveVector = Input.GetAxis("Horizontal") * transform.right + transform.forward * Input.GetAxis("Vertical");

        charController.Move(moveVector *  speed * Time.deltaTime);

        
     
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }
        
    }



    private void ApplyGravity()
    {

        if (!isGrounded) fallingTimer += Time.deltaTime;

        //falling timer two times used not to invoke a math method, resource-wise cheaper.

     

        velocity.y += (Physics.gravity.y * fallingTimer * fallingTimer * Time.deltaTime) * gravityMod;

        charController.Move(velocity * Time.deltaTime);
    }

    private void CheckGround()
    {
         isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);
        

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
            fallingTimer = 0;
        }
    }



    private void Update()
    {
        Move();
        CheckGround();
        ApplyGravity();
        Jump();

    }












}
