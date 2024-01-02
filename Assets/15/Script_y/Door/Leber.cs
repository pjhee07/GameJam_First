using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leber : MonoBehaviour
{
    [SerializeField] private GameObject EImage;
    public GameObject dor2;
    private bool DoorFlage = false;
    Door door;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        door = GetComponentInChildren<Door>();
        
    }
    private void Update()
    {
        if(DoorFlage==true&&Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("On");
            //door.enabled = true;
            dor2.GetComponent<Door>().enabled = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            DoorFlage = true;
            EImage.SetActive(true);
        }
    }
}
