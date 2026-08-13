using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float jumpForce = 7f;
    private void FixedUpdate()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        rb.linearVelocity = new Vector3(
            playerController.MoveValue.x * velocity,
            rb.linearVelocity.y,
            playerController.MoveValue.y * velocity);   
    }
   private void Jump()
{
    if (playerController.IsJump)
    {
        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            jumpForce,
            rb.linearVelocity.z);
    }
}
}
