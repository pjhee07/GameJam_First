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
        enemyMove.onMoveChanged += OnMove;
    }

    private void OnDestroy()
    {
        enemy.onDeadChanged -= OnDead;
        enemyMove.onMoveChanged -= OnMove;
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

    public void OnMove(int nextMove)
    {
        anim.SetInteger("WalkSpeed", nextMove);
    }
}
