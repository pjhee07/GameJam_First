using System;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isJumping;
    [SerializeField] private bool _isDashing;
    [SerializeField] private float _dashCooldown = 1f;

    public int AttackDamage { get; private set; } = 1;

    private float _dashDuration = 0.5f;
    private float _attackCooldown = 1f;
    private float _currentTime;
    private float _horizontal;
    private float _defaultSpeed = 3f;
    private float _dashSpeed = 7f;
    private float _direction;

    private bool _isAttacked;
    private float _attackedTime;
    [SerializeField] private float _attackedDuration = 0.3f; // 넉백 유지 시

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private TrailRenderer _trailRenderer;

    private PlayerHealth _playerHealth;
    private GameObject _hammerCollider;
    private BoxCollider2D _hammerBoxCollider;


    public Action<float> OnRunChanged;
    public Action<bool> OnJumpChanged;
    public Action OnAttackChanged;
    public Action OnDashChanged;
    public bool IsMove { get; private set; } 

    private void UpdateMovementState()
    {
        bool isMoving = _rigidbody.velocity.x != 0;
        GameManager.Instance.Movement = isMoving;
        IsMove = isMoving; 
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
        _playerHealth = GetComponent<PlayerHealth>();
        _hammerCollider = transform.GetChild(1).gameObject;
        _hammerBoxCollider = _hammerCollider.GetComponent<BoxCollider2D>();

    }

    private void Start()
    {
        _moveSpeed = _defaultSpeed;
        _isJumping = false;
        _isDashing = false;
        _hammerBoxCollider.enabled = false;
    }

    private void Update()
    {
        HandleFacing();
        HandleAttack();
        HandleDash();
        HandleJump();

        _currentTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (_isAttacked && Time.time - _attackedTime < _attackedDuration)
        {
            // 공격받은 상태, 이동 막기
            UpdateMovementState();
            return;
        }

        _isAttacked = false; // 넉백 지속시간 지나면 다시 이동 가능
        HandleRun();
        UpdateMovementState();
    }


    private void HandleRun()
    {
        if (GameManager.Instance.textflage) return;

        _horizontal = Input.GetAxisRaw("Horizontal"); // 0 이 아니면 움직이는거
        _rigidbody.velocity = new Vector2(_horizontal * _moveSpeed, _rigidbody.velocity.y);
        OnRunChanged?.Invoke(_horizontal * _moveSpeed);
    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !_isDashing)
        {
            StartCoroutine(DashRoutine());
        }
    }

    private IEnumerator DashRoutine()
    {
        _isDashing = true;
        SoundManager.Instance.PlaySFX(SoundManager.Sound.Dash);
        _moveSpeed = _dashSpeed;
        _trailRenderer.emitting = true;

        yield return new WaitForSeconds(_dashDuration);
        _trailRenderer.emitting = false;
        _moveSpeed = _defaultSpeed;

        yield return new WaitForSeconds(_dashCooldown);
        _isDashing = false;
    }

    private void HandleFacing()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _direction = transform.position.x - mousePosition.x;

        bool isFacingLeft = _direction > 0;
        _spriteRenderer.flipX = isFacingLeft;
        _hammerCollider.transform.rotation = Quaternion.Euler(0, isFacingLeft ? 180 : 0, 0);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameManager.Instance.textflage && !_isJumping)
        {
            _isJumping = true;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            OnJumpChanged?.Invoke(_isJumping);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MAP"))
        {
            _isJumping = false;
            OnJumpChanged?.Invoke(_isJumping);
        }
    }

    private void HandleAttack()
    {
        if (_currentTime < _attackCooldown) return;

        bool isMouseDown = Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject(); // UI위에 있지 않을때
        //bool isTouchDown = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began &&
        //                   !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);

        if (isMouseDown)
        {
            _currentTime = 0f;

            // 공격할 때만 충돌체 켜고, 잠깐 후 꺼지게
            StartCoroutine(EnableHammerColliderForSeconds(0.2f));
            OnAttackChanged?.Invoke();

        }
    }

    private IEnumerator EnableHammerColliderForSeconds(float duration)
    {
        _hammerBoxCollider.enabled = true;
        yield return new WaitForSeconds(duration);
        _hammerBoxCollider.enabled = false;
    }

    public void SetAttacked(bool value)
    {
        _isAttacked = value;
        if(value)
        {
            _attackedTime = Time.time;
        }
    }

}
