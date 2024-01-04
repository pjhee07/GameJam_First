using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestComplete : MonoBehaviour
{
    [SerializeField] private GameObject TextCanvas;
    [SerializeField] private TextMeshProUGUI Texts;

   
    [SerializeField] private TextSO textso;
    [SerializeField] private float NextTextTime;

    int num = 0;


    BoxCollider2D box;
    [SerializeField] private GameObject Laber;

  
    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        
        TextCanvas.SetActive(false);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PLAYER"))
        {
            if (GameManager.Flage == true)
            {
                Laber.SetActive(true);
                box.enabled = false;
                TextCanvas.SetActive(true);
                StartTalking(textso.text);
                gameObject.SetActive(false);
            }
        }


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
        if (num == textso.text.Length)
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
    }

    IEnumerator TextRotine(string Story)
    {
        Texts.text = null;

        for (int i = 0; i < Story.Length; i++)
        {
            Texts.text = Texts.text + Story[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(NextTextTime);
        NextTalk();
    }
}
