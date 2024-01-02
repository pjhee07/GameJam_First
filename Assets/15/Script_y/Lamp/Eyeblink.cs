using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Eyeblink : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    public Light2D Light2D;
    [SerializeField] private GameObject movement;
    float currcolor;
    bool flag;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {

        StartCoroutine(routine());
    }

    IEnumerator routine()
    {
        while (true)
        {

            OpenState();
            yield return new WaitForSeconds(15f);
        }

    }



    private void CloseState()
    {
        StartCoroutine(waitingtime());
        
      
       
    }
    private void OpenState()
    {
        StartCoroutine(waitingtime2());
       
       
    }

  
    IEnumerator waitingtime()
    {
        yield return new WaitForSeconds(7f);
        StartCoroutine(ColorFadeDown());
        StartCoroutine(LightFadeDown());

    }

    IEnumerator waitingtime2()
    {
        yield return new WaitForSeconds(7f);
        movement.SetActive(true);
        StartCoroutine(ColorFadeOn());
        StartCoroutine(lightfadeon());

    }

    IEnumerator ColorFadeDown()
    {

        currcolor = 1;
        while (currcolor > 0)
        {
            currcolor -= 0.02f;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, currcolor);
            yield return new WaitForSeconds(0.01f);
        }
        movement.SetActive(false);

    }

    IEnumerator LightFadeDown()
    {
        currcolor = 1;
        while (currcolor > 0)
        {
            currcolor -= 0.02f;
            Light2D.color = new Color(Light2D.color.r, Light2D.color.g, Light2D.color.b, currcolor);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ColorFadeOn()
    {
        currcolor = 0;
        while (currcolor < 1)
        {
            currcolor += 0.02f;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, currcolor);
            yield return new WaitForSeconds(0.01f);
        }

    }

    IEnumerator lightfadeon()
    {
        currcolor = 0;
        while (currcolor < 1)
        {
            currcolor += 0.02f;
            Light2D.color = new Color(Light2D.color.r, Light2D.color.g, Light2D.color.b, currcolor);
            yield return new WaitForSeconds(0.01f);
        }


        CloseState();
    }
}
