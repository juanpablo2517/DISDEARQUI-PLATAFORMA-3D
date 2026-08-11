using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float velocity = 5f;
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb.linearVelocity = new Vector3(
            playerController.MoveValue.x * velocity,
            0f,
            playerController.MoveValue.y * velocity);  //diraccion * velocidad 
    }
    //crear un nevo metodo que se encargue del movimiento del personaje
    //llamar al rigidbody y moverlo con una velocidad lineal, la direccion es el moveValue, velocidad;
}
