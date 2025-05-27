using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    //무적 시간이랑, hit 애니메이션 설정하기
     private float _currentHp;
    private float knockbackForce = 3f;
    [SerializeField] private float _maxHp = 5f;
    [SerializeField] private Image[] _hpImages;

    private PlayerController _playerController;
    public Action OnHitChanged;

    public bool IsDebugInvincible { get; set; } = false;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _rb2d = GetComponent<Rigidbody2D>();    
    }

    private void OnEnable()
    {
        _currentHp = _maxHp;
    }


    public void TakeDamage(float damage, int direction)
    {
        if (IsDebugInvincible || _currentHp <= 0f) return;

        Debug.Log("플레이어 공격당함");

        _currentHp -= damage;
        _currentHp = Mathf.Max(_currentHp, 0f);

        OnHitChanged?.Invoke();
        _rb2d.AddForce(Vector2.right * direction * knockbackForce, ForceMode2D.Impulse);

        _playerController.SetAttacked(true);

        UpdateHpUI();

        if (_currentHp <= 0f)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DEADZONE"))
            Die();
    }

    private void Die()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Sound.Die);
        UIManager.Instance.ShowRetryPanel();
        Destroy(gameObject);
    }

    private void UpdateHpUI()
    {
        for (int i = 0; i < _hpImages.Length; i++)
        {
            _hpImages[i].enabled = i < _currentHp;
        }
    }
}
