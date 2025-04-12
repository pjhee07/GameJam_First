using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _timeColor;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }
   
    IEnumerator FadeOut()
    {
        float currentAlpha = 1;
        while(currentAlpha >= 0)
        {
            currentAlpha -= 0.02f ;
            _spriteRenderer.color = new Color(1, 1, 1, currentAlpha);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.SetActive(false);
       SoundManager.Instance.PlaySound(SoundManager.Sound.Door);
    }
}
