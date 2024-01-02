using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Eyes : MonoBehaviour
{

    [SerializeField] private GameObject eye;

    private void Start()
    {
        if (GameManager.Instance.Movement==false)
        {
            Debug.Log("dsasdfs");
        
        }
        
    }

  




}
