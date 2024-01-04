using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Enemy : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject canvas;

    
    RectTransform hpBar;

    public float height = 1.7f;
    Camera mainCam;

    public string enemyName;
    public int maxHp;
    public int currentHp;
    public int atkDmg;
    public int atkSpeed; //���ݼӵ�(��Ÿ��)
    public float atkDistance;

    PlayerCtrl playerCtrl;
    Image currentHpbar;

    public Action onDeadChanged;
    GameObject EnemyHpbar;
    CircleCollider2D CircleCol;

    private void Awake()
    {
        mainCam = Camera.main;
        playerCtrl = GameObject.FindWithTag("PLAYER").GetComponent<PlayerCtrl>();
        CircleCol = GetComponent<CircleCollider2D>();
        
    }

    void Start()
    {
        
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>(); //UI�� ĵ���� �ȿ� �־����.
                                                                                       // UI�� transform�� �ƴ� RectRansform�� ���. //�����ϱ����ϵ��� ������ ����
        GetEnemyStatus();

        currentHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        //EnemyHpbar = GameObject.Find("bghp_bar(Clone)");
    }

    void Update()
    {
        Vector3 _hpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0)); //���� ��ǥ�� ��ũ�� ��ǥ ��, UI��ǥ�� �ٲ���.
        if(EnemyHpbar != null)
        {
        hpBar.position = _hpBarPos; //��ũ�� ��ǥ�� �ٲ� ������ ü�¹ٸ� �̵�. //����ٴϵ���
        currentHpbar.fillAmount = (float)currentHp / (float)maxHp;
        //currentHpbar�κ��� hpBar�� fillAmount�� ���� ���� ���� �翡 ���� �޶����� ������.

        }
    }

    void SetEnemyStatus(string _enemyName, int _maxHp, int _atkDmg, float _atkDistance, int _atkSpeed)
    {
        enemyName = _enemyName; //������ �ٸ� ������ ���� �� �ְ�
        maxHp = _maxHp;
        currentHp = _maxHp;
        atkDmg = _atkDmg;
        atkDistance = _atkDistance;
        atkSpeed = _atkSpeed;
    }

    void GetEnemyStatus()
    {
        if (name.Equals("Ladybird"))
        {
            SetEnemyStatus("Ladybird", 1, 1, 2,2);
        }
    }

    private void OnTriggerStay2D(Collider2D col) //���ݹ���
    {
        if (col.gameObject.CompareTag("HAMMER"))
        {
            //Debug.Log(col.gameObject.tag);
            if (playerCtrl.attacked)
            {
                currentHp -= playerCtrl.atkDmg;
                //Debug.Log(currentHp);
                if (currentHp <= 0) //�� ���
                {
                    //��� �ִϸ��̼�
                    //�Ҹ� ���� �÷��̾� �������� ���ϵ���
                    CircleCol.enabled = false;
                    onDeadChanged.Invoke();
                    Destroy(prfHpBar);
                    Destroy(gameObject,0.3f);
                    
                    
                }
            }
        }
    }


}
