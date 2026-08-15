using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float rotationSpeed = 10f;

    private void FixedUpdate()
    {
        Move();
        Rotate();
        Jump();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector3(
            playerController.MoveValue.x * velocity,
            rb.linearVelocity.y,
            playerController.MoveValue.y * velocity
        );
    }

    private void Rotate()
    {
        Vector2 moveInput = playerController.MoveValue;

        if (moveInput.sqrMagnitude > 0.01f)
        {
            Vector3 direction = new Vector3(
                moveInput.x,
                0f,
                moveInput.y
            );

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            rb.MoveRotation(
                Quaternion.Slerp(
                    rb.rotation,
                    targetRotation,
                    rotationSpeed * Time.fixedDeltaTime
                )
            );
        }
    }

    private void Jump()
    {
        if (playerController.IsJump)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                jumpForce,
                rb.linearVelocity.z
            );
        }
    }
}