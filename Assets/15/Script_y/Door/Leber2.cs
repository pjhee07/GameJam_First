using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leber2 : MonoBehaviour
{
    [SerializeField] private GameObject EImage;
    public GameObject dor2;
    
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
       

    }
    private void Update()
    {
        if (EImage.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("On");
          
            dor2.GetComponent<Door>().enabled = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            EImage.SetActive(true);
        }
    }
}
