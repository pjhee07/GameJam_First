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

    public bool IsAttacked { get; private set; }

    private float _dashDuration = 0.5f;
    private float _attackCooldown = 1f;
    private float _currentTime;
    private float _horizontal;
    private float _defaultSpeed = 3f;
    private float _dashSpeed = 7f;
    private float _direction;

    private Rigidbody2D _rigidbody;
    private Camera _mainCamera;
    private SpriteRenderer _spriteRenderer;
    private TrailRenderer _trailRenderer;

    private PlayerHealth _playerHealth;
    private GameObject _hammerCollider;

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
        _mainCamera = Camera.main;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
        _playerHealth = GetComponent<PlayerHealth>();
        _hammerCollider = transform.GetChild(1).gameObject;
    }

    private void Start()
    {
        _moveSpeed = _defaultSpeed;
        _isJumping = false;
        _isDashing = false;
    }

    private void Update()
    {
        HandleFacing();
        HandleAttack();
        HandleDash();
        HandleJump();
        HandleTalk();

        _currentTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        HandleRun();
        UpdateMovementState();
    }

    private void HandleRun()
    {
        if (GameManager.Instance.textflage) return;

        _horizontal = Input.GetAxisRaw("Horizontal");
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
        //SoundManager.Instance.PlaySound(SoundManager.Sound.Dash);
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
        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
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

        bool isMouseDown = Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();
        bool isTouchDown = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began &&
                           !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);

        if (isMouseDown || isTouchDown)
        {
            _currentTime = 0f;
            OnAttackChanged?.Invoke();
        }
    }

    private void HandleTalk()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 대화 기능 추후 구현
        }
    }


    public void SetAttacked(bool value)
    {
        IsAttacked = value;
    }
}
