using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{

    int speed = 4;
    public static bool Movement = false;

   

    
    
    void Update()
    {
       

        float x = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(x, 0,0) * speed * Time.deltaTime;

        
        if(x==0)
        {
            Movement = true;
        }
    }
}
