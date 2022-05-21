using UnityEngine;

public interface IMoveVelocity
{
    void SetVelocity(Vector3 velocityVector);
    void SetJumpVelocity(bool isJumping);
    void SetRotation(float mouseX);
    void SetGroundForce(float y);
}
