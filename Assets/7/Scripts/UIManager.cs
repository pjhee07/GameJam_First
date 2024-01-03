using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private string ReSceneName;

    public void Startgame()
    {
        StartCoroutine(GameManager.Instance.FadeOut());
        SceneManager.LoadScene("1_lobe");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Bye!");
    }


    public void ReturnBtn()
    {
        GameManager.Instance.SceneMovement(ReSceneName);
    }

    public void MainBtn()
    {
        GameManager.Instance.SceneMovement("Start");
    }
}
