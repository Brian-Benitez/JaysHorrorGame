using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController Controller;

    public float Speed = 12f;
    public float Gravity = -9.81f;
    public float JumpHeight = 3f;
    public float Runspeed = 16;


    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;


    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.deltaTime);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            Controller.Move(move * Runspeed * Time.deltaTime);
        }
        
        velocity.y += Gravity * Time.deltaTime;

        Controller.Move(velocity * Time.deltaTime);
    }
}
