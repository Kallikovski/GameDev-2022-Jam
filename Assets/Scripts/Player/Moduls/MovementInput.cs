using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    private float moveZ;
    private float moveX;

    private float mouseX;

    private bool jump;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;

    private void Awake()
    {
        groundMask = LayerMask.GetMask("Ground");
        groundCheck = gameObject.transform.GetChild(1).gameObject.transform;
    }

    private void Update()
    {
        jump = false;
        
        MoveVelocity Script = GetComponent<MoveVelocity>();

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        float mouseX = Input.GetAxis("Mouse X");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                jump = true;
            }
            else
            {
                Script.SetGroundForce(-1f);
            }
        }

        Vector3 moveDircetion = new Vector3(moveX, 0, moveZ).normalized;

        Script.SetVelocity(moveDircetion);
        Script.SetRotation(mouseX);
        Script.SetJumpVelocity(jump);

    }
}
