using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class PlayerCtrl : MonoBehaviour
{
    [Header("float Value")]
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed;
    [SerializeField] bool isJump;
    [SerializeField] bool isDash;
    [SerializeField] float dashCoolTime = 1f;
    public int atkDmg;

    public bool attacked = false; //여러번 공격감지 방지용
    float currentTime;
    float attackCoolTime = 1f;

    float hor;
    float defaultSpeed = 3f;
    float dashSpeed = 7f;
    float Dir;


    private Rigidbody2D rigid;
    public Action<float> onRunChanged;
    public Action<bool> onJumpChanged;
    public Action onAttackChanged;
    public Action onDashChanged;

    Camera mainCam;
    SpriteRenderer spriteRenderer;
    TrailRenderer trailRenderer;

    PlayerHp playerHp;
    GameObject HammerCol;



    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        playerHp = GetComponent<PlayerHp>();
        HammerCol = transform.GetChild(1).gameObject;

    }


    void Start()
    {

        moveSpeed = defaultSpeed;
        isJump = false;
        isDash = false;

        atkDmg = 1;
    }



    private void Update()
    {
        Facing();
        Attack();
        Dash();
        Talk();
        Jump();
        currentTime += Time.deltaTime;
        //Falldown();

    }
    private void FixedUpdate()
    {
        Run();
        movementJude();
    }

    void Run()
    {
        if (GameManager.Instance.textflage == false)
        {

            hor = Input.GetAxisRaw("Horizontal");
            rigid.velocity = new Vector2(hor * moveSpeed, rigid.velocity.y);
            //SoundManager.Instance.PlaySound(SoundManager.Sound.Walk);
            onRunChanged?.Invoke(hor * moveSpeed);
        }
        else
        {
            return;
        }
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDash)
            StartCoroutine(DashRoutine()); //startCoroutine

    }

    IEnumerator DashRoutine()
    {
        isDash = true;
        SoundManager.Instance.PlaySound(SoundManager.Sound.Dash);
        moveSpeed = dashSpeed;
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(0.5f);
        trailRenderer.emitting = false;
        moveSpeed = defaultSpeed;
        yield return new WaitForSeconds(dashCoolTime);
        isDash = false;
    }

    void Facing()
    {
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Dir = transform.position.x - mousePos.x;

        if (Dir > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 180, 0); 카메라 z축 회전...
            spriteRenderer.flipX = true;
            HammerCol.transform.rotation = Quaternion.Euler(0, 180, 0);


        }

        else
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.flipX = false;
            HammerCol.transform.rotation = Quaternion.Euler(0, 0, 0);

        }

    }

    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (GameManager.Instance.textflage == false)
            {
                if (!isJump)
                {
                    isJump = true;
                    rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
                onJumpChanged?.Invoke(isJump);
            }
            else
            {
                return;
            }




        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("MAP"))
        {
            isJump = false;
            onJumpChanged?.Invoke(isJump);
        }

    }

    void Attack()
    {
        // PC: 마우스 클릭 시
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스가 UI 위에 있는 경우 공격하지 않음
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            HandleAttack();
        }

        // 모바일: 터치가 발생한 경우
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // 터치가 UI 위에 있는 경우 공격하지 않음
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

            HandleAttack();
        }
    }

    void HandleAttack()
    {
        if (currentTime < attackCoolTime)
            return;

        currentTime = 0; // 초기화
        onAttackChanged?.Invoke();
        SoundManager.Instance.PlaySound(SoundManager.Sound.Attack);
    }


    void AttackTrue()
    {
        attacked = true;
    }

    void AttackFalse()
    {
        attacked = false;
    }


    void Talk()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    /*public void KnockBack()
    {
        rigid.AddForce(-transform.right * pushForce, ForceMode2D.Impulse);
    }*/

    /*  void Falldown()
      {


          //RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.down, 30, LayerMask.GetMask("TILEMAP")); 

          if (rayHit.collider == null && !isJump)
          {
              playerHp.TakeDamage(1);
              playerHp.HpRenewal();
              //스폰포인트로 리스폰
          } 



      }*/

    void movementJude()
    {
        if (rigid.velocity.x == 0)
            GameManager.Instance.Movement = false;
        else
            GameManager.Instance.Movement = true;

    }





}
