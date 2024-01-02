using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer lineRenderer;
    public GameObject player;
   
    private void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
       
        lineRenderer.positionCount = 2;
        LineRendering();
    }

    private void LineRendering()
    {
       
        lineRenderer.SetPosition(0, transform.position);

        lineRenderer.SetPosition(1, player.transform.position);
        Debug.Log("draw");
    }
}
