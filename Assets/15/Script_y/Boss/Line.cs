using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer lineRenderer;
    

    [SerializeField] private GameObject Target;
    Vector3 currentPos;
    Vector3 mypos;
    Vector3 dir;
    public Vector3 dis;
   
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        LineRendering();
    }
   
    

    private void LineRendering()
    {
       
        lineRenderer.SetPosition(0, transform.position);

        lineRenderer.SetPosition(1, Target.transform.position);
        Debug.Log("draw");
    }
}
