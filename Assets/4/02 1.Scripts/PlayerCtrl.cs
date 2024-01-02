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

    float hor;
    float defaultSpeed = 3f;
    float dashSpeed = 7f;

    Rigidbody2D rigid;
    public Action<float> onRunChanged;
    public Action<bool> onJumpChanged;
    public Action onAttackChanged;

    Camera mainCam;
    SpriteRenderer spriteRenderer;



    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        moveSpeed = defaultSpeed;
        isJump = false;
        mainCam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        Facing();
        Attack();
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
        onRunChanged?.Invoke(rigid.velocity.magnitude);
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

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onAttackChanged?.Invoke();   
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("MAP"))
            isJump = false;
        onJumpChanged?.Invoke(isJump);

    }



}
