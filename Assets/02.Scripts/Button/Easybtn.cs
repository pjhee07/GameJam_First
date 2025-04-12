using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easybtn : MonoBehaviour
{
    [SerializeField] GameObject TurnLight;
    public void EasyBtn()
    {
        TurnLight.SetActive(true);
    }
}
