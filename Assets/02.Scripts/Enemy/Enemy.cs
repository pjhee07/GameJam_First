using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData; // SO ÂüÁ¶

    public string EnemyName => _enemyData.enemyName;
    public int MaxHp => _enemyData.maxHp;
    public int AtkDmg => _enemyData.atkDmg;
    public int AtkSpeed => _enemyData.atkSpeed;
    public float ChaseDist => _enemyData.chaseDist;

    public int CurrentHp { get; private set; }

    private PlayerCtrl _playerCtrl;
    private CircleCollider2D _coll;

    public Action onDeadChanged;

    private void Awake()
    {
        _playerCtrl = GameObject.FindWithTag("PLAYER").GetComponent<PlayerCtrl>();
        _coll = GetComponent<CircleCollider2D>();
        CurrentHp = _enemyData.maxHp;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("HAMMER"))
        {
            if (_playerCtrl.attacked)
            {
                CurrentHp -= _playerCtrl.atkDmg;

                if (CurrentHp <= 0)
                {
                    _coll.enabled = false;
                    onDeadChanged?.Invoke();
                    Destroy(gameObject, 0.3f);
                }
            }
        }
    }
  
}
