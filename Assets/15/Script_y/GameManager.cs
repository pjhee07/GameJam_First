using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool Movement = false;
    public static int ItemCount = 0;
    public static bool Flage;

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
    }
}
