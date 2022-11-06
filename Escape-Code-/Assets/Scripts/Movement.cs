using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpHeight = 1f;
    public float gravity = -20f;

    Vector3 moveInput = Vector3.zero;
    CharacterController playerController;

    void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Move();

        //float xMove = transform.right * Input.GetAxis("Horizontal") * speedForce * Time.fixedDeltaTime;
        /* float xMove =Input.GetAxis("Horizontal");
        float zMove =Input.GetAxis("Vertical");
        
        rb.AddForce(transform.forward * 10f * speedForce * zMove * Time.fixedDeltaTime, ForceMode.Impulse);
        rb.AddForce(transform.right * 10f * speedForce * xMove * Time.fixedDeltaTime, ForceMode.Impulse);
        if(Input.GetKeyDown(KeyCode.Space)) {rb.AddForce(new Vector3(0, speedForce * 100, 0), ForceMode.Impulse);} */
    }

    private void Move()
    {
        if(playerController.isGrounded)
        {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f , Input.GetAxis("Vertical"));
        moveInput = Vector3.ClampMagnitude(moveInput, 1f);

            if(Input.GetButton("Sprint"))
            {
                moveInput = transform.TransformDirection(moveInput) * runSpeed;
            }
            else
            {
                moveInput = transform.TransformDirection(moveInput) * walkSpeed;
            }

            if(Input.GetButton("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        moveInput.y += gravity * Time.fixedDeltaTime;
        playerController.Move(moveInput * Time.fixedDeltaTime);
    }
}
