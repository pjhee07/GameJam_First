using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    private Animator anim;
    private Enemy enemy;
    private EnemyMove enemyMove;
    private TrailRenderer trailRenderer;
    public float animationSpeed;
    public AnimationClip attackAnim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
        enemyMove = GetComponent<EnemyMove>();
        trailRenderer = GetComponentInChildren<TrailRenderer>(); //In
    }

    private void Start()
    {
        enemy.onDeadChanged += OnDead;
        enemyMove.OnEnemyAtkChanged += OnEnemyAtk;
        enemyMove.onEnemyMoveChanged += OnWalk;
    }

    private void OnDestroy()
    {
        enemy.onDeadChanged -= OnDead;
        enemyMove.OnEnemyAtkChanged -= OnEnemyAtk;
        enemyMove.onEnemyMoveChanged -= OnWalk;
    }

    void OnDead()
    {
        anim.SetTrigger("Dead");
        
    }

    public void DeadAniEvent()
    {
        Destroy(GameObject.Find("bghp_bar(Clone)"));
        Destroy(gameObject,0.5f);
    }

    public void DashStartAniEvent()
    {
        trailRenderer.emitting = true; //(+앞으로 이동)
    }

    public void DashEndAniEvent()
    {
        trailRenderer.emitting = false;
    }
    void OnEnemyAtk()
    {
        anim.SetTrigger("Dash"); //ResetTrigger?
        anim.SetTrigger("Attack");
    }

    void OnWalk(int nextMove)
    {
        anim.SetInteger("WalkSpeed", nextMove);
    }

}
