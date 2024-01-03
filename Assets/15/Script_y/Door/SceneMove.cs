using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    [SerializeField] private GameObject EImage;

    [SerializeField] private string SceneName;
    private void Update()
    {
        if (EImage.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(GameManager.Instance.FadeOut());
            StartCoroutine(DelayRotine());
           
           
        }

    }



    IEnumerator DelayRotine()
    {
        yield return new WaitForSeconds(5f);
        GameManager.Instance.SceneMovement(SceneName);
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
