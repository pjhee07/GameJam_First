using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow  : MonoBehaviour
{
    GameObject Player;
    CinemachineStateDrivenCamera drivenCamera;
    
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (Player = null)
        {
            drivenCamera.Follow = null;
        }
    }
}

