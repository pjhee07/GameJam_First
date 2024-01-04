using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButnPush : MonoBehaviour
{
    Animator anim;
    BoxCollider2D box;
    [SerializeField] private GameObject brigde;
    Brigde brigde2;
    private void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        brigde2 = GetComponentInParent<Brigde>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Object"))
        {
            anim.SetTrigger("Push");
            brigde2.PusCountSet();
            box.enabled = false;
            if (brigde2.PushFlage == true)
            {
                brigde.SetActive(true);
                SoundManager.Instance.PlaySound(SoundManager.Sound.Brigde);
            }
        }
    }
}
