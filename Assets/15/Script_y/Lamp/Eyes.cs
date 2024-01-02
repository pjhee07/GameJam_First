using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Eyes : MonoBehaviour
{

    [SerializeField] private GameObject eye;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.Instance.Movement == true)
        {
            Debug.Log("ddddddddddd");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.Instance.Movement == true)
        {
            Debug.Log("asfsadfdasf");
        }
    }




}
