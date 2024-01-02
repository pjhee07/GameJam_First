using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    Animator anim;
    Enemy enemy;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        enemy.onDeadChanged += OnDead;
    }

    private void OnDestroy()
    {
        enemy.onDeadChanged -= OnDead;
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
}
