using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _currentHp = 3f;
    [SerializeField] private float _maxHp = 3f;
    [SerializeField] private Image[] _hpImages;

    private PlayerController _playerController;

    public bool IsDebugInvincible { get; set; } = false;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (IsDebugInvincible && Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage)
    {
        if (IsDebugInvincible || _currentHp <= 0f) return;

        _playerController.SetAttacked(true);
        _currentHp -= damage;
        _currentHp = Mathf.Max(_currentHp, 0f);

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
