using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    Animator anim;
    Enemy enemy;
    EnemyMove enemyMove;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
        enemyMove = GetComponent<EnemyMove>();
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
        Destroy(gameObject);
    }

    void OnEnemyAtk()
    {
        anim.SetTrigger("Attack");
    }

    void OnWalk(int nextMove)
    {
        anim.SetInteger("WalkSpeed", nextMove);
    }
}
