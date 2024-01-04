using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brigde : MonoBehaviour
{
    
    public bool PushFlage = false;
    [SerializeField] private int PushUpBtnCount=0;
    public int PushCount = 0;
   
   

    public void PusCountSet()
    {
        PushCount++;
        Debug.Log("puset" + PushUpBtnCount);
        Debug.Log(PushCount);
        if (PushCount >= PushUpBtnCount)
        {
            PushFlage = true;
        }
    }
}
