using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    public Vector2 MoveValue { get; private set; }
    public bool IsJump { get; private set; }
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }
    void Update()
    {
        MoveValue = moveAction.ReadValue<Vector2>();
        IsJump = jumpAction.WasPressedThisFrame();
    }
}