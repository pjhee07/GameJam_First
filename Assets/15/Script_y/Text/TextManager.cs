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
    [SerializeField] private float NextTextTime;
    
   
    int num=0;


    BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        EImage.SetActive(false);
        TextCanvas.SetActive(false);
    }
    private void Update()
    {
       
        if (EImage.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            box.enabled = false;
            GameManager.Instance.textflage = true;
            TextCanvas.SetActive(true);
            StartTalking(textso.text);
            Debug.Log("Ω√¿€");
        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PLAYER"))
        {
            EImage.SetActive(true);
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TextCanvas.SetActive(false);
        EImage.SetActive(false);
        EndTalking();
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
        box.enabled = true;
        GameManager.Instance.textflage = false;
    }

    IEnumerator TextRotine(string Story)
    {
        Texts.text = null;

        for(int i=0; i<Story.Length;i++)
        {
            Texts.text = Texts.text + Story[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(NextTextTime);
        NextTalk();
    }
}
