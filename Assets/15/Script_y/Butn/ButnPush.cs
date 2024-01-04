using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButnPush : MonoBehaviour
{
    Animator anim;
    BoxCollider2D box;
    [SerializeField] private GameObject brigde;
    private void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Object"))
        {
            anim.SetTrigger("Push");
            GameManager.Instance.PusCountSet();
            box.enabled = false;
           if(GameManager.Instance.PushFlage==true)
            {
                brigde.SetActive(true);
                //SoundManager.Instance.PlaySound(SoundManager.Sound.Brigde);
            }
        }
    }
}
