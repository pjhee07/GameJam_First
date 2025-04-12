using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject RetryPanel;
    public void QuitGame()
    {
        Application.Quit();
    }


    public void ChangeSceneBtn(string sceneName)
    {
        //RetryPanel.SetActive(false);
        GameManager.Instance.ChangeScene(sceneName);
    }

}
