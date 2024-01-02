using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{

    int speed = 4;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(x, 0,0) * speed * Time.deltaTime;
    }
}
