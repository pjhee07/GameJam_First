using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Eyes : MonoBehaviour
{

    GameObject Player;
    PlayerHp playerHp;

    private void Awake()
    {
        Player = GameObject.FindWithTag("PLAYER");
        playerHp = Player?.GetComponent<PlayerHp>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PLAYER") && GameManager.Instance.Movement == true)
        {
            StartCoroutine(WaitRoutine());
            playerHp.TakeDamage(5);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PLAYER") && GameManager.Instance.Movement == true)
        {
            StartCoroutine(WaitRoutine());
            playerHp.TakeDamage(5);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PLAYER") && GameManager.Instance.Movement == true)
        {
            StartCoroutine(WaitRoutine());
            playerHp.TakeDamage(5);
        }
        
    }

    IEnumerator WaitRoutine()
    {
        yield return new WaitForSeconds(1f);
    }




}
