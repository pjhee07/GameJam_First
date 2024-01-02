using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leber : MonoBehaviour
{
    [SerializeField] private GameObject EImage;
    private bool DoorFlage = false;
    Door door;

    private void Start()
    {
        door = GetComponentInChildren<Door>();
    }
    private void Update()
    {
        if(DoorFlage==true&&Input.GetKeyDown(KeyCode.E))
        {
            door.enabled = true;
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
