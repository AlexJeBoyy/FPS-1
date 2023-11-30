using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float currentSpeed;
    public float walkingSpeed = 10f;
    public float runningSpeed = 20f;

    public float gravity = -.5f;
    public float jumpSpeed = 0.8f;
    
    private float baselineGravity = 0.5f;

    


    private float xMove;
    private float zMove;
    private Vector3 move;




    public CharacterController characterController;
    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkingSpeed;
        baselineGravity = gravity;
        
    }

    
    void Update()
    {
        
        xMove = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        zMove = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right * xMove +
               transform.up * gravity +
               transform.forward * zMove;

        characterController.Move(move);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runningSpeed;
        }
        else
        {
            currentSpeed = walkingSpeed;
        }

        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
           gravity = baselineGravity;
            gravity *= -jumpSpeed;
        }
        
        if (gravity > baselineGravity)
        {
            gravity -= 1.5f * Time.deltaTime;
        }
        


    }
}
