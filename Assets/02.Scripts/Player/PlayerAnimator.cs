using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerController playerController;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnEnable()
    {
        playerController = GetComponent<PlayerController>();
        _playerHealth = GetComponent<PlayerHealth>();

        playerController.OnRunChanged += HandleRun;
        playerController.OnJumpChanged += HandleJump;
        playerController.OnAttackChanged += HandleAttack;
        playerController.OnDashChanged += HandleDash;
        _playerHealth.OnHitChanged += HandleHit;
    }

    private void OnDisable()
    {
        playerController.OnRunChanged -= HandleRun;
        playerController.OnJumpChanged -= HandleJump;
        playerController.OnAttackChanged -= HandleAttack;
        playerController.OnDashChanged -= HandleDash;
        _playerHealth.OnHitChanged -= HandleHit;

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

    private void HandleHit()
    {
        _animator.SetTrigger("Hit");
    }
}
