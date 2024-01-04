using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{

    [SerializeField] private Image FadeImage;

   
    [SerializeField] private CutSceneManager textManager;

    [SerializeField] private Sprite[] sprite;
    SpriteRenderer spriteRenderer;
    [SerializeField] private string NextScene;
    [SerializeField] private AudioSource BGM;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(FadeOut());
    }


    public IEnumerator FadeOut()
    {
        FadeImage.enabled = true;
        float current = 1;
        while (current >0)
        {
            current -= Time.deltaTime;
            FadeImage.color = new Color(1, 1, 1, current);
            yield return new WaitForSeconds(0.01f);
        }
       // FadeImage.enabled = false;
       
        textManager.enabled = true;
        StartCoroutine(ChangeSpriteRotine());
        StartCoroutine(BlackOut());
    }

    

    
  

    IEnumerator ChangeSpriteRotine()
    {
        SoundManager.Instance.PlaySound(SoundManager.Sound.Breaking);
        yield return new WaitForSeconds(3.5f);
        spriteRenderer.sprite = sprite[0];
        yield return new WaitForSeconds(3.5f);
        spriteRenderer.sprite = sprite[1];
        yield return new WaitForSeconds(5.5f);
        spriteRenderer.sprite = sprite[2];
        yield return new WaitForSeconds(3f);
        
        Debug.Log("Á¾·á");
    }

    IEnumerator BlackOut()
    {

        yield return new WaitForSeconds(15f);
        BGM.Stop();
        SoundManager.Instance.PlaySound(SoundManager.Sound.Knock);
        FadeImage.color = new Color(0, 0, 0, 1);

        yield return new WaitForSeconds(2f);
        GameManager.Instance.SceneMovement(NextScene);
    }
}
