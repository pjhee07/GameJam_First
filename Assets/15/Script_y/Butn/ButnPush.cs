using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButnPush : MonoBehaviour
{
    Animator anim;
    BoxCollider2D box;
    private void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Object"))
        {
            box.enabled = false;
            anim.SetTrigger("Push");
            GameManager.Instance.PusCountSet();
        }
    }
}
