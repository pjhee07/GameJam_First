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
    public int atkSpeed; //공격속도(쿨타임)
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
        
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>(); //UI는 캔버스 안에 있어야함.
                                                                                       // UI는 transform이 아닌 RectRansform을 사용. //삭제하기편하도록 변수에 담음
        GetEnemyStatus();

        currentHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        //EnemyHpbar = GameObject.Find("bghp_bar(Clone)");
    }

    void Update()
    {
        Vector3 _hpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0)); //월드 좌표를 스크린 좌표 즉, UI좌표로 바꿔줌.
        if(EnemyHpbar != null)
        {
        hpBar.position = _hpBarPos; //스크린 좌표로 바꾼 값으로 체력바를 이동. //따라다니도록
        currentHpbar.fillAmount = (float)currentHp / (float)maxHp;
        //currentHpbar부분은 hpBar의 fillAmount를 현재 남은 피의 양에 따라 달라지게 설정함.

        }
    }

    void SetEnemyStatus(string _enemyName, int _maxHp, int _atkDmg, float _atkDistance, int _atkSpeed)
    {
        enemyName = _enemyName; //적마다 다른 스텟을 가질 수 있게
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

    private void OnTriggerStay2D(Collider2D col) //공격받음
    {
        if (col.gameObject.CompareTag("HAMMER"))
        {
            //Debug.Log(col.gameObject.tag);
            if (playerCtrl.attacked)
            {
                currentHp -= playerCtrl.atkDmg;
                //Debug.Log(currentHp);
                if (currentHp <= 0) //적 사망
                {
                    //사망 애니메이션
                    //소멸 전에 플레이어 공격하지 못하도록
                    CircleCol.enabled = false;
                    onDeadChanged.Invoke();
                    Destroy(prfHpBar);
                    Destroy(gameObject,0.3f);
                    
                    
                }
            }
        }
    }


}
