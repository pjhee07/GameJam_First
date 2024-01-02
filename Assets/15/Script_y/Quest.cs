using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject Laber;

    private void Start()
    {
        Laber.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Flage==true)
        {
            Laber.SetActive(true);
        }
    }
}
