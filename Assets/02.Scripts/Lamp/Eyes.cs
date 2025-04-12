using System.Collections;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    [SerializeField] private int _damage = 5;
    [SerializeField] private float _damageCooldown = 1f;

    private bool _canDamage = true;

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("PLAYER");
        _playerHealth = player?.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryDamagePlayer(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TryDamagePlayer(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TryDamagePlayer(collision);
    }

    private void TryDamagePlayer(Collider2D collider)
    {
        if (!_canDamage) return;

        if (collider.CompareTag("PLAYER") && GameManager.Instance.Movement)
        {
            _playerHealth?.TakeDamage(_damage);
            StartCoroutine(DamageCooldown());
        }
    }

    private IEnumerator DamageCooldown()
    {
        _canDamage = false;
        yield return new WaitForSeconds(_damageCooldown);
        _canDamage = true;
    }
}
