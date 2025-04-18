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

    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeSceneBtn(string sceneName)
    {
        GameManager.Instance.ChangeScene(sceneName);
    }

}
