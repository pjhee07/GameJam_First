using UnityEngine;
using System;

public class EnemyMove : MonoBehaviour
{

    private Rigidbody2D _rb2d;
    private SpriteRenderer _spriteRenderer;
    private Transform _tr;

    public int _nextMove;
    [SerializeField] float _attackDist = 0.5f;
    public Action OnEnemyAtkChanged;
    public Action<int> onEnemyMoveChanged;

    private Vector2 _frontVec; // 낭떠러지 감지 하는 용도

    private Enemy _enemy;
    private GameObject _player;
    private PlayerHealth _playerHealth;
    private PlayerController _playerController;

    float _currentTime;

    private void Facing()
    {
        if (_nextMove != 0)
            _spriteRenderer.flipX = _nextMove < 0;
        else
        {
            // 정지 상태에서도 방향 유지: 플레이어 기준
            float dir = _player.transform.position.x - transform.position.x;
            _spriteRenderer.flipX = dir < 0;
        }
    }

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _tr = GetComponent<Transform>();
        _enemy = GetComponent<Enemy>();

        _player = GameObject.FindWithTag("PLAYER");
        _playerHealth = _player.GetComponent<PlayerHealth>();
        _playerController = _player.GetComponent<PlayerController>();

        Invoke("Think", 3);
    }

    private void Update()
    {
        Facing();
        ChasePlayer();
        Attack();
        _currentTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = new Vector2(_nextMove, _rb2d.velocity.y);

        _frontVec = new Vector2(_rb2d.position.x + _nextMove * 1f, _rb2d.position.y);
        Debug.DrawRay(_frontVec, Vector3.down, Color.green);
        RaycastHit2D rayHit = Physics2D.Raycast(_frontVec, Vector3.down, 1, LayerMask.GetMask("TILEMAP"));

        if (rayHit.collider == null)
        {
            _nextMove *= -1; // 방향 전환
            CancelInvoke();
            Invoke("Think", 3);
        }
    }

    private void Think()
    {
        _nextMove = UnityEngine.Random.Range(-1, 2); // -1 ~ 1
        float nextThinkTime = UnityEngine.Random.Range(2f, 5f); // 2 ~ 5초
        Invoke("Think", nextThinkTime);
        onEnemyMoveChanged?.Invoke(_nextMove);
    }

  
    private void ChasePlayer()
    {
        // 플레이어 감지
        RaycastHit2D detectPlayer = Physics2D.Raycast(_frontVec, new Vector2(_nextMove, 0), _enemy.ChaseDist, LayerMask.GetMask("PLAYER"));
        if (detectPlayer.collider != null)
        {
            Vector2 dir = _player.transform.position - transform.position;
            _nextMove = Math.Sign(dir.x); // 방향 계산
        }
    }

    private void Attack()
    {

        if (_currentTime < _enemy.AtkSpeed)
            return;
        float xDist = Mathf.Abs(_player.transform.position.x - transform.position.x);
        Debug.Log(xDist);
        if (xDist <= _attackDist)
        {
            Debug.Log("공격");

            _nextMove = 0;
            OnEnemyAtkChanged?.Invoke();
            _playerHealth.TakeDamage(_enemy.AtkDmg);
            _currentTime = 0;
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (_player == null)
            return;

        Gizmos.color = Color.red;

        // 적의 현재 위치에서 공격 거리만큼 양쪽에 원 그리기
        Vector3 leftPoint = transform.position + Vector3.left * _attackDist;
        Vector3 rightPoint = transform.position + Vector3.right * _attackDist;

        Gizmos.DrawWireSphere(leftPoint, 0.1f);  // 왼쪽 범위 표시
        Gizmos.DrawWireSphere(rightPoint, 0.1f); // 오른쪽 범위 표시


    }


}
