using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerController playerController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerController = GetComponent<PlayerController>();
        playerController.OnRunChanged += HandleRun;
        playerController.OnJumpChanged += HandleJump;
        playerController.OnAttackChanged += HandleAttack;
        playerController.OnDashChanged += HandleDash;
    }

    private void OnDisable()
    {
        playerController.OnRunChanged -= HandleRun;
        playerController.OnJumpChanged -= HandleJump;
        playerController.OnAttackChanged -= HandleAttack;
        playerController.OnDashChanged -= HandleDash;
    }

    private void HandleRun(float moveAmount)
    {
        _animator.SetFloat("Run", Mathf.Abs(moveAmount));
    }

    private void HandleJump(bool isJumping)
    {
        _animator.SetBool("Jump", isJumping);
    }

    private void HandleAttack()
    {
        _animator.SetTrigger("Attack");
    }

    private void HandleDash()
    {
        _animator.SetTrigger("Dash");
    }
}
