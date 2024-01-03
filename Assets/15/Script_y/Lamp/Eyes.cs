using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Eyes : MonoBehaviour
{

    GameObject Player;
    PlayerCtrl playerCtrl;

    private void Awake()
    {
        Player = GameObject.FindWithTag("PLAYER");
        playerCtrl = Player.GetComponent<PlayerCtrl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PLAYER") && GameManager.Instance.Movement == true)
        {
            Debug.Log("ddddddddddd");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PLAYER") && GameManager.Instance.Movement == true)
        {
            Debug.Log("asfsadfdasf");
        }
    }

    void Judement() 
    {
        //if(PlayerCtrl.)
    }




}
