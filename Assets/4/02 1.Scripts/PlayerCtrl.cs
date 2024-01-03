using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCtrl : MonoBehaviour
{
    [Header("float Value")]
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float moveSpeed;
    [SerializeField] bool isJump;
    [SerializeField] bool isDash;
    [SerializeField] float dashCoolTime = 3f;
    public int atkDmg;

    public bool attacked = false; //여러번 공격감지 방지용
    float currentTime;
    float attackCoolTime = 2f;

    float hor;
    float defaultSpeed = 3f;
    float dashSpeed = 7f;
    float Dir;
    float pushForce = 4f;
    


    Rigidbody2D rigid;
    public Action<float> onRunChanged;
    public Action<bool> onJumpChanged;
    public Action onAttackChanged;
    public Action onDashChanged;

    Camera mainCam;
    SpriteRenderer spriteRenderer;
    TrailRenderer trailRenderer;

    PlayerHp playerHp;



    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        playerHp = GetComponent<PlayerHp>();
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
        currentTime += Time.deltaTime;
        Falldown();

    }
    private void FixedUpdate()
    {
        Run();
        Jump();
    }

    void Run()
    {
        hor = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(hor * moveSpeed, rigid.velocity.y);
        onRunChanged?.Invoke(hor*moveSpeed);
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDash)
            StartCoroutine(DashRoutine()); //startCoroutine
        
    }

    IEnumerator DashRoutine()
    {
        isDash = true;
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
            //transform.rotation = Quaternion.Euler(0, 180, 0); 카메라 z축 회전...
            spriteRenderer.flipX = true;
        else
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.flipX = false;

    }

    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (!isJump)
            {
                isJump = true;
                rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            onJumpChanged?.Invoke(isJump);


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
        if (Input.GetMouseButtonDown(0))
        {
            if (currentTime < attackCoolTime)
                return;
            else
            {
                currentTime = 0;
                onAttackChanged?.Invoke();

            }
        }
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

    public void KnockBack()
    {
        rigid.AddForce(-transform.right * pushForce, ForceMode2D.Impulse);
    }

    void Falldown()
    {


        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.down, 30, LayerMask.GetMask("TILEMAP")); 

        if (rayHit.collider == null)
        {
            playerHp.TakeDamage(1);
            playerHp.HpRenewal();
            //스폰포인트로 리스폰
        }




    }
}
