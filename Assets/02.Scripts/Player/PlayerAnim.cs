using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        PlayerController player = GetComponent<PlayerController>();
        player.OnRunChanged += HandleRun;
        player.OnJumpChanged += HandleJump;
        player.OnAttackChanged += HandleAttack;
        player.OnDashChanged += HandleDash;
    }

    private void OnDisable()
    {
        PlayerController player = GetComponent<PlayerController>();
        player.OnRunChanged -= HandleRun;
        player.OnJumpChanged -= HandleJump;
        player.OnAttackChanged -= HandleAttack;
        player.OnDashChanged -= HandleDash;
    }

    private void HandleRun(float runSpeed)
    {
        _animator.SetFloat("Run", Mathf.Abs(runSpeed));
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
