using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    EnemyMove enemyMove;

    [SerializeField] Image currentHpBar;

    private void Awake()
    {
        enemyMove = GameObject.FindWithTag("ENEMY").GetComponent<EnemyMove>();
    }
    private void Start()
    {
        maxHp = 5;
        currentHp = maxHp;
        HpRenewal();
        enemyMove.onHpBarValueChanged += HpRenewal;
    }

    private void OnDestroy()
    {
        enemyMove.onHpBarValueChanged -= HpRenewal;
    }
    //데미지 받을 때 currentBar업데이트
    public void HpRenewal()
    {
        currentHpBar.fillAmount = (float)currentHp / (float)maxHp;
    }

    public void TakeDamage(int damage)
    {
        
        currentHp -= damage;
    }

}