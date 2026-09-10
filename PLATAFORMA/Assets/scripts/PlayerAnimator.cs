using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator animator;

    private static readonly int IsRunningParameter = Animator.StringToHash("IsRunning");
    private static readonly int JumpParameter = Animator.StringToHash("Jump");

    private void Update()
    {
        UpdateMovementAnimation();
        UpdateJumpAnimation();
    }

    private void UpdateMovementAnimation()
    {
        if (playerController != null && animator != null)
        {
            bool isRunning = playerController.MoveValue.sqrMagnitude > 0.01f;
            animator.SetBool(IsRunningParameter, isRunning);
        }
    }

    private void UpdateJumpAnimation()
    {
        if (playerController != null && animator != null && playerController.IsJumpPressed)
        {
            animator.SetBool(JumpParameter, playerController.IsJumpPressed);
            Debug.Log("Salto");
        }

        //si estoy tocando el suelo la animacion de salto es falsa
        if (playerController != null && animator != null && playerController.IsJumpPressed == false)
        {
            animator.SetBool(JumpParameter, playerController.IsJumpPressed);
        }
    }
}

