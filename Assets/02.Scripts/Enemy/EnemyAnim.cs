using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//attackAnim?
public class EnemyAnim : MonoBehaviour
{
    private Enemy _enemy;
    private EnemyMove _enemyMove;

    private Animator _animator;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyMove = GetComponent<EnemyMove>();

        _animator = GetComponent<Animator>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>(); 
    }

    private void OnEnable()
    {
        _enemyMove.onMoveChanged += OnWalk;
        _enemyMove.onAttackChanged += OnAttack;
        _enemy.onHitChanged += OnHit;
        _enemy.onDeadChanged += OnDead;
    }

    private void OnDestroy()
    {
        _enemyMove.onMoveChanged -= OnWalk;
        _enemyMove.onAttackChanged -= OnAttack;
        _enemy.onDeadChanged -= OnDead;
    }

    public void DeadAniEvent()
    {
        Destroy(gameObject);
    }
 
    private void OnWalk(int nextMove)
    {
        _animator.SetInteger("WalkSpeed", nextMove);
    }

    private void OnAttack()
    {
        _animator.SetTrigger("Attack");
    }

    private void OnDead()
    {
        _animator.SetTrigger("Dead");
    }

    private void OnHit()
    {
        _animator.SetTrigger("Hit");
    }
}
