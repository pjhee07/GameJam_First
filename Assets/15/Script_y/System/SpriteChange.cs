using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    [SerializeField] private string NextScene;
    [SerializeField] private Image FadeImage;
    [SerializeField] private Sprite[] sprite;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        FadeImage.enabled = false;
        StartCoroutine(ChangeSpriteRotine());
        
    }

    IEnumerator ChangeSpriteRotine()
    {
        yield return new WaitForSeconds(4.5f);
        spriteRenderer.sprite = sprite[0];
        yield return new WaitForSeconds(3f);
        spriteRenderer.sprite = sprite[1];
        yield return new WaitForSeconds(4.5f);
        spriteRenderer.sprite = sprite[2];
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeRotine());
        Debug.Log("Á¾·á");        
    }

    IEnumerator FadeRotine()
    {
        FadeImage.enabled = true;
        float currentime = 0;
        while(currentime<1)
        {
            currentime += Time.deltaTime;
            FadeImage.color = new Color(1, 1, 1, currentime);
            yield return new WaitForSeconds(0.01f);
        }
        GameManager.Instance.ChangeScene(NextScene);
    }
}
