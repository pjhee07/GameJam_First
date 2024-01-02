using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public int maxHp;
    public int currentHp;

    [SerializeField] Image currentHpBar;

    private void Start()
    {
        maxHp = 5;
        currentHp = maxHp;
        //currentHpBar.fillAmount = (float)currentHp / (float)maxHp;
    }

    void TakeDamage(int damageAmount)
    {

    }
}