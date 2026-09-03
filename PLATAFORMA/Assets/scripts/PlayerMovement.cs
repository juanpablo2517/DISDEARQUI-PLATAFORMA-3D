using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GroundCheck groundCheck; // Referencia al nuevo script de suelo
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("Doble Salto & Velocidad")]
    public bool canDoubleJump = false;
    private bool hasDoubleJumped = false;
    private float currentVelocityMultiplier = 1f;

    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (groundCheck == null) groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void FixedUpdate()
    {
        rb.angularVelocity = Vector3.zero; // Evita que el Rigidbody rote por colisiones
        CheckResetJump();
        Move();
        Rotate();
        Jump();
    }

    private void CheckResetJump()
    {
        if (groundCheck != null && groundCheck.IsGrounded)
        {
            hasDoubleJumped = false;
        }
    }

    private void Move()
    {
        float speed = velocity * currentVelocityMultiplier;
        rb.linearVelocity = new Vector3(
            playerController.MoveValue.x * speed,
            rb.linearVelocity.y,
            playerController.MoveValue.y * speed
        );
    }

    private void Rotate()
    {
        Vector2 moveInput = playerController.MoveValue;

        if (moveInput.sqrMagnitude > 0.01f)
        {
            Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y);
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            rb.MoveRotation(
                Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime)
            );
        }
    }

    private void Jump()
    {
        if (playerController.IsJumpPressed)
        {
            bool isGrounded = groundCheck != null ? groundCheck.IsGrounded : Mathf.Abs(rb.linearVelocity.y) < 0.05f;

            if (isGrounded)
            {
                ExecuteJump();
            }
            else if (canDoubleJump && !hasDoubleJumped)
            {
                ExecuteJump();
                hasDoubleJumped = true;
            }

            playerController.IsJumpPressed = false;
        }
    }

    private void ExecuteJump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        currentVelocityMultiplier = multiplier;
    }
}