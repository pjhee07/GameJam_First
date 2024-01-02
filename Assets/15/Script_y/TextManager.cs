using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextCanvas;

    [SerializeField] private TextSO textso;
   
    int num=0;

    private void Start()
    {
        StartTalking(textso.text);
    }

    public void StartTalking(string[] talk)
    {
        //textso.text = talk;
        StartCoroutine(TextRotine(talk[num]));
    }

    private void NextTalk()
    {
        TextCanvas.text = null;

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
    }

    IEnumerator TextRotine(string Story)
    {
        TextCanvas.text = null;

        for(int i=0; i<Story.Length;i++)
        {
            TextCanvas.text = TextCanvas.text + Story[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);
        NextTalk();
    }
}
