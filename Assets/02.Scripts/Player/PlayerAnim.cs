using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator anim;
    PlayerCtrl playerCtrl;
    public float atkSpeed = 1;

    private void Awake()
    {
        playerCtrl = GetComponent<PlayerCtrl>(); //¡÷¿«
        
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerCtrl.onRunChanged += onRun;
        playerCtrl.onJumpChanged += onJump;
        playerCtrl.onAttackChanged += onAttack;
        SetAttackSpeed(1.5f);
    }

    private void OnDestroy()
    {
        playerCtrl.onRunChanged -= onRun;
        playerCtrl.onJumpChanged -= onJump;
    }

    void onRun(float hor)
    {
        //Mathf.Abs(hor);
        anim.SetFloat("Hor", Mathf.Abs(hor));
    }

    void onJump(bool isJump)
    {
        anim.SetBool("Jump", isJump);
    }

    void onAttack()
    {
        anim.SetTrigger("Attack");
    }


    void SetAttackSpeed(float speed)
    {
        anim.SetFloat("AtkSpeed", speed);
        atkSpeed = speed;

    }


}
