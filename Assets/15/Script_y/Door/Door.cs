using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    float timecolor;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ColorDown());
    }
   
    IEnumerator ColorDown()
    {
        float currcolor = 1;
        while(currcolor>0)
        {
            currcolor -= 0.02f ;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, currcolor);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }
}
