using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator anim;
    PlayerCtrl playerCtrl;


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
    }

    private void OnDestroy()
    {
        playerCtrl.onRunChanged -= onRun;
        playerCtrl.onJumpChanged -= onJump;
    }

    void onRun(float hor)
    {
        anim.SetFloat("Hor", hor);
    }

    void onJump(bool isJump)
    {
        anim.SetBool("Jump", isJump);
    }

    void onAttack()
    {
        anim.SetTrigger("Attack");
    }


}
