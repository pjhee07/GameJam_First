using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    
    public Image currentHpBar;

    private void Start()
    {
        maxHp = 5;
        currentHp = maxHp;
    }

    private void Update()
    {
      //currentHpBar.fillAmount = (float)currentHp / (float)maxHp; //전체체력 분의 현재체력
        
    }



}
