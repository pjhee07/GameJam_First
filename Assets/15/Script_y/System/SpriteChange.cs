using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    [SerializeField] private string NextScene;

    [SerializeField] private Sprite[] sprite;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeSpriteRotine());
    }

    IEnumerator ChangeSpriteRotine()
    {

        yield return new WaitForSeconds(4f);
        spriteRenderer.sprite = sprite[0];
        yield return new WaitForSeconds(3f);
        spriteRenderer.sprite = sprite[1];
        yield return new WaitForSeconds(4.5f);
        spriteRenderer.sprite = sprite[2];
        yield return new WaitForSeconds(2f);
        GameManager.Instance.SceneMovement(NextScene);

        
    }
}
