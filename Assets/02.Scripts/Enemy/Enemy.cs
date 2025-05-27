using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    public string EnemyName => _enemyData.enemyName;
    public int MaxHp => _enemyData.maxHp;
    public int AtkDmg => _enemyData.atkDmg;
    public int AtkSpeed => _enemyData.atkSpeed;
    public float ChaseDist => _enemyData.chaseDist;

    public int CurrentHp { get; private set; }

    private PlayerController _playerController;

    // 애니메이션
    public Action onHitChanged;
    public Action onDeadChanged;

    private void Awake()
    {
        _playerController = GameObject.FindWithTag("PLAYER").GetComponent<PlayerController>();
        CurrentHp = _enemyData.maxHp;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("HAMMER"))
        {
            CurrentHp -= _playerController.AttackDamage;

            if (CurrentHp <= 0)
            {

                onDeadChanged?.Invoke();
                Destroy(gameObject, 0.3f);
            }
            else
            {
                onHitChanged?.Invoke();
            }
        }
    }
}




