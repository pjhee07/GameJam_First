using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private GameObject TextCanvas;
    [SerializeField] private TextMeshProUGUI Texts;

    [SerializeField] private GameObject EImage;
    [SerializeField] private TextSO textso;
   
    int num=0;

    private void Start()
    {
        EImage.SetActive(false);
        TextCanvas.SetActive(false);
    }

    private void Update()
    {
        if (EImage.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            TextCanvas.SetActive(true);
            StartTalking(textso.text);
            Debug.Log("Ω√¿€");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EImage.SetActive(true);
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EImage.SetActive(false);
        TextCanvas.SetActive(false);
    }

    public void StartTalking(string[] talk)
    {
        //textso.text = talk;
        StartCoroutine(TextRotine(talk[num]));
    }

    private void NextTalk()
    {
        Texts.text = null;

        num++;
        if(num==textso.text.Length)
        {
            EndTalking();
            return;
        }

        StartCoroutine(TextRotine(textso.text[num]));
    }

    private void EndTalking()
    {
        num = 0;
        TextCanvas.SetActive(false);
    }

    IEnumerator TextRotine(string Story)
    {
        Texts.text = null;

        for(int i=0; i<Story.Length;i++)
        {
            Texts.text = Texts.text + Story[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);
        NextTalk();
    }
}
