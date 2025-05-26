using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPush : MonoBehaviour
{
    Animator anim;
    BoxCollider2D box;
    [SerializeField] private GameObject bridge;
    Bridge bridge2;
    private void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        bridge2 = GetComponentInParent<Bridge>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Object"))
        {
            anim.SetTrigger("Push");
            bridge2.PusCountSet();
            box.enabled = false;
            if (bridge2.PushFlage == true)
            {
                bridge.SetActive(true);
                SoundManager.Instance.PlaySFX(SoundManager.Sound.Bridge);
            }
        }
    }
}
