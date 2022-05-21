using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour, IMoveVelocity
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float mouseSensetivity;
    [SerializeField] private float jumpHeight;

    private float gravity = -9.81f;

    private Vector3 moveDircetion;
    private Vector3 jumpVelocity;

    private float rotation;

    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Rotate();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        moveDircetion = velocityVector;
    }

    public void SetJumpVelocity(bool isJumping)
    {
        if(isJumping)
        {
            jumpVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

    }

    public void SetRotation(float mouseX)
    {
        rotation = mouseX * mouseSensetivity;
    }

    public void SetGroundForce(float y)
    {
        jumpVelocity.y = -2f;
    }

    private void Move()
    {
        moveDircetion = transform.TransformDirection(moveDircetion);

        moveDircetion *= moveSpeed;

        controller.Move(moveDircetion * Time.deltaTime);

        jumpVelocity.y += gravity * Time.deltaTime;

        controller.Move(jumpVelocity * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(rotation * Time.deltaTime * Vector3.up);
    }
}
