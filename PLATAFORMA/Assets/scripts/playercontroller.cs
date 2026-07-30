using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    InputAction moveAction;
    InputAction jumpAction;

     void Start()
    {
       
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        bool jumpValue = jumpAction.IsPressed();

        Debug.Log("me muevo:" + moveValue);
        Debug.Log("Salto:" + jumpValue);


    }
}