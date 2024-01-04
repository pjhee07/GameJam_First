using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : Singleton<GameManager>
{
    public bool Movement = false;
    public bool PushFlage = false;
    public static int ItemCount = 0;
    public static bool Flage;
    public int PushCount = 0;
    public bool textflage = false;


    [SerializeField] private Image FadeImage;
    
    [SerializeField] private int PushUpBtnCount;
    
    public void ItemCountSet()
    {
        ItemCount++;
        Debug.Log(ItemCount);
        if(ItemCount>=3)
        {
            Flage = true;
            Debug.Log("¿Ï·á");
        }
    }

    public void SceneMovement(string name)
    {        
        SceneManager.LoadScene(name);
        Debug.Log(name);
    }

    public void PusCountSet()
    {
        PushCount++;
        Debug.Log(PushCount);
        if (PushCount >= PushUpBtnCount)
        {
            PushFlage = true;
        }
    }


    public  IEnumerator FadeOut()
    {
        FadeImage.enabled = true;
        float current = 0;
        while(current<1)
        {
            current += 0.2f;
            FadeImage.color = new Color(0, 0, 0, current);
            yield return new WaitForSeconds(0.01f);
        }
    }

   
}
