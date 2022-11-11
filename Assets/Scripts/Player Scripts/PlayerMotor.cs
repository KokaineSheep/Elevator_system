using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    public Transform groundCheck;

    private Vector3 playerVelocity;
    
    private bool isGrounded;
    private bool sprinting;

    //player input settings
    public float speed = 5f;
    public float gravity = -9.8f;
    public float groundDistance = 0.5f;
    public float jumpHeight = 10f;
    public float crouchTimer = 4f;

    public LayerMask groundMask;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //crouch
        if (Input.GetKey("c"))
        {
            controller.height = 1f;           
        }
        else
        {
            controller.height = 2f;
        }
        //sprint
        if (Input.GetKey("left shift"))
        {
            speed = 9f;
        }
        else
        {
            speed = 5f;
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;

        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //ground check and drop velocity to 0;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -3f;
        }

    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
