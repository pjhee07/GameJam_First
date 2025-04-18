using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutSceneManager : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI Texts;

    
    [SerializeField] private TextSO textso;
    [SerializeField] private float NextTextTime;

    

    int num = 0;

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
        Texts.text = null;

        num++;
        Debug.Log(num);
        
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
