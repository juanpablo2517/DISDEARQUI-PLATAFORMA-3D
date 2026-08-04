using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 [SerializeField] private PlayerController PlayerController;
 [SerializeField] private Rigidbody rb;
 [SerializeField] private float velocity = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
  
    void FixedUpdate()
{
    Move();
}
    private void Move()
    {
        rb.linearVelocity = PlayerController.moveValue * velocity;
    }
}
