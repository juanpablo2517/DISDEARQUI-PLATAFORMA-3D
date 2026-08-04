using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    InputAction moveAction;
    InputAction jumpAction;

    public Vector2 moveValue {get; private set;}
    private bool jumpValue;

     void Start()
    {
       
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        jumpValue = jumpAction.IsPressed();

        Debug.Log("me muevo:" + moveValue);
        Debug.Log("Salto:" + jumpValue);


    }
}