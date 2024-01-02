using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove; //행동지표를 결정할 변수
    SpriteRenderer spriteRenderer;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 3);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Facing();
    }
    void FixedUpdate()
    {
        //한 '방향'으로만 알아서 움직이게
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //플랫폼 체크
        //몬스터는 앞을 체크해야
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0)); //시작점,방향,색깔

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("TILEMAP")); //시작,방향,거리,레이어마스크

        if (rayHit.collider == null)
        {
            Debug.Log("경고! 이 앞 낭떨어지다!");
            nextMove = nextMove * (-1); // 낭떠러지에 닿으면 1보 후퇴
            CancelInvoke(); //모든 Invoke함수를 멈추고 다시 생각
            Invoke("Think", 5);
            //즉, 낭떨어지에 닿았을 때 Invoke 함수를 멈추지 않으면
            //1보 후퇴를 하더라도 5초가 끝나기 전에는 이전과 같은 방향을 향하고 있지면
            //CancelInvoke를 사용함으로써 5초 이전이라도 낭떨어지에 닿으면 바로 방향을 바꿔버릴 수 있다.

        }
    }
    //행동지표를 바꿔줄 함수 생각 ---> 랜덤클래스 활용

    void Think()
    {
        nextMove = Random.Range(-1, 2); //-1이면 왼쪽, 0이면 멈추기, 
        // 1이면 오른쪽으로 이동
        Invoke("Think", 5);
    }

    void Facing()
    {
        if (nextMove < 0)
            spriteRenderer.flipX = false;
        else if (nextMove > 0)
            spriteRenderer.flipX = true;
        //0일때는 그대로

            
            
    }
}
