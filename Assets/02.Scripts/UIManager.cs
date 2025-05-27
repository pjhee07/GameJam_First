using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIManager : Singleton<UIManager>   
{
    private GameObject retryPanel;


    public void ShowRetryPanel()
    {
        if(retryPanel != null)
            retryPanel.SetActive(true);
        else
        {
            retryPanel = GameObject.Find("UICanvas").transform.Find("RetryPanel").gameObject;
            Button retryButton = retryPanel.GetComponentInChildren<Button>();
            retryButton.onClick.RemoveAllListeners();
            retryButton.onClick.AddListener(RetryBtn);
            retryPanel.SetActive(true);
        }
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeSceneBtn(string sceneName)
    {
        GameManager.Instance.ChangeScene(sceneName);
    }
    
}
