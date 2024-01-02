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

    public bool attacked = false; //여러번 공격 방지용

    float hor;
    float defaultSpeed = 3f;
    float dashSpeed = 7f;



    Rigidbody2D rigid;
    public Action<float> onRunChanged;
    public Action<bool> onJumpChanged;
    public Action onAttackChanged;
    public Action onDashChanged;

    Camera mainCam;
    SpriteRenderer spriteRenderer;
    TrailRenderer trailRenderer;



    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
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
        float Dir = transform.position.x - mousePos.x;

        if (Dir > 0)
            spriteRenderer.flipX = true;
        else
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
            onAttackChanged?.Invoke();   
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


}
