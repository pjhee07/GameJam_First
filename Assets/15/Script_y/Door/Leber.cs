using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leber : MonoBehaviour
{
    [SerializeField] private GameObject EImage;
   
    Door door;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        door = GetComponentInChildren<Door>();
        
    }
    private void Update()
    {
        if(EImage.activeSelf&&Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("On");
            door.enabled = true;
           
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            
            EImage.SetActive(true);
        }
    }
}
