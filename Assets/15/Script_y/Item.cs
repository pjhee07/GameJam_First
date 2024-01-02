using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject EImage;


    private void Update()
    {
        if (EImage.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.ItemCountSet();
            Destroy(gameObject);
        }

    }







    private void OnTriggerEnter2D(Collider2D collision)
    {
        EImage.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EImage.SetActive(false);
    }
}
