using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject Laber;

    BoxCollider2D box;

   
    private void Start()
    {
        Laber.SetActive(false);
        box = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Flage==true)
        {
            Laber.SetActive(true);
            box.enabled = false;
        }
    }
}
