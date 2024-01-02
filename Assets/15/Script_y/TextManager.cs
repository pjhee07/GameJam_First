using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextCanvas;

    [SerializeField] private string[] Textdiaglue;

    [SerializeField] private string[] diagule;

    int num;


    private void Start()
    {
        StartTalking(Textdiaglue);
    }
    private void StartTalking(string[] talk)
    {
        diagule = talk;
        StartCoroutine(TextRotine(diagule[num]));
    }

    private void NextTalk()
    {
        TextCanvas.text = null;

        num++;
        if(num==diagule.Length)
        {
            EndTalking();
            return;
        }

        StartCoroutine(TextRotine(diagule[num]));
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
            TextCanvas.text += Story[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);
        NextTalk();
    }
}
