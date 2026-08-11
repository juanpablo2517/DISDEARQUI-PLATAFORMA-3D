using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator animator;

    private static readonly int IsRunningParameter =
       Animator.StringToHash("IsRunning");

    private void Update()
    {
        UpdateMovementAnimation();
    }

    private void UpdateMovementAnimation()
    {
        bool isRunning = playerController.MoveValue.sqrMagnitude > 0.01f;

        animator.SetBool(IsRunningParameter, isRunning);
    }
}
