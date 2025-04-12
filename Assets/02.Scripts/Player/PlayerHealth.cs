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
            // TODO: Handle player death
        }
    }

    private void UpdateHpUI()
    {
        for (int i = 0; i < _hpImages.Length; i++)
        {
            _hpImages[i].enabled = i < _currentHp;
        }
    }
}
