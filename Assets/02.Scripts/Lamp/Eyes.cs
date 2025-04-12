using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Eyes : MonoBehaviour
{

    GameObject Player;
    PlayerHealth _playerHealth;

    private void Awake()
    {
        Player = GameObject.FindWithTag("PLAYER");
        _playerHealth = Player?.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PLAYER") && GameManager.Instance.Movement == true)
        {
            StartCoroutine(WaitRoutine());
            _playerHealth.TakeDamage(5);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PLAYER") && GameManager.Instance.Movement == true)
        {
            StartCoroutine(WaitRoutine());
            _playerHealth.TakeDamage(5);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PLAYER") && GameManager.Instance.Movement == true)
        {
            StartCoroutine(WaitRoutine());
            _playerHealth.TakeDamage(5);
        }
        
    }

    IEnumerator WaitRoutine()
    {
        yield return new WaitForSeconds(1f);
    }




}
