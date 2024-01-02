using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] private Light lamplight;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }




    IEnumerator ColorFadeDown()
    {
        float currcolor = 1;
        while (currcolor > 0)
        {
            currcolor -= 0.02f;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, currcolor);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }
}
