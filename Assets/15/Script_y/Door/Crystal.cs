using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Crystal : MonoBehaviour
{
    [SerializeField] private GameObject EImage;
    [SerializeField] private Image FadePanel;
    [SerializeField] private string SceneName;

    private void Start()
    {
        FadePanel.enabled = false;
    }
    private void Update()
    {
        if (EImage.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.Glass);
            StartCoroutine(FadeWhite());
        }

    }

    IEnumerator FadeWhite()
    {
        FadePanel.enabled = true;
        float curretim = 0;
        while(curretim<1)
        {
            curretim += Time.deltaTime;

            FadePanel.color = new Color(1, 1, 1, curretim);

            yield return new WaitForSeconds(0.01f);
        }
        GameManager.Instance.SceneMovement(SceneName);
    }

    



    private void OnTriggerEnter2D(Collider2D collision)
    {
        EImage.SetActive(true);
    }

   
}
