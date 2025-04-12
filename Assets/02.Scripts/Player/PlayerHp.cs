using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    EnemyMove enemyMove;

    [Header("Flash")]
    [SerializeField] Material whiteFlashMat;
    [SerializeField] float flashTime = 0.5f;

    SpriteRenderer spriteRenderer;
    Material defaultMat;

    [SerializeField] GameObject ReTryPanel;
    [SerializeField] GameObject Canvas;



    [SerializeField] Image currentHpBar;

    bool HpFlage;

    private void Awake()
    {
        enemyMove = GameObject.FindWithTag("ENEMY").GetComponent<EnemyMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = spriteRenderer.material;
        HpFlage = false;
    }

    public void ChangeMaterials()
    {
        spriteRenderer.material = whiteFlashMat;
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        yield return new WaitForSeconds(flashTime);
        spriteRenderer.material = defaultMat;
    }
    private void Start()
    {
        maxHp = 5;
        currentHp = maxHp;
        HpRenewal();
    }
    //데미지 받을 때 currentBar업데이트
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            HpFlage = true;
            
        }
        if(HpFlage==true)
        {
            currentHp = 500;
            
        }
        else
        {
            maxHp = 5;
        }

        if(currentHp<=0)
        {
            Die();
        }
    }
    public void HpRenewal()
    {
        currentHpBar.fillAmount = (float)currentHp / (float)maxHp;
    }

    public void TakeDamage(int damage)
    {
        if (currentHp > 0)
        {
            currentHp -= damage;
           // SoundManager.Instance.PlaySound(SoundManager.Sound.Hit);
            ChangeMaterials();
            HpRenewal();
        }
        else
        {
            Die();
        }
    }

    public void Die()
    {
        
        ReTryPanel.SetActive(true);
        SoundManager.Instance.PlaySound(SoundManager.Sound.Die);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DEADZONE"))
        {
            Die();
        }
    }



}