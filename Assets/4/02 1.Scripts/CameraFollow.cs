using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow  : MonoBehaviour
{
    GameObject Player;
    CinemachineVirtualCamera drivenCamera;
    private void Awake()
    {
        drivenCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Start()
    {
        Player = GameObject.FindWithTag("PLAYER");
    }
    void Update()
    {        if (Player == null)
        {
            drivenCamera.enabled = false;
        }

    }
}

